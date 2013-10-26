namespace Client
{
    partial class chat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chat));
            this.user_lb = new System.Windows.Forms.Label();
            this.svrskt_lb = new System.Windows.Forms.Label();
            this.hide_cb = new System.Windows.Forms.CheckBox();
            this.chatrcd_rtb = new System.Windows.Forms.RichTextBox();
            this.online_cb = new System.Windows.Forms.ComboBox();
            this.nudge_pb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.private_rb = new System.Windows.Forms.RadioButton();
            this.broadcast_rb = new System.Windows.Forms.RadioButton();
            this.msg_tb = new System.Windows.Forms.TextBox();
            this.send_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.comeback_tsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.close_tsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudge_pb)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // user_lb
            // 
            this.user_lb.AutoSize = true;
            this.user_lb.Location = new System.Drawing.Point(13, 13);
            this.user_lb.Name = "user_lb";
            this.user_lb.Size = new System.Drawing.Size(29, 12);
            this.user_lb.TabIndex = 0;
            this.user_lb.Text = "name";
            // 
            // svrskt_lb
            // 
            this.svrskt_lb.AutoSize = true;
            this.svrskt_lb.Location = new System.Drawing.Point(160, 13);
            this.svrskt_lb.Name = "svrskt_lb";
            this.svrskt_lb.Size = new System.Drawing.Size(41, 12);
            this.svrskt_lb.TabIndex = 1;
            this.svrskt_lb.Text = "label2";
            // 
            // hide_cb
            // 
            this.hide_cb.AutoSize = true;
            this.hide_cb.Location = new System.Drawing.Point(333, 9);
            this.hide_cb.Name = "hide_cb";
            this.hide_cb.Size = new System.Drawing.Size(96, 16);
            this.hide_cb.TabIndex = 2;
            this.hide_cb.Text = "最小化到托盘";
            this.hide_cb.UseVisualStyleBackColor = true;
            this.hide_cb.CheckedChanged += new System.EventHandler(this.hide_cb_CheckedChanged);
            // 
            // chatrcd_rtb
            // 
            this.chatrcd_rtb.Location = new System.Drawing.Point(15, 38);
            this.chatrcd_rtb.Name = "chatrcd_rtb";
            this.chatrcd_rtb.Size = new System.Drawing.Size(414, 155);
            this.chatrcd_rtb.TabIndex = 3;
            this.chatrcd_rtb.Text = "";
            this.chatrcd_rtb.TextChanged += new System.EventHandler(this.chartrcd_rtb_TextChanged);
            // 
            // online_cb
            // 
            this.online_cb.FormattingEnabled = true;
            this.online_cb.Location = new System.Drawing.Point(122, 208);
            this.online_cb.Name = "online_cb";
            this.online_cb.Size = new System.Drawing.Size(79, 20);
            this.online_cb.TabIndex = 4;
            this.online_cb.DropDown += new System.EventHandler(this.online_cb_DropDown);
            // 
            // nudge_pb
            // 
            this.nudge_pb.Image = ((System.Drawing.Image)(resources.GetObject("nudge_pb.Image")));
            this.nudge_pb.Location = new System.Drawing.Point(218, 199);
            this.nudge_pb.Name = "nudge_pb";
            this.nudge_pb.Size = new System.Drawing.Size(32, 32);
            this.nudge_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.nudge_pb.TabIndex = 5;
            this.nudge_pb.TabStop = false;
            this.nudge_pb.Click += new System.EventHandler(this.nudge_pb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "选择接受消息对象";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "聊天模式";
            // 
            // private_rb
            // 
            this.private_rb.AutoSize = true;
            this.private_rb.Checked = true;
            this.private_rb.Location = new System.Drawing.Point(315, 211);
            this.private_rb.Name = "private_rb";
            this.private_rb.Size = new System.Drawing.Size(47, 16);
            this.private_rb.TabIndex = 8;
            this.private_rb.TabStop = true;
            this.private_rb.Text = "私聊";
            this.private_rb.UseVisualStyleBackColor = true;
            // 
            // broadcast_rb
            // 
            this.broadcast_rb.AutoSize = true;
            this.broadcast_rb.Location = new System.Drawing.Point(370, 211);
            this.broadcast_rb.Name = "broadcast_rb";
            this.broadcast_rb.Size = new System.Drawing.Size(59, 16);
            this.broadcast_rb.TabIndex = 9;
            this.broadcast_rb.Text = "聊天室";
            this.broadcast_rb.UseVisualStyleBackColor = true;
            this.broadcast_rb.CheckedChanged += new System.EventHandler(this.broadcast_rb_CheckedChanged);
            // 
            // msg_tb
            // 
            this.msg_tb.Location = new System.Drawing.Point(17, 237);
            this.msg_tb.Multiline = true;
            this.msg_tb.Name = "msg_tb";
            this.msg_tb.Size = new System.Drawing.Size(412, 51);
            this.msg_tb.TabIndex = 10;
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(15, 304);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(75, 23);
            this.send_btn.TabIndex = 11;
            this.send_btn.Text = "发送消息";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(112, 304);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(75, 23);
            this.close_btn.TabIndex = 12;
            this.close_btn.Text = "关闭";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(224, 304);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(85, 23);
            this.save_btn.TabIndex = 13;
            this.save_btn.Text = "保存聊天记录";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(333, 304);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(96, 23);
            this.clear_btn.TabIndex = 14;
            this.clear_btn.Text = "清除聊天记录";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comeback_tsmi,
            this.close_tsmi});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // comeback_tsmi
            // 
            this.comeback_tsmi.Name = "comeback_tsmi";
            this.comeback_tsmi.Size = new System.Drawing.Size(124, 22);
            this.comeback_tsmi.Text = "还原窗口";
            this.comeback_tsmi.Click += new System.EventHandler(this.comeback_tsmi_Click);
            // 
            // close_tsmi
            // 
            this.close_tsmi.Name = "close_tsmi";
            this.close_tsmi.Size = new System.Drawing.Size(124, 22);
            this.close_tsmi.Text = "关闭连接";
            this.close_tsmi.Click += new System.EventHandler(this.close_tsmi_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 358);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.msg_tb);
            this.Controls.Add(this.broadcast_rb);
            this.Controls.Add(this.private_rb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudge_pb);
            this.Controls.Add(this.online_cb);
            this.Controls.Add(this.chatrcd_rtb);
            this.Controls.Add(this.hide_cb);
            this.Controls.Add(this.user_lb);
            this.Controls.Add(this.svrskt_lb);
            this.Name = "chat";
            this.Text = "chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.chat_FormClosing);
            this.Load += new System.EventHandler(this.chat_Load);
            this.SizeChanged += new System.EventHandler(this.chat_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nudge_pb)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label user_lb;
        private System.Windows.Forms.Label svrskt_lb;
        private System.Windows.Forms.CheckBox hide_cb;
        private System.Windows.Forms.RichTextBox chatrcd_rtb;
        private System.Windows.Forms.ComboBox online_cb;
        private System.Windows.Forms.PictureBox nudge_pb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton private_rb;
        private System.Windows.Forms.RadioButton broadcast_rb;
        private System.Windows.Forms.TextBox msg_tb;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem comeback_tsmi;
        private System.Windows.Forms.ToolStripMenuItem close_tsmi;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}