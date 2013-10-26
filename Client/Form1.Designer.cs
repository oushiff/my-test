namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.user_tb = new System.Windows.Forms.TextBox();
            this.svrip_tb = new System.Windows.Forms.TextBox();
            this.svrport_tb = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "请输入服务器IP：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "请输入端口号：";
            // 
            // user_tb
            // 
            this.user_tb.Location = new System.Drawing.Point(154, 28);
            this.user_tb.Name = "user_tb";
            this.user_tb.Size = new System.Drawing.Size(100, 21);
            this.user_tb.TabIndex = 3;
            // 
            // svrip_tb
            // 
            this.svrip_tb.Location = new System.Drawing.Point(154, 76);
            this.svrip_tb.Name = "svrip_tb";
            this.svrip_tb.Size = new System.Drawing.Size(100, 21);
            this.svrip_tb.TabIndex = 4;
            // 
            // svrport_tb
            // 
            this.svrport_tb.Location = new System.Drawing.Point(154, 117);
            this.svrport_tb.Name = "svrport_tb";
            this.svrport_tb.Size = new System.Drawing.Size(100, 21);
            this.svrport_tb.TabIndex = 5;
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(30, 213);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(107, 23);
            this.login_btn.TabIndex = 6;
            this.login_btn.Text = "登录聊天服务器";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(178, 213);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 7;
            this.cancel_btn.Text = "取消";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.svrport_tb);
            this.Controls.Add(this.svrip_tb);
            this.Controls.Add(this.user_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox user_tb;
        private System.Windows.Forms.TextBox svrip_tb;
        private System.Windows.Forms.TextBox svrport_tb;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Button cancel_btn;
    }
}

