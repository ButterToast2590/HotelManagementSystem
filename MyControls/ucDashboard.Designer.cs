namespace HotelManagementSystem.MyControl
{
    public partial class ucDashboard : System.Windows.Forms.UserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel11 = new Guna.UI2.WinForms.Guna2Panel();
            this.rsGrid = new System.Windows.Forms.DataGridView();
            this.label22 = new System.Windows.Forms.Label();
            this.guna2Panel10 = new Guna.UI2.WinForms.Guna2Panel();
            this.rrGrid = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label23 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCurrentBill = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.guna2Panel7 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRoomNum = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.guna2Panel8 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.guna2Panel9 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.colRsDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRSFloor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRSRoomNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRSStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRSBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.guna2Panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rsGrid)).BeginInit();
            this.guna2Panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rrGrid)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel7.SuspendLayout();
            this.guna2Panel8.SuspendLayout();
            this.guna2Panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(140, -54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Here is a summary of your current stay.";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblTitle.Location = new System.Drawing.Point(136, -110);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(184, 45);
            this.lblTitle.TabIndex = 23;
            this.lblTitle.Text = "Dashboard";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 854);
            this.panel1.TabIndex = 33;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.guna2Panel11, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.guna2Panel10, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(16, 188);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1076, 660);
            this.tableLayoutPanel3.TabIndex = 32;
            // 
            // guna2Panel11
            // 
            this.guna2Panel11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel11.AutoSize = true;
            this.guna2Panel11.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel11.BorderRadius = 15;
            this.guna2Panel11.Controls.Add(this.rsGrid);
            this.guna2Panel11.Controls.Add(this.label22);
            this.guna2Panel11.FillColor = System.Drawing.Color.White;
            this.guna2Panel11.Location = new System.Drawing.Point(3, 333);
            this.guna2Panel11.Name = "guna2Panel11";
            this.guna2Panel11.Size = new System.Drawing.Size(1070, 324);
            this.guna2Panel11.TabIndex = 32;
            // 
            // rsGrid
            // 
            this.rsGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.rsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRsDate,
            this.colRSFloor,
            this.colRSRoomNum,
            this.colRSStatus,
            this.colRSBill});
            this.rsGrid.Location = new System.Drawing.Point(15, 50);
            this.rsGrid.Name = "rsGrid";
            this.rsGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rsGrid.Size = new System.Drawing.Size(1045, 264);
            this.rsGrid.TabIndex = 2;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label22.Location = new System.Drawing.Point(10, 12);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(241, 30);
            this.label22.TabIndex = 0;
            this.label22.Text = "Room Service  Activity";
            // 
            // guna2Panel10
            // 
            this.guna2Panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel10.AutoSize = true;
            this.guna2Panel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel10.BorderRadius = 15;
            this.guna2Panel10.Controls.Add(this.rrGrid);
            this.guna2Panel10.Controls.Add(this.label23);
            this.guna2Panel10.FillColor = System.Drawing.Color.White;
            this.guna2Panel10.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel10.Name = "guna2Panel10";
            this.guna2Panel10.Size = new System.Drawing.Size(1070, 324);
            this.guna2Panel10.TabIndex = 31;
            // 
            // rrGrid
            // 
            this.rrGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rrGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.rrGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rrGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colRoom,
            this.colCheckIn,
            this.colCheckOut,
            this.colStatus,
            this.colBill});
            this.rrGrid.Location = new System.Drawing.Point(15, 50);
            this.rrGrid.Name = "rrGrid";
            this.rrGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rrGrid.Size = new System.Drawing.Size(1045, 264);
            this.rrGrid.TabIndex = 2;
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
            this.colRoom.HeaderText = "Room";
            this.colRoom.Name = "colRoom";
            this.colRoom.ReadOnly = true;
            this.colRoom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colRoom.Width = 140;
            // 
            // colCheckIn
            // 
            this.colCheckIn.HeaderText = "Check-In";
            this.colCheckIn.Name = "colCheckIn";
            this.colCheckIn.ReadOnly = true;
            this.colCheckIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCheckIn.Width = 140;
            // 
            // colCheckOut
            // 
            this.colCheckOut.HeaderText = "Check-Out";
            this.colCheckOut.Name = "colCheckOut";
            this.colCheckOut.ReadOnly = true;
            this.colCheckOut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCheckOut.Width = 140;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStatus.Width = 140;
            // 
            // colBill
            // 
            this.colBill.HeaderText = "Bill";
            this.colBill.Name = "colBill";
            this.colBill.ReadOnly = true;
            this.colBill.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colBill.Width = 140;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label23.Location = new System.Drawing.Point(10, 12);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(232, 30);
            this.label23.TabIndex = 0;
            this.label23.Text = "Recent Room Activity";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(12, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(265, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Here is a summary of your current stay.";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.guna2Panel4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.guna2Panel7, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.guna2Panel8, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.guna2Panel9, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(16, 79);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1076, 103);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BorderRadius = 15;
            this.guna2Panel4.Controls.Add(this.lblCurrentBill);
            this.guna2Panel4.Controls.Add(this.label14);
            this.guna2Panel4.FillColor = System.Drawing.Color.White;
            this.guna2Panel4.Location = new System.Drawing.Point(810, 3);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(263, 97);
            this.guna2Panel4.TabIndex = 30;
            // 
            // lblCurrentBill
            // 
            this.lblCurrentBill.AutoSize = true;
            this.lblCurrentBill.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBill.ForeColor = System.Drawing.Color.DimGray;
            this.lblCurrentBill.Location = new System.Drawing.Point(12, 48);
            this.lblCurrentBill.Name = "lblCurrentBill";
            this.lblCurrentBill.Size = new System.Drawing.Size(30, 25);
            this.lblCurrentBill.TabIndex = 1;
            this.lblCurrentBill.Text = "__";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(10, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 30);
            this.label14.TabIndex = 0;
            this.label14.Text = "Current Bill";
            // 
            // guna2Panel7
            // 
            this.guna2Panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel7.BorderRadius = 15;
            this.guna2Panel7.Controls.Add(this.lblRoomNum);
            this.guna2Panel7.Controls.Add(this.label16);
            this.guna2Panel7.FillColor = System.Drawing.Color.White;
            this.guna2Panel7.Location = new System.Drawing.Point(541, 3);
            this.guna2Panel7.Name = "guna2Panel7";
            this.guna2Panel7.Size = new System.Drawing.Size(263, 97);
            this.guna2Panel7.TabIndex = 29;
            // 
            // lblRoomNum
            // 
            this.lblRoomNum.AutoSize = true;
            this.lblRoomNum.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNum.ForeColor = System.Drawing.Color.DimGray;
            this.lblRoomNum.Location = new System.Drawing.Point(12, 48);
            this.lblRoomNum.Name = "lblRoomNum";
            this.lblRoomNum.Size = new System.Drawing.Size(30, 25);
            this.lblRoomNum.TabIndex = 1;
            this.lblRoomNum.Text = "__";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(10, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(161, 30);
            this.label16.TabIndex = 0;
            this.label16.Text = "Room Number";
            // 
            // guna2Panel8
            // 
            this.guna2Panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel8.BorderRadius = 15;
            this.guna2Panel8.Controls.Add(this.lblCheckOut);
            this.guna2Panel8.Controls.Add(this.label18);
            this.guna2Panel8.FillColor = System.Drawing.Color.White;
            this.guna2Panel8.Location = new System.Drawing.Point(272, 3);
            this.guna2Panel8.Name = "guna2Panel8";
            this.guna2Panel8.Size = new System.Drawing.Size(263, 97);
            this.guna2Panel8.TabIndex = 28;
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOut.ForeColor = System.Drawing.Color.DimGray;
            this.lblCheckOut.Location = new System.Drawing.Point(12, 48);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(30, 25);
            this.lblCheckOut.TabIndex = 1;
            this.lblCheckOut.Text = "__";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label18.Location = new System.Drawing.Point(10, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(176, 30);
            this.label18.TabIndex = 0;
            this.label18.Text = "Check-Out Date";
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel9.BorderRadius = 15;
            this.guna2Panel9.Controls.Add(this.lblCheckIn);
            this.guna2Panel9.Controls.Add(this.label20);
            this.guna2Panel9.FillColor = System.Drawing.Color.White;
            this.guna2Panel9.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel9.Name = "guna2Panel9";
            this.guna2Panel9.Size = new System.Drawing.Size(263, 97);
            this.guna2Panel9.TabIndex = 27;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckIn.ForeColor = System.Drawing.Color.DimGray;
            this.lblCheckIn.Location = new System.Drawing.Point(12, 48);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(30, 25);
            this.lblCheckIn.TabIndex = 1;
            this.lblCheckIn.Text = "__";
            this.lblCheckIn.Click += new System.EventHandler(this.lblCheckIn_Click_1);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label20.Location = new System.Drawing.Point(10, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(158, 30);
            this.label20.TabIndex = 0;
            this.label20.Text = "Check-In Date";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(8, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(184, 45);
            this.label21.TabIndex = 27;
            this.label21.Text = "Dashboard";
            // 
            // colRsDate
            // 
            this.colRsDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRsDate.HeaderText = "Date Ordered";
            this.colRsDate.Name = "colRsDate";
            this.colRsDate.ReadOnly = true;
            // 
            // colRSFloor
            // 
            this.colRSFloor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRSFloor.HeaderText = "Floor";
            this.colRSFloor.Name = "colRSFloor";
            this.colRSFloor.ReadOnly = true;
            // 
            // colRSRoomNum
            // 
            this.colRSRoomNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRSRoomNum.HeaderText = "Room";
            this.colRSRoomNum.Name = "colRSRoomNum";
            this.colRSRoomNum.ReadOnly = true;
            this.colRSRoomNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colRSStatus
            // 
            this.colRSStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRSStatus.HeaderText = "Status";
            this.colRSStatus.Name = "colRSStatus";
            this.colRSStatus.ReadOnly = true;
            this.colRSStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colRSBill
            // 
            this.colRSBill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRSBill.HeaderText = "Bill";
            this.colRSBill.Name = "colRSBill";
            this.colRSBill.ReadOnly = true;
            this.colRSBill.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ucDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucDashboard";
            this.Size = new System.Drawing.Size(1110, 854);
            this.Load += new System.EventHandler(this.ucDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.guna2Panel11.ResumeLayout(false);
            this.guna2Panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rsGrid)).EndInit();
            this.guna2Panel10.ResumeLayout(false);
            this.guna2Panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rrGrid)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            this.guna2Panel7.ResumeLayout(false);
            this.guna2Panel7.PerformLayout();
            this.guna2Panel8.ResumeLayout(false);
            this.guna2Panel8.PerformLayout();
            this.guna2Panel9.ResumeLayout(false);
            this.guna2Panel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel11;
        private System.Windows.Forms.DataGridView rsGrid;
        private System.Windows.Forms.Label label22;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel10;
        private System.Windows.Forms.DataGridView rrGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBill;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label lblCurrentBill;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel7;
        private System.Windows.Forms.Label lblRoomNum;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel8;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.Label label18;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRsDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRSFloor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRSRoomNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRSStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRSBill;
    }
}
