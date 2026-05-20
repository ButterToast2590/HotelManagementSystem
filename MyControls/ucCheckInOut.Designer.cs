namespace HotelManagementSystem
{
    partial class ucCheckInOut : System.Windows.Forms.UserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.chechINOutGrid = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnEarlyOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnExtendStay = new Guna.UI2.WinForms.Guna2Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCheckoutSched = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel9 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAssignedRoom = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMaxOccupancy = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCheckInSched = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bookingStatsContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChangeBookingStats = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chechINOutGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel9.SuspendLayout();
            this.bookingStatsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 756);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.guna2Panel1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 345);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 506F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1072, 408);
            this.tableLayoutPanel2.TabIndex = 34;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.Controls.Add(this.chechINOutGrid);
            this.guna2Panel1.Controls.Add(this.label16);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1066, 402);
            this.guna2Panel1.TabIndex = 0;
            // 
            // chechINOutGrid
            // 
            this.chechINOutGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.chechINOutGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.chechINOutGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chechINOutGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colRoom,
            this.colCheckIn,
            this.colCheckOut,
            this.colStatus,
            this.colBill});
            this.chechINOutGrid.Location = new System.Drawing.Point(19, 46);
            this.chechINOutGrid.Name = "chechINOutGrid";
            this.chechINOutGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chechINOutGrid.Size = new System.Drawing.Size(1031, 341);
            this.chechINOutGrid.TabIndex = 33;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colName.Width = 300;
            // 
            // colRoom
            // 
            this.colRoom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRoom.HeaderText = "Room";
            this.colRoom.Name = "colRoom";
            this.colRoom.ReadOnly = true;
            this.colRoom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colCheckIn
            // 
            this.colCheckIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCheckIn.HeaderText = "Check-In";
            this.colCheckIn.Name = "colCheckIn";
            this.colCheckIn.ReadOnly = true;
            this.colCheckIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colCheckOut
            // 
            this.colCheckOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCheckOut.HeaderText = "Check-Out";
            this.colCheckOut.Name = "colCheckOut";
            this.colCheckOut.ReadOnly = true;
            this.colCheckOut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colBill
            // 
            this.colBill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBill.HeaderText = "Bill";
            this.colBill.Name = "colBill";
            this.colBill.ReadOnly = true;
            this.colBill.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(14, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(225, 28);
            this.label16.TabIndex = 32;
            this.label16.Text = "Check-In / Out History";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel9, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 66);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1072, 276);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 15;
            this.guna2Panel2.Controls.Add(this.btnEarlyOut);
            this.guna2Panel2.Controls.Add(this.btnExtendStay);
            this.guna2Panel2.Controls.Add(this.lblTime);
            this.guna2Panel2.Controls.Add(this.label15);
            this.guna2Panel2.Controls.Add(this.lblCheckoutSched);
            this.guna2Panel2.Controls.Add(this.label10);
            this.guna2Panel2.Controls.Add(this.label11);
            this.guna2Panel2.Controls.Add(this.label13);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(539, 3);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(530, 270);
            this.guna2Panel2.TabIndex = 29;
            // 
            // btnEarlyOut
            // 
            this.btnEarlyOut.BorderColor = System.Drawing.Color.DimGray;
            this.btnEarlyOut.BorderRadius = 15;
            this.btnEarlyOut.BorderThickness = 1;
            this.btnEarlyOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEarlyOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEarlyOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEarlyOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEarlyOut.FillColor = System.Drawing.Color.Transparent;
            this.btnEarlyOut.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEarlyOut.ForeColor = System.Drawing.Color.Black;
            this.btnEarlyOut.Location = new System.Drawing.Point(274, 188);
            this.btnEarlyOut.Name = "btnEarlyOut";
            this.btnEarlyOut.PressedColor = System.Drawing.Color.IndianRed;
            this.btnEarlyOut.PressedDepth = 70;
            this.btnEarlyOut.Size = new System.Drawing.Size(193, 45);
            this.btnEarlyOut.TabIndex = 66;
            this.btnEarlyOut.Text = "Early Check-Out";
            this.btnEarlyOut.Click += new System.EventHandler(this.btnEarlyOut_Click_1);
            // 
            // btnExtendStay
            // 
            this.btnExtendStay.BorderColor = System.Drawing.Color.DimGray;
            this.btnExtendStay.BorderRadius = 15;
            this.btnExtendStay.BorderThickness = 1;
            this.btnExtendStay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExtendStay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExtendStay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExtendStay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExtendStay.FillColor = System.Drawing.Color.Transparent;
            this.btnExtendStay.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtendStay.ForeColor = System.Drawing.Color.Black;
            this.btnExtendStay.Location = new System.Drawing.Point(29, 188);
            this.btnExtendStay.Name = "btnExtendStay";
            this.btnExtendStay.PressedColor = System.Drawing.Color.SeaGreen;
            this.btnExtendStay.PressedDepth = 70;
            this.btnExtendStay.Size = new System.Drawing.Size(193, 45);
            this.btnExtendStay.TabIndex = 66;
            this.btnExtendStay.Text = "Extend Stay";
            this.btnExtendStay.Click += new System.EventHandler(this.btnExtendStay_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblTime.Location = new System.Drawing.Point(24, 127);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(139, 25);
            this.lblTime.TabIndex = 65;
            this.lblTime.Text = "3 days, 14 hrs";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(25, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 20);
            this.label15.TabIndex = 64;
            this.label15.Text = "Time Remaining";
            // 
            // lblCheckoutSched
            // 
            this.lblCheckoutSched.AutoSize = true;
            this.lblCheckoutSched.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckoutSched.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblCheckoutSched.Location = new System.Drawing.Point(24, 72);
            this.lblCheckoutSched.Name = "lblCheckoutSched";
            this.lblCheckoutSched.Size = new System.Drawing.Size(245, 25);
            this.lblCheckoutSched.TabIndex = 63;
            this.lblCheckoutSched.Text = "Apr 18, 2026 — 12:00 PM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(25, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 62;
            this.label10.Text = "Scheduled";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(270, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 18);
            this.label11.TabIndex = 58;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(25, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 18);
            this.label13.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(24, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Upcoming Check-Out";
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel9.BorderRadius = 10;
            this.guna2Panel9.Controls.Add(this.lblAssignedRoom);
            this.guna2Panel9.Controls.Add(this.label8);
            this.guna2Panel9.Controls.Add(this.lblMaxOccupancy);
            this.guna2Panel9.Controls.Add(this.label6);
            this.guna2Panel9.Controls.Add(this.lblCheckInSched);
            this.guna2Panel9.Controls.Add(this.label3);
            this.guna2Panel9.Controls.Add(this.bookingStatsContainer);
            this.guna2Panel9.Controls.Add(this.label1);
            this.guna2Panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel9.FillColor = System.Drawing.Color.White;
            this.guna2Panel9.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel9.Name = "guna2Panel9";
            this.guna2Panel9.Size = new System.Drawing.Size(530, 270);
            this.guna2Panel9.TabIndex = 28;
            // 
            // lblAssignedRoom
            // 
            this.lblAssignedRoom.AutoSize = true;
            this.lblAssignedRoom.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignedRoom.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblAssignedRoom.Location = new System.Drawing.Point(22, 172);
            this.lblAssignedRoom.Name = "lblAssignedRoom";
            this.lblAssignedRoom.Size = new System.Drawing.Size(180, 25);
            this.lblAssignedRoom.TabIndex = 65;
            this.lblAssignedRoom.Text = "Room 412, Floor 4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(23, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 20);
            this.label8.TabIndex = 64;
            this.label8.Text = "Assigned Room";
            // 
            // lblMaxOccupancy
            // 
            this.lblMaxOccupancy.AutoSize = true;
            this.lblMaxOccupancy.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxOccupancy.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblMaxOccupancy.Location = new System.Drawing.Point(22, 226);
            this.lblMaxOccupancy.Name = "lblMaxOccupancy";
            this.lblMaxOccupancy.Size = new System.Drawing.Size(23, 25);
            this.lblMaxOccupancy.TabIndex = 63;
            this.lblMaxOccupancy.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(23, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 62;
            this.label6.Text = "Max Occupancy";
            // 
            // lblCheckInSched
            // 
            this.lblCheckInSched.AutoSize = true;
            this.lblCheckInSched.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckInSched.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblCheckInSched.Location = new System.Drawing.Point(22, 117);
            this.lblCheckInSched.Name = "lblCheckInSched";
            this.lblCheckInSched.Size = new System.Drawing.Size(235, 25);
            this.lblCheckInSched.TabIndex = 61;
            this.lblCheckInSched.Text = "Apr 14, 2026 — 8:10 AM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(23, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 59;
            this.label3.Text = "Scheduled";
            // 
            // bookingStatsContainer
            // 
            this.bookingStatsContainer.BackColor = System.Drawing.Color.Transparent;
            this.bookingStatsContainer.BorderRadius = 10;
            this.bookingStatsContainer.Controls.Add(this.lblChangeBookingStats);
            this.bookingStatsContainer.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.bookingStatsContainer.Location = new System.Drawing.Point(22, 51);
            this.bookingStatsContainer.Name = "bookingStatsContainer";
            this.bookingStatsContainer.Size = new System.Drawing.Size(146, 33);
            this.bookingStatsContainer.TabIndex = 60;
            // 
            // lblChangeBookingStats
            // 
            this.lblChangeBookingStats.AutoSize = true;
            this.lblChangeBookingStats.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeBookingStats.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblChangeBookingStats.Location = new System.Drawing.Point(4, 6);
            this.lblChangeBookingStats.Name = "lblChangeBookingStats";
            this.lblChangeBookingStats.Size = new System.Drawing.Size(96, 21);
            this.lblChangeBookingStats.TabIndex = 61;
            this.lblChangeBookingStats.Text = "Checked In";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 30);
            this.label1.TabIndex = 59;
            this.label1.Text = "Check-In Status";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(16, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(331, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "Guest status and room assignment management.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(12, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(236, 45);
            this.label21.TabIndex = 31;
            this.label21.Text = "Check-In / Out";
            // 
            // ucCheckInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1110, 854);
            this.Name = "ucCheckInOut";
            this.Size = new System.Drawing.Size(1110, 756);
            this.Load += new System.EventHandler(this.ucCheckInOut_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chechINOutGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel9.ResumeLayout(false);
            this.guna2Panel9.PerformLayout();
            this.bookingStatsContainer.ResumeLayout(false);
            this.bookingStatsContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel bookingStatsContainer;
        private System.Windows.Forms.Label lblChangeBookingStats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAssignedRoom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMaxOccupancy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCheckInSched;
        private Guna.UI2.WinForms.Guna2Button btnExtendStay;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCheckoutSched;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2Button btnEarlyOut;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView chechINOutGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBill;
    }
}
