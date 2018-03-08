namespace AirTicket
{
    partial class FormAirTicket
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.udBabyNumber = new System.Windows.Forms.NumericUpDown();
            this.udChildren = new System.Windows.Forms.NumericUpDown();
            this.udPeopleNumber = new System.Windows.Forms.NumericUpDown();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbBaby = new System.Windows.Forms.Label();
            this.lbChildren = new System.Windows.Forms.Label();
            this.lbPeopleNumber = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.comboTicket = new System.Windows.Forms.ComboBox();
            this.comboSeat = new System.Windows.Forms.ComboBox();
            this.comboDesPlace = new System.Windows.Forms.ComboBox();
            this.comboSourcePlace = new System.Windows.Forms.ComboBox();
            this.comboWebsiteSearch = new System.Windows.Forms.ComboBox();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.lbTicket = new System.Windows.Forms.Label();
            this.lbSeat = new System.Windows.Forms.Label();
            this.lbDesPlace = new System.Windows.Forms.Label();
            this.lbSourcePlace = new System.Windows.Forms.Label();
            this.lbWebsiteSearch = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.groupTicketInfo = new System.Windows.Forms.GroupBox();
            this.lbScanTicketState = new System.Windows.Forms.Label();
            this.dataTicket = new System.Windows.Forms.DataGridView();
            this.clNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSearchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAirPortKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSourcePlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDesPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTicketPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTripLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbLoadingStatus = new System.Windows.Forms.Label();
            this.groupSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udBabyNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPeopleNumber)).BeginInit();
            this.groupTicketInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // groupSearch
            // 
            this.groupSearch.Controls.Add(this.udBabyNumber);
            this.groupSearch.Controls.Add(this.udChildren);
            this.groupSearch.Controls.Add(this.udPeopleNumber);
            this.groupSearch.Controls.Add(this.btnSearch);
            this.groupSearch.Controls.Add(this.lbBaby);
            this.groupSearch.Controls.Add(this.lbChildren);
            this.groupSearch.Controls.Add(this.lbPeopleNumber);
            this.groupSearch.Controls.Add(this.dtEndDate);
            this.groupSearch.Controls.Add(this.dtStartDate);
            this.groupSearch.Controls.Add(this.comboTicket);
            this.groupSearch.Controls.Add(this.comboSeat);
            this.groupSearch.Controls.Add(this.comboDesPlace);
            this.groupSearch.Controls.Add(this.comboSourcePlace);
            this.groupSearch.Controls.Add(this.comboWebsiteSearch);
            this.groupSearch.Controls.Add(this.lbEndDate);
            this.groupSearch.Controls.Add(this.lbStartDate);
            this.groupSearch.Controls.Add(this.lbTicket);
            this.groupSearch.Controls.Add(this.lbSeat);
            this.groupSearch.Controls.Add(this.lbDesPlace);
            this.groupSearch.Controls.Add(this.lbSourcePlace);
            this.groupSearch.Controls.Add(this.lbWebsiteSearch);
            this.groupSearch.Location = new System.Drawing.Point(5, 3);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(912, 218);
            this.groupSearch.TabIndex = 0;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "Thông tin tìm kiếm";
            // 
            // udBabyNumber
            // 
            this.udBabyNumber.Location = new System.Drawing.Point(637, 32);
            this.udBabyNumber.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.udBabyNumber.Name = "udBabyNumber";
            this.udBabyNumber.ReadOnly = true;
            this.udBabyNumber.Size = new System.Drawing.Size(39, 25);
            this.udBabyNumber.TabIndex = 3;
            // 
            // udChildren
            // 
            this.udChildren.Location = new System.Drawing.Point(526, 32);
            this.udChildren.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.udChildren.Name = "udChildren";
            this.udChildren.ReadOnly = true;
            this.udChildren.Size = new System.Drawing.Size(39, 25);
            this.udChildren.TabIndex = 2;
            this.udChildren.ValueChanged += new System.EventHandler(this.udChildren_ValueChanged);
            // 
            // udPeopleNumber
            // 
            this.udPeopleNumber.Location = new System.Drawing.Point(410, 32);
            this.udPeopleNumber.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.udPeopleNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPeopleNumber.Name = "udPeopleNumber";
            this.udPeopleNumber.ReadOnly = true;
            this.udPeopleNumber.Size = new System.Drawing.Size(39, 25);
            this.udPeopleNumber.TabIndex = 1;
            this.udPeopleNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPeopleNumber.ValueChanged += new System.EventHandler(this.udPeopleNumber_ValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(762, 173);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(135, 29);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Tải thông tin";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbBaby
            // 
            this.lbBaby.AutoSize = true;
            this.lbBaby.Location = new System.Drawing.Point(582, 41);
            this.lbBaby.Name = "lbBaby";
            this.lbBaby.Size = new System.Drawing.Size(49, 17);
            this.lbBaby.TabIndex = 19;
            this.lbBaby.Text = "Em bé:";
            // 
            // lbChildren
            // 
            this.lbChildren.AutoSize = true;
            this.lbChildren.Location = new System.Drawing.Point(467, 40);
            this.lbChildren.Name = "lbChildren";
            this.lbChildren.Size = new System.Drawing.Size(53, 17);
            this.lbChildren.TabIndex = 1;
            this.lbChildren.Text = "Trẻ em:";
            // 
            // lbPeopleNumber
            // 
            this.lbPeopleNumber.AutoSize = true;
            this.lbPeopleNumber.Location = new System.Drawing.Point(336, 40);
            this.lbPeopleNumber.Name = "lbPeopleNumber";
            this.lbPeopleNumber.Size = new System.Drawing.Size(70, 17);
            this.lbPeopleNumber.TabIndex = 15;
            this.lbPeopleNumber.Text = "Người lớn:";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(689, 131);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(208, 25);
            this.dtEndDate.TabIndex = 9;
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "";
            this.dtStartDate.Location = new System.Drawing.Point(689, 89);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(208, 25);
            this.dtStartDate.TabIndex = 6;
            this.dtStartDate.Value = new System.DateTime(2018, 3, 5, 22, 7, 0, 0);
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // comboTicket
            // 
            this.comboTicket.FormattingEnabled = true;
            this.comboTicket.Items.AddRange(new object[] {
            "Một chiều",
            "Hai chiều"});
            this.comboTicket.Location = new System.Drawing.Point(410, 131);
            this.comboTicket.MaxLength = 50;
            this.comboTicket.Name = "comboTicket";
            this.comboTicket.Size = new System.Drawing.Size(140, 25);
            this.comboTicket.TabIndex = 8;
            // 
            // comboSeat
            // 
            this.comboSeat.FormattingEnabled = true;
            this.comboSeat.Items.AddRange(new object[] {
            "Economy",
            "Business",
            "First Class",
            "Premium Economy"});
            this.comboSeat.Location = new System.Drawing.Point(410, 89);
            this.comboSeat.MaxLength = 50;
            this.comboSeat.Name = "comboSeat";
            this.comboSeat.Size = new System.Drawing.Size(140, 25);
            this.comboSeat.TabIndex = 5;
            this.comboSeat.Text = "Economy";
            // 
            // comboDesPlace
            // 
            this.comboDesPlace.FormattingEnabled = true;
            this.comboDesPlace.Location = new System.Drawing.Point(90, 131);
            this.comboDesPlace.MaxLength = 80;
            this.comboDesPlace.Name = "comboDesPlace";
            this.comboDesPlace.Size = new System.Drawing.Size(217, 25);
            this.comboDesPlace.TabIndex = 7;
            this.comboDesPlace.Text = "Điểm đến";
            // 
            // comboSourcePlace
            // 
            this.comboSourcePlace.FormattingEnabled = true;
            this.comboSourcePlace.Location = new System.Drawing.Point(90, 89);
            this.comboSourcePlace.MaxLength = 80;
            this.comboSourcePlace.Name = "comboSourcePlace";
            this.comboSourcePlace.Size = new System.Drawing.Size(217, 25);
            this.comboSourcePlace.TabIndex = 4;
            this.comboSourcePlace.Text = "Điểm đi";
            // 
            // comboWebsiteSearch
            // 
            this.comboWebsiteSearch.FormattingEnabled = true;
            this.comboWebsiteSearch.Items.AddRange(new object[] {
            "traveloka",
            "Vietnam Airlines"});
            this.comboWebsiteSearch.Location = new System.Drawing.Point(90, 32);
            this.comboWebsiteSearch.Name = "comboWebsiteSearch";
            this.comboWebsiteSearch.Size = new System.Drawing.Size(217, 25);
            this.comboWebsiteSearch.TabIndex = 0;
            this.comboWebsiteSearch.Text = "Chọn web";
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Location = new System.Drawing.Point(600, 139);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(61, 17);
            this.lbEndDate.TabIndex = 7;
            this.lbEndDate.Text = "Ngày về:";
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Location = new System.Drawing.Point(600, 97);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(58, 17);
            this.lbStartDate.TabIndex = 6;
            this.lbStartDate.Text = "Ngày đi:";
            // 
            // lbTicket
            // 
            this.lbTicket.AutoSize = true;
            this.lbTicket.Location = new System.Drawing.Point(336, 139);
            this.lbTicket.Name = "lbTicket";
            this.lbTicket.Size = new System.Drawing.Size(55, 17);
            this.lbTicket.TabIndex = 5;
            this.lbTicket.Text = "Loại vé:";
            // 
            // lbSeat
            // 
            this.lbSeat.AutoSize = true;
            this.lbSeat.Location = new System.Drawing.Point(336, 97);
            this.lbSeat.Name = "lbSeat";
            this.lbSeat.Size = new System.Drawing.Size(68, 17);
            this.lbSeat.TabIndex = 4;
            this.lbSeat.Text = "Hạng ghế:";
            // 
            // lbDesPlace
            // 
            this.lbDesPlace.AutoSize = true;
            this.lbDesPlace.Location = new System.Drawing.Point(5, 139);
            this.lbDesPlace.Name = "lbDesPlace";
            this.lbDesPlace.Size = new System.Drawing.Size(69, 17);
            this.lbDesPlace.TabIndex = 3;
            this.lbDesPlace.Text = "Điểm đến:";
            // 
            // lbSourcePlace
            // 
            this.lbSourcePlace.AutoSize = true;
            this.lbSourcePlace.Location = new System.Drawing.Point(7, 97);
            this.lbSourcePlace.Name = "lbSourcePlace";
            this.lbSourcePlace.Size = new System.Drawing.Size(58, 17);
            this.lbSourcePlace.TabIndex = 2;
            this.lbSourcePlace.Text = "Điểm đi:";
            // 
            // lbWebsiteSearch
            // 
            this.lbWebsiteSearch.AutoSize = true;
            this.lbWebsiteSearch.Location = new System.Drawing.Point(7, 40);
            this.lbWebsiteSearch.Name = "lbWebsiteSearch";
            this.lbWebsiteSearch.Size = new System.Drawing.Size(58, 17);
            this.lbWebsiteSearch.TabIndex = 1;
            this.lbWebsiteSearch.Text = "Website:";
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnSetting.Location = new System.Drawing.Point(7, 25);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(59, 29);
            this.btnSetting.TabIndex = 20;
            this.btnSetting.Text = "@";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // groupTicketInfo
            // 
            this.groupTicketInfo.Controls.Add(this.lbScanTicketState);
            this.groupTicketInfo.Controls.Add(this.dataTicket);
            this.groupTicketInfo.Controls.Add(this.btnSetting);
            this.groupTicketInfo.Controls.Add(this.lbLoadingStatus);
            this.groupTicketInfo.Location = new System.Drawing.Point(5, 227);
            this.groupTicketInfo.Name = "groupTicketInfo";
            this.groupTicketInfo.Size = new System.Drawing.Size(912, 345);
            this.groupTicketInfo.TabIndex = 1;
            this.groupTicketInfo.TabStop = false;
            this.groupTicketInfo.Text = "Thông tin hiển thị";
            // 
            // lbScanTicketState
            // 
            this.lbScanTicketState.AutoSize = true;
            this.lbScanTicketState.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScanTicketState.Location = new System.Drawing.Point(72, 33);
            this.lbScanTicketState.Name = "lbScanTicketState";
            this.lbScanTicketState.Size = new System.Drawing.Size(123, 13);
            this.lbScanTicketState.TabIndex = 21;
            this.lbScanTicketState.Text = "Quét vé rẻ: Đang chạy";
            // 
            // dataTicket
            // 
            this.dataTicket.AllowUserToAddRows = false;
            this.dataTicket.AllowUserToDeleteRows = false;
            this.dataTicket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataTicket.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataTicket.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataTicket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNo,
            this.clSearchId,
            this.clAirPortKind,
            this.clSourcePlace,
            this.clDesPlace,
            this.clTicketPrice,
            this.clTripLink});
            this.dataTicket.Location = new System.Drawing.Point(6, 60);
            this.dataTicket.Name = "dataTicket";
            this.dataTicket.ReadOnly = true;
            this.dataTicket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTicket.Size = new System.Drawing.Size(900, 264);
            this.dataTicket.TabIndex = 11;
            // 
            // clNo
            // 
            this.clNo.HeaderText = "STT";
            this.clNo.Name = "clNo";
            this.clNo.ReadOnly = true;
            // 
            // clSearchId
            // 
            this.clSearchId.HeaderText = "Mã tìm kiếm";
            this.clSearchId.Name = "clSearchId";
            this.clSearchId.ReadOnly = true;
            // 
            // clAirPortKind
            // 
            this.clAirPortKind.HeaderText = "Hãng bay";
            this.clAirPortKind.Name = "clAirPortKind";
            this.clAirPortKind.ReadOnly = true;
            // 
            // clSourcePlace
            // 
            this.clSourcePlace.HeaderText = "Điểm khởi hành";
            this.clSourcePlace.Name = "clSourcePlace";
            this.clSourcePlace.ReadOnly = true;
            // 
            // clDesPlace
            // 
            this.clDesPlace.HeaderText = "Điểm đến";
            this.clDesPlace.Name = "clDesPlace";
            this.clDesPlace.ReadOnly = true;
            // 
            // clTicketPrice
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.clTicketPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.clTicketPrice.HeaderText = "Giá vé";
            this.clTicketPrice.Name = "clTicketPrice";
            this.clTicketPrice.ReadOnly = true;
            // 
            // clTripLink
            // 
            this.clTripLink.HeaderText = "Link Thanh toán";
            this.clTripLink.Name = "clTripLink";
            this.clTripLink.ReadOnly = true;
            // 
            // lbLoadingStatus
            // 
            this.lbLoadingStatus.AutoSize = true;
            this.lbLoadingStatus.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoadingStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbLoadingStatus.Location = new System.Drawing.Point(7, 327);
            this.lbLoadingStatus.Name = "lbLoadingStatus";
            this.lbLoadingStatus.Size = new System.Drawing.Size(66, 15);
            this.lbLoadingStatus.TabIndex = 0;
            this.lbLoadingStatus.Text = "Trạng thái:";
            // 
            // FormAirTicket
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 579);
            this.Controls.Add(this.groupTicketInfo);
            this.Controls.Add(this.groupSearch);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormAirTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tải thông tin vé máy bay online";
            this.Load += new System.EventHandler(this.FormAirTicket_Load);
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udBabyNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPeopleNumber)).EndInit();
            this.groupTicketInfo.ResumeLayout(false);
            this.groupTicketInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTicket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSearch;
        private System.Windows.Forms.GroupBox groupTicketInfo;
        private System.Windows.Forms.Label lbLoadingStatus;
        private System.Windows.Forms.Label lbTicket;
        private System.Windows.Forms.Label lbSeat;
        private System.Windows.Forms.Label lbDesPlace;
        private System.Windows.Forms.Label lbSourcePlace;
        private System.Windows.Forms.Label lbWebsiteSearch;
        private System.Windows.Forms.Label lbEndDate;
        private System.Windows.Forms.Label lbStartDate;
        private System.Windows.Forms.ComboBox comboWebsiteSearch;
        private System.Windows.Forms.ComboBox comboSourcePlace;
        private System.Windows.Forms.ComboBox comboDesPlace;
        private System.Windows.Forms.ComboBox comboSeat;
        private System.Windows.Forms.ComboBox comboTicket;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label lbPeopleNumber;
        private System.Windows.Forms.Label lbChildren;
        private System.Windows.Forms.Label lbBaby;
        private System.Windows.Forms.DataGridView dataTicket;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.NumericUpDown udBabyNumber;
        private System.Windows.Forms.NumericUpDown udChildren;
        private System.Windows.Forms.NumericUpDown udPeopleNumber;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Label lbScanTicketState;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSearchId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAirPortKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSourcePlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDesPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTicketPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTripLink;
    }
}