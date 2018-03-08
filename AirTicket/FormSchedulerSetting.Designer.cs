namespace AirTicket
{
    partial class FormSchedulerSetting
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lbSMTPServer = new System.Windows.Forms.Label();
            this.lbMailPort = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbEmailTo = new System.Windows.Forms.Label();
            this.txtEmailServer = new System.Windows.Forms.TextBox();
            this.txtEmailUserName = new System.Windows.Forms.TextBox();
            this.txtEmailPassword = new System.Windows.Forms.TextBox();
            this.txtTicketPriceFrom = new System.Windows.Forms.TextBox();
            this.txtTicketPriceTo = new System.Windows.Forms.TextBox();
            this.txtEmailTo = new System.Windows.Forms.TextBox();
            this.groupEmailServer = new System.Windows.Forms.GroupBox();
            this.numericEmailPort = new System.Windows.Forms.NumericUpDown();
            this.groupTicketInfo = new System.Windows.Forms.GroupBox();
            this.lbTicketPriceFrom = new System.Windows.Forms.Label();
            this.lbTicketPriceTo = new System.Windows.Forms.Label();
            this.groupEmailServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEmailPort)).BeginInit();
            this.groupTicketInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(463, 331);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbSMTPServer
            // 
            this.lbSMTPServer.AutoSize = true;
            this.lbSMTPServer.Location = new System.Drawing.Point(7, 42);
            this.lbSMTPServer.Name = "lbSMTPServer";
            this.lbSMTPServer.Size = new System.Drawing.Size(93, 17);
            this.lbSMTPServer.TabIndex = 1;
            this.lbSMTPServer.Text = "Máy chủ Mail:";
            // 
            // lbMailPort
            // 
            this.lbMailPort.AutoSize = true;
            this.lbMailPort.Location = new System.Drawing.Point(366, 42);
            this.lbMailPort.Name = "lbMailPort";
            this.lbMailPort.Size = new System.Drawing.Size(79, 17);
            this.lbMailPort.TabIndex = 2;
            this.lbMailPort.Text = "Cổng Email:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(6, 90);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(99, 17);
            this.lbUserName.TabIndex = 3;
            this.lbUserName.Text = "Tên đăng nhập:";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(7, 137);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(67, 17);
            this.lbPassword.TabIndex = 4;
            this.lbPassword.Text = "Mật khẩu:";
            // 
            // lbEmailTo
            // 
            this.lbEmailTo.AutoSize = true;
            this.lbEmailTo.Location = new System.Drawing.Point(7, 47);
            this.lbEmailTo.Name = "lbEmailTo";
            this.lbEmailTo.Size = new System.Drawing.Size(76, 17);
            this.lbEmailTo.TabIndex = 5;
            this.lbEmailTo.Text = "Email nhận:";
            // 
            // txtEmailServer
            // 
            this.txtEmailServer.Location = new System.Drawing.Point(125, 34);
            this.txtEmailServer.Name = "txtEmailServer";
            this.txtEmailServer.Size = new System.Drawing.Size(235, 25);
            this.txtEmailServer.TabIndex = 0;
            // 
            // txtEmailUserName
            // 
            this.txtEmailUserName.Location = new System.Drawing.Point(125, 82);
            this.txtEmailUserName.MaxLength = 100;
            this.txtEmailUserName.Name = "txtEmailUserName";
            this.txtEmailUserName.Size = new System.Drawing.Size(420, 25);
            this.txtEmailUserName.TabIndex = 2;
            // 
            // txtEmailPassword
            // 
            this.txtEmailPassword.Location = new System.Drawing.Point(125, 129);
            this.txtEmailPassword.MaxLength = 100;
            this.txtEmailPassword.Name = "txtEmailPassword";
            this.txtEmailPassword.PasswordChar = '*';
            this.txtEmailPassword.Size = new System.Drawing.Size(420, 25);
            this.txtEmailPassword.TabIndex = 3;
            // 
            // txtTicketPriceFrom
            // 
            this.txtTicketPriceFrom.Location = new System.Drawing.Point(89, 90);
            this.txtTicketPriceFrom.MaxLength = 100;
            this.txtTicketPriceFrom.Name = "txtTicketPriceFrom";
            this.txtTicketPriceFrom.Size = new System.Drawing.Size(200, 25);
            this.txtTicketPriceFrom.TabIndex = 5;
            // 
            // txtTicketPriceTo
            // 
            this.txtTicketPriceTo.Location = new System.Drawing.Point(345, 90);
            this.txtTicketPriceTo.MaxLength = 100;
            this.txtTicketPriceTo.Name = "txtTicketPriceTo";
            this.txtTicketPriceTo.Size = new System.Drawing.Size(200, 25);
            this.txtTicketPriceTo.TabIndex = 6;
            // 
            // txtEmailTo
            // 
            this.txtEmailTo.Location = new System.Drawing.Point(89, 39);
            this.txtEmailTo.MaxLength = 200;
            this.txtEmailTo.Name = "txtEmailTo";
            this.txtEmailTo.Size = new System.Drawing.Size(456, 25);
            this.txtEmailTo.TabIndex = 4;
            // 
            // groupEmailServer
            // 
            this.groupEmailServer.Controls.Add(this.numericEmailPort);
            this.groupEmailServer.Controls.Add(this.lbSMTPServer);
            this.groupEmailServer.Controls.Add(this.lbMailPort);
            this.groupEmailServer.Controls.Add(this.lbUserName);
            this.groupEmailServer.Controls.Add(this.lbPassword);
            this.groupEmailServer.Controls.Add(this.txtEmailPassword);
            this.groupEmailServer.Controls.Add(this.txtEmailUserName);
            this.groupEmailServer.Controls.Add(this.txtEmailServer);
            this.groupEmailServer.Location = new System.Drawing.Point(5, 12);
            this.groupEmailServer.Name = "groupEmailServer";
            this.groupEmailServer.Size = new System.Drawing.Size(555, 171);
            this.groupEmailServer.TabIndex = 12;
            this.groupEmailServer.TabStop = false;
            this.groupEmailServer.Text = "Thông tin mail server";
            // 
            // numericEmailPort
            // 
            this.numericEmailPort.Location = new System.Drawing.Point(451, 34);
            this.numericEmailPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericEmailPort.Name = "numericEmailPort";
            this.numericEmailPort.Size = new System.Drawing.Size(94, 25);
            this.numericEmailPort.TabIndex = 1;
            this.numericEmailPort.ValueChanged += new System.EventHandler(this.numericEmailPort_ValueChanged);
            // 
            // groupTicketInfo
            // 
            this.groupTicketInfo.Controls.Add(this.lbTicketPriceTo);
            this.groupTicketInfo.Controls.Add(this.lbTicketPriceFrom);
            this.groupTicketInfo.Controls.Add(this.lbEmailTo);
            this.groupTicketInfo.Controls.Add(this.txtEmailTo);
            this.groupTicketInfo.Controls.Add(this.txtTicketPriceTo);
            this.groupTicketInfo.Controls.Add(this.txtTicketPriceFrom);
            this.groupTicketInfo.Location = new System.Drawing.Point(5, 189);
            this.groupTicketInfo.Name = "groupTicketInfo";
            this.groupTicketInfo.Size = new System.Drawing.Size(555, 136);
            this.groupTicketInfo.TabIndex = 13;
            this.groupTicketInfo.TabStop = false;
            this.groupTicketInfo.Text = "Thông tin gửi giá vé";
            // 
            // lbTicketPriceFrom
            // 
            this.lbTicketPriceFrom.AutoSize = true;
            this.lbTicketPriceFrom.Location = new System.Drawing.Point(7, 98);
            this.lbTicketPriceFrom.Name = "lbTicketPriceFrom";
            this.lbTicketPriceFrom.Size = new System.Drawing.Size(65, 17);
            this.lbTicketPriceFrom.TabIndex = 12;
            this.lbTicketPriceFrom.Text = "Giá vé từ:";
            // 
            // lbTicketPriceTo
            // 
            this.lbTicketPriceTo.AutoSize = true;
            this.lbTicketPriceTo.Location = new System.Drawing.Point(299, 98);
            this.lbTicketPriceTo.Name = "lbTicketPriceTo";
            this.lbTicketPriceTo.Size = new System.Drawing.Size(36, 17);
            this.lbTicketPriceTo.TabIndex = 13;
            this.lbTicketPriceTo.Text = "Đến:";
            // 
            // FormSchedulerSetting
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 371);
            this.Controls.Add(this.groupTicketInfo);
            this.Controls.Add(this.groupEmailServer);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormSchedulerSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cài đặt tham số thông báo vé máy bay";
            this.Load += new System.EventHandler(this.FormSchedulerSetting_Load);
            this.groupEmailServer.ResumeLayout(false);
            this.groupEmailServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEmailPort)).EndInit();
            this.groupTicketInfo.ResumeLayout(false);
            this.groupTicketInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbSMTPServer;
        private System.Windows.Forms.Label lbMailPort;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbEmailTo;
        private System.Windows.Forms.TextBox txtEmailServer;
        private System.Windows.Forms.TextBox txtEmailUserName;
        private System.Windows.Forms.TextBox txtEmailPassword;
        private System.Windows.Forms.TextBox txtTicketPriceFrom;
        private System.Windows.Forms.TextBox txtTicketPriceTo;
        private System.Windows.Forms.TextBox txtEmailTo;
        private System.Windows.Forms.GroupBox groupEmailServer;
        private System.Windows.Forms.NumericUpDown numericEmailPort;
        private System.Windows.Forms.GroupBox groupTicketInfo;
        private System.Windows.Forms.Label lbTicketPriceTo;
        private System.Windows.Forms.Label lbTicketPriceFrom;
    }
}