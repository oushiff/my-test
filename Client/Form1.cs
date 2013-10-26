using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;



namespace Client
{

    public partial class Form1 : Form
    {
        private IPAddress _ipAddr;

        #region 登录窗体构造函数
        public Form1()
        {
            InitializeComponent();
            
        }
        #endregion

        //检验输入是否合法
        private bool ValidateInfo()
        {
            //用户名为空，提示错误
            if (user_tb.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请填写用户名！",
                "提示",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return false;
            }
            //IP地址不合法，提示错误
            if (!IPAddress.TryParse(svrip_tb.Text, out _ipAddr))
            {
                MessageBox.Show("IP地址不合法!",
                "提示",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return false;
            }
            int _port;
            //端口不存在，提示错误
            if (!int.TryParse(svrport_tb.Text, out _port))
            {
                MessageBox.Show("端口号不合法!",
                "提示",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return false;
            }
            else
            {
                //端口的数字不符合
                if (_port < 1024 || _port > 65535)
                {
                    MessageBox.Show("端口号不合法!",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            //验证数据合法性
            if (!ValidateInfo())
            {
                return;
            }
            int port = int.Parse(svrport_tb.Text);
            //向服务器发出连接请求
            TCPConnection conn = new TCPConnection(_ipAddr, port);
            TcpClient _tcpc = conn.Connect();
            if (_tcpc == null)
            {
                MessageBox.Show("无法连接到服务器，请重试！",
                "错误",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
            else
            {
                NetworkStream netstream = _tcpc.GetStream();
                //向服务器发送用户名以确认身份
                netstream.Write(Encoding.Unicode.GetBytes(user_tb.Text), 0,
                Encoding.Unicode.GetBytes(user_tb.Text).Length);
                //得到登录结果
                byte[] buffer = new byte[50];
                netstream.Read(buffer, 0, buffer.Length);
                string connResult = Encoding.Unicode.GetString(buffer).TrimEnd('\0');
                if (connResult.Equals("cmd::Failed"))
                {
                    MessageBox.Show("您的用户名已经被使用，请尝试其他用户名!",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    //传递参数
                    string svrskt = svrip_tb.Text + ":" + svrport_tb.Text;
                    chat chatFrm = new chat(user_tb.Text, netstream, svrskt);
                    chatFrm.Owner = this;
                    this.Hide();
                    //弹出聊天窗口
                    chatFrm.Show();
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            svrip_tb.Text = "192.168.2.102";
            svrport_tb.Text = "8888";
            user_tb.Focus();
        }

        


    }
}
