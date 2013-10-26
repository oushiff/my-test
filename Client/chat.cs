using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Runtime;
using System.IO;
using System.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Resources;

namespace Client
{

    public partial class chat : Form
    {
        #region 私有字段
        /// <summary>
        /// 当前用户名
        /// </summary>
        string _username=null;
        /// <summary>
        /// 服务器套接字的字符串形式，从登录窗体得到
        /// </summary>
        string _svrskt=null;
        /// <summary>
        /// 用于接受和发送的网络流，从登陆窗体得到
        /// </summary>
        NetworkStream _nws=null;
        /// <summary>
        /// 接收数据缓冲区大小64K
        /// </summary>
        private const int _maxPacket = 2048;
        /// <summary>
        /// 只是是否最小化到托盘
        /// </summary>
        private bool _hideFlag=false;
        /// <summary>
        /// 用于接受消息的线程
        /// </summary>
        private Thread _receiveThread=null;
        /// <summary>
        /// 播放消息提示的播放器
        /// </summary>
        private SoundPlayer _sp1 =new SoundPlayer ( Properties.Resources.msg);
        private SoundPlayer _sp2=new SoundPlayer ( Properties.Resources.nudge);

        #endregion

        public chat(string userName, NetworkStream nws, string svrskt)
        {
            InitializeComponent();
            _username = userName;
            _nws = nws;
            _svrskt = svrskt;
        }

        public chat()
        {
            InitializeComponent();
        }

        //装载窗口
        private void chat_Load(object sender, EventArgs e)
        {
            //为该窗口创建一个接收线程
            _receiveThread = new Thread(new ThreadStart(ReceiveMsg));
            //线程开始工作
            _receiveThread.Start();
            online_cb.Enabled = true;
            //在窗口中显示信息
            user_lb.Text = "当前用户：" + _username;
            svrskt_lb.Text = "服务器：" + _svrskt;
            
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            string localTxt = null;
            string sendTxt = null;
            string msg = msg_tb.Text.Trim();
            //当为输入文字信息时，提示错误
            if (msg == string.Empty)
            {
                MessageBox.Show("不能发送空消息",
                "提示",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            //如果是聊天室模式则向服务器发送广播请求
            if (broadcast_rb.Checked)
            {
                localTxt = string.Format("[广播]您在 {0} 对所有人说：\r\n{1}\r\n\r\n",
                DateTime.Now, msg);
                sendTxt = string.Format("[广播]{0} 在 {1} 对所有人说：\r\n{2}\r\n\r\n",
                _username, DateTime.Now, msg);
                //发送广播请求
                _nws.Write(new byte[] { 0, 5 }, 0, 2);
            }
            else  //私聊
            {
                string _receiver = online_cb.Text;
                //私聊却没指定接收方，提示错误
                if (_receiver == string.Empty)
                {
                    MessageBox.Show("请选择一个接收者！\n如果没有接受者可选，表明当前只有您一个人在线\t",
                    "发送消息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    return;
                }
                localTxt = string.Format("[私聊]您在 {0} 对 {1} 说：\r\n{2}\r\n\r\n",
                DateTime.Now, _receiver, msg);
                sendTxt = string.Format("[私聊]{0} 在 {1} 对您说：\r\n{2}\r\n\r\n", _username,
                DateTime.Now, msg);
                //发送接受者用户名
                _nws.Write(Encoding.Unicode.GetBytes(_receiver), 0,
                Encoding.Unicode.GetBytes(_receiver).Length);
            }
            //发送文字
            _nws.Write(Encoding.Unicode.GetBytes(sendTxt), 0,
            Encoding.Unicode.GetBytes(sendTxt).Length);
            //在本地显示文字
            chatrcd_rtb.AppendText(localTxt);
            //清空输入区
            msg_tb.Clear();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            //弹出提示窗
            ret = MessageBox.Show("确定与服务器断开连接吗？",
            "退出",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);
            if (ret == DialogResult.OK)
            {
                //向服务器发送离线请求
                _nws.Write(new byte[] { 0, 1 }, 0, 2);
                //结束接受消息的线程
                if (_receiveThread != null)
                {
                    _receiveThread.Abort();
                }
                //关闭网络流
                _nws.Close();
                //关闭父窗口及自身
                this.Owner.Close();
                this.Close();
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            //弹出提示窗
            SaveFileDialog sfd = new SaveFileDialog();
            //设置提示窗内的默认选项
            sfd.Filter = "文本文件(*.txt)|*.txt";
            sfd.AddExtension = true;
            if ((ret = sfd.ShowDialog()) == DialogResult.OK)
            {
                chatrcd_rtb.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            //弹出提示窗
            ret = MessageBox.Show("确定清除吗？清除后不可恢复。",
            "提示",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);
            if (ret == DialogResult.OK)
            {
                //点击确认后，清空本地的聊天记录窗口
                chatrcd_rtb.Clear();
            }
        }

        private string DecodingBytes(byte[] s)
        {
            return string.Concat(s[0].ToString(), s[1].ToString());
        }

        /// <summary>
        /// 接受消息的线程执行体
        /// </summary>
        private void ReceiveMsg()
        {
            while (true)
            {
                byte[] packet = new byte[_maxPacket];
                //接收数据包
                _nws.Read(packet, 0, packet.Length);
                string _cmd = DecodingBytes(packet);

                switch (_cmd)
                {
                    /// "11"-服务器要求客户机更新在线列表
                    /// "12"-服务器要求客户机做闪屏振动
                    /// default-接受用户消息或者系统消息的正文
                    case "11":  //更新在线列表
                        {
                            byte[] onlineBuff = new byte[_maxPacket];
                            //接收在线列表
                            int byteCnt = _nws.Read(onlineBuff, 0, onlineBuff.Length);
                            IFormatter format = new BinaryFormatter();
                            MemoryStream stream = new MemoryStream();
                            //反序列化
                            stream.Write(onlineBuff, 0, byteCnt);
                            stream.Position = 0;
                            StringCollection onlineList =
                            (StringCollection)format.Deserialize(stream);
                            online_cb.Items.Clear();
                            //更新下拉列表的信息
                            foreach (string onliner in onlineList)
                            {
                                if (!onliner.Equals(_username))
                                {
                                    online_cb.Items.Add(onliner);
                                }
                            }
                            break;
                        }
                    case "12":  //闪屏振动
                        {
                            Nudge();
                            break;
                        }
                    default: //文本消息
                        {
                            //接收文字
                            string displaytxt = Encoding.Unicode.GetString(packet);
                            //显示在窗口上
                            chatrcd_rtb.AppendText(displaytxt);
                            //播放声音
                            _sp1.Play();
                            break;
                        }
                }

            }
        }

        //处理窗口振动的函数
        private void Nudge()
        {
            //当最小化托盘时，不震动
            if (notifyIcon1.Visible == true)
            {
                return;
            }
            //当窗口最小化的时候，将窗口复原
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            int i = 0;
            //定义窗口在振动时的几个位置
            Point _old = this.Location;
            Point _new1 = new Point(_old.X + 2, _old.Y + 2);
            Point _new2 = new Point(_old.X - 2, _old.Y - 2);
            _sp2.Play(); //播放音乐
            //窗口振动4次
            while (i < 4)
            {
                this.Location = _new1;
                Thread.Sleep(60); //60ms后再到下一位置
                this.Location = _new2;
                Thread.Sleep(60);   //60ms后再到下一位置
                i++;
            }
            this.Location = _old;
        
        }

        private void chartrcd_rtb_TextChanged(object sender, EventArgs e)
        {
            //将控件滚动至信息的末尾
            chatrcd_rtb.ScrollToCaret();
            //当窗口最小化的时候，闪烁图标
            if (this.WindowState == FormWindowState.Minimized)
            {
                FlashWindow(this.Handle, true);
            }
        }

        private void chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            if (e.CloseReason == CloseReason.FormOwnerClosing)
            {
                return;
            }
            close_btn_Click(sender, e);
        }

        [DllImport("user32.dll")]
        public static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

        private void chat_SizeChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Normal:  //当窗口未最小化或隐藏时，不闪烁
                    FlashWindow(this.Handle, false);
                    break;
                case FormWindowState.Minimized:  //当窗口最小化时
                    if (_hideFlag)  //窗口隐藏时
                    {
                        notifyIcon1.Visible = true; // 显示图标
                        this.Visible = false; //隐藏窗口
                    }
                    break;
                default:
                    break;
            }
        }

        private void online_cb_DropDown(object sender, EventArgs e)
        {
            //向服务器发送更新用户列表的请求
            _nws.Write(new byte[] { 0, 2 }, 0, 2);
        }

        private void broadcast_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (private_rb.Checked)
            {
                online_cb.Enabled = true;
            }
            else
            {
                online_cb.Enabled = false;
            }
        }

        private void hide_cb_CheckedChanged(object sender, EventArgs e)
        {
            _hideFlag = hide_cb.Checked;
        }

        private void nudge_pb_Click(object sender, EventArgs e)
        {
            string displayTxt = null;
            //当在私聊的情况下，却没有选择接受者，提示错误信息
            if (private_rb.Checked && online_cb.Text == string.Empty)
            {
                MessageBox.Show("非聊天室模式下必须先选择一个接收者！",
                "发送闪屏振动",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            //私聊的情况下
            if (private_rb.Checked)
            {
                //向服务器发送请求
                _nws.Write(new byte[] { 0, 4 }, 0, 2);
                string _receiver = online_cb.Text;
                _nws.Write(Encoding.Unicode.GetBytes(_receiver), 0,
                Encoding.Unicode.GetBytes(_receiver).Length);
                //设置显示信息
                displayTxt = string.Format("[系统提示]您向 {0} 发送了一个闪屏振动。\r\n\r\n",
                _receiver);
            }
            else
            {
                //向服务器发送请求
                _nws.Write(new byte[] { 0, 3 }, 0, 2);
                //设置显示信息
                displayTxt = "[系统提示]您向所有人发送了一个闪屏振动。\r\n\r\n";
            }
            //发送显示信息
            chatrcd_rtb.AppendText(displayTxt);
            Nudge();
        }

        private void close_tsmi_Click(object sender, EventArgs e)
        {
            close_btn_Click(sender, e);
        }

        private void comeback_tsmi_Click(object sender, EventArgs e)
        {
            //隐藏图标
            notifyIcon1.Visible = false;
            //显示窗口
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            //窗口到最前
            this.BringToFront();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //双击图标还原窗口
            comeback_tsmi_Click(sender, e);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

       

        
        



    }
}
