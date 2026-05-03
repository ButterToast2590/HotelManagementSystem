namespace HotelManagementSystem.MyControls
{
    partial class ucAdminRoomService
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUnderMaintenance = new System.Windows.Forms.Label();
            this.roomUnderMaintenance = new System.Windows.Forms.Label();
            this.guna2Panel7 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalRoomAvailable = new System.Windows.Forms.Label();
            this.todaysAvailable = new System.Windows.Forms.Label();
            this.guna2Panel8 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbltotalRoomOccupied = new System.Windows.Forms.Label();
            this.roomOccupied = new System.Windows.Forms.Label();
            this.guna2Panel9 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalRooms = new System.Windows.Forms.Label();
            this.totalRoom = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.createRoombtn = new Guna.UI2.WinForms.Guna2Button();
            this.colImgae = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemFood = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusOrder = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel7.SuspendLayout();
            this.guna2Panel8.SuspendLayout();
            this.guna2Panel9.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 854);
            this.panel1.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(12, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(359, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "All incoming food and amenity requests from guests.";
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
            this.guna2Panel4.Controls.Add(this.lblUnderMaintenance);
            this.guna2Panel4.Controls.Add(this.roomUnderMaintenance);
            this.guna2Panel4.FillColor = System.Drawing.Color.White;
            this.guna2Panel4.Location = new System.Drawing.Point(810, 3);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(263, 97);
            this.guna2Panel4.TabIndex = 30;
            // 
            // lblUnderMaintenance
            // 
            this.lblUnderMaintenance.AutoSize = true;
            this.lblUnderMaintenance.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnderMaintenance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUnderMaintenance.Location = new System.Drawing.Point(18, 48);
            this.lblUnderMaintenance.Name = "lblUnderMaintenance";
            this.lblUnderMaintenance.Size = new System.Drawing.Size(36, 32);
            this.lblUnderMaintenance.TabIndex = 1;
            this.lblUnderMaintenance.Text = "__";
            // 
            // roomUnderMaintenance
            // 
            this.roomUnderMaintenance.AutoSize = true;
            this.roomUnderMaintenance.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomUnderMaintenance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.roomUnderMaintenance.Location = new System.Drawing.Point(10, 18);
            this.roomUnderMaintenance.Name = "roomUnderMaintenance";
            this.roomUnderMaintenance.Size = new System.Drawing.Size(208, 30);
            this.roomUnderMaintenance.TabIndex = 0;
            this.roomUnderMaintenance.Text = "Overall Total Order";
            // 
            // guna2Panel7
            // 
            this.guna2Panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel7.BorderRadius = 15;
            this.guna2Panel7.Controls.Add(this.lblTotalRoomAvailable);
            this.guna2Panel7.Controls.Add(this.todaysAvailable);
            this.guna2Panel7.FillColor = System.Drawing.Color.White;
            this.guna2Panel7.Location = new System.Drawing.Point(541, 3);
            this.guna2Panel7.Name = "guna2Panel7";
            this.guna2Panel7.Size = new System.Drawing.Size(263, 97);
            this.guna2Panel7.TabIndex = 29;
            // 
            // lblTotalRoomAvailable
            // 
            this.lblTotalRoomAvailable.AutoSize = true;
            this.lblTotalRoomAvailable.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRoomAvailable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalRoomAvailable.Location = new System.Drawing.Point(18, 48);
            this.lblTotalRoomAvailable.Name = "lblTotalRoomAvailable";
            this.lblTotalRoomAvailable.Size = new System.Drawing.Size(36, 32);
            this.lblTotalRoomAvailable.TabIndex = 1;
            this.lblTotalRoomAvailable.Text = "__";
            // 
            // todaysAvailable
            // 
            this.todaysAvailable.AutoSize = true;
            this.todaysAvailable.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todaysAvailable.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.todaysAvailable.Location = new System.Drawing.Point(10, 18);
            this.todaysAvailable.Name = "todaysAvailable";
            this.todaysAvailable.Size = new System.Drawing.Size(109, 30);
            this.todaysAvailable.TabIndex = 0;
            this.todaysAvailable.Text = "Delivered";
            // 
            // guna2Panel8
            // 
            this.guna2Panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel8.BorderRadius = 15;
            this.guna2Panel8.Controls.Add(this.lbltotalRoomOccupied);
            this.guna2Panel8.Controls.Add(this.roomOccupied);
            this.guna2Panel8.FillColor = System.Drawing.Color.White;
            this.guna2Panel8.Location = new System.Drawing.Point(272, 3);
            this.guna2Panel8.Name = "guna2Panel8";
            this.guna2Panel8.Size = new System.Drawing.Size(263, 97);
            this.guna2Panel8.TabIndex = 28;
            // 
            // lbltotalRoomOccupied
            // 
            this.lbltotalRoomOccupied.AutoSize = true;
            this.lbltotalRoomOccupied.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalRoomOccupied.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbltotalRoomOccupied.Location = new System.Drawing.Point(18, 48);
            this.lbltotalRoomOccupied.Name = "lbltotalRoomOccupied";
            this.lbltotalRoomOccupied.Size = new System.Drawing.Size(36, 32);
            this.lbltotalRoomOccupied.TabIndex = 1;
            this.lbltotalRoomOccupied.Text = "__";
            // 
            // roomOccupied
            // 
            this.roomOccupied.AutoSize = true;
            this.roomOccupied.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomOccupied.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.roomOccupied.Location = new System.Drawing.Point(10, 18);
            this.roomOccupied.Name = "roomOccupied";
            this.roomOccupied.Size = new System.Drawing.Size(96, 30);
            this.roomOccupied.TabIndex = 0;
            this.roomOccupied.Text = "Pending";
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel9.BorderRadius = 15;
            this.guna2Panel9.Controls.Add(this.lblTotalRooms);
            this.guna2Panel9.Controls.Add(this.totalRoom);
            this.guna2Panel9.FillColor = System.Drawing.Color.White;
            this.guna2Panel9.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel9.Name = "guna2Panel9";
            this.guna2Panel9.Size = new System.Drawing.Size(263, 97);
            this.guna2Panel9.TabIndex = 27;
            // 
            // lblTotalRooms
            // 
            this.lblTotalRooms.AutoSize = true;
            this.lblTotalRooms.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRooms.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalRooms.Location = new System.Drawing.Point(18, 48);
            this.lblTotalRooms.Name = "lblTotalRooms";
            this.lblTotalRooms.Size = new System.Drawing.Size(36, 32);
            this.lblTotalRooms.TabIndex = 1;
            this.lblTotalRooms.Text = "__";
            // 
            // totalRoom
            // 
            this.totalRoom.AutoSize = true;
            this.totalRoom.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRoom.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.totalRoom.Location = new System.Drawing.Point(10, 18);
            this.totalRoom.Name = "totalRoom";
            this.totalRoom.Size = new System.Drawing.Size(132, 30);
            this.totalRoom.TabIndex = 0;
            this.totalRoom.Text = "Total Today";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(8, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(335, 45);
            this.label21.TabIndex = 27;
            this.label21.Text = "Room Service Orders";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.0223F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.9777F));
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 188);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1076, 654);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.guna2ComboBox1);
            this.guna2Panel1.Controls.Add(this.dataGridView1);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(543, 648);
            this.guna2Panel1.TabIndex = 29;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderNum,
            this.colRoom,
            this.colItemFood,
            this.colAmount,
            this.colStatusOrder});
            this.dataGridView1.Location = new System.Drawing.Point(9, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(525, 574);
            this.dataGridView1.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 28);
            this.label1.TabIndex = 33;
            this.label1.Text = "Order Queue";
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderColor = System.Drawing.Color.Black;
            this.guna2ComboBox1.BorderRadius = 10;
            this.guna2ComboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FillColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.guna2ComboBox1.ItemHeight = 35;
            this.guna2ComboBox1.Items.AddRange(new object[] {
            "Filter By Status",
            "Pending",
            "Confirmed",
            "Cancelled"});
            this.guna2ComboBox1.Location = new System.Drawing.Point(148, 11);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(289, 41);
            this.guna2ComboBox1.StartIndex = 0;
            this.guna2ComboBox1.TabIndex = 38;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 15;
            this.guna2Panel2.Controls.Add(this.createRoombtn);
            this.guna2Panel2.Controls.Add(this.dataGridView2);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(552, 3);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(521, 648);
            this.guna2Panel2.TabIndex = 30;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImgae,
            this.ColName,
            this.colDesc,
            this.colPrice});
            this.dataGridView2.Location = new System.Drawing.Point(6, 58);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(508, 574);
            this.dataGridView2.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(19, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 28);
            this.label2.TabIndex = 34;
            this.label2.Text = "Available Menu";
            // 
            // createRoombtn
            // 
            this.createRoombtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createRoombtn.BorderRadius = 10;
            this.createRoombtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.createRoombtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.createRoombtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.createRoombtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.createRoombtn.FillColor = System.Drawing.SystemColors.HotTrack;
            this.createRoombtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createRoombtn.ForeColor = System.Drawing.Color.White;
            this.createRoombtn.Location = new System.Drawing.Point(394, 11);
            this.createRoombtn.Name = "createRoombtn";
            this.createRoombtn.Size = new System.Drawing.Size(118, 41);
            this.createRoombtn.TabIndex = 78;
            this.createRoombtn.Text = "Add Menu";
            this.createRoombtn.Click += new System.EventHandler(this.createRoombtn_Click);
            // 
            // colImgae
            // 
            this.colImgae.HeaderText = "Image";
            this.colImgae.Name = "colImgae";
            this.colImgae.ReadOnly = true;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColName.HeaderText = "Food Name";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // colDesc
            // 
            this.colDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDesc.HeaderText = "Description";
            this.colDesc.Name = "colDesc";
            this.colDesc.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colOrderNum
            // 
            this.colOrderNum.HeaderText = "Order Number";
            this.colOrderNum.Name = "colOrderNum";
            this.colOrderNum.ReadOnly = true;
            // 
            // colRoom
            // 
            this.colRoom.HeaderText = "Room";
            this.colRoom.Name = "colRoom";
            this.colRoom.ReadOnly = true;
            this.colRoom.Width = 80;
            // 
            // colItemFood
            // 
            this.colItemFood.HeaderText = "Food";
            this.colItemFood.Name = "colItemFood";
            this.colItemFood.ReadOnly = true;
            this.colItemFood.Width = 117;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 80;
            // 
            // colStatusOrder
            // 
            this.colStatusOrder.HeaderText = "Status";
            this.colStatusOrder.Items.AddRange(new object[] {
            "Pending",
            "Delivered"});
            this.colStatusOrder.Name = "colStatusOrder";
            this.colStatusOrder.ReadOnly = true;
            this.colStatusOrder.Width = 105;
            // 
            // ucAdminRoomService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucAdminRoomService";
            this.Size = new System.Drawing.Size(1110, 854);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            this.guna2Panel7.ResumeLayout(false);
            this.guna2Panel7.PerformLayout();
            this.guna2Panel8.ResumeLayout(false);
            this.guna2Panel8.PerformLayout();
            this.guna2Panel9.ResumeLayout(false);
            this.guna2Panel9.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label lblUnderMaintenance;
        private System.Windows.Forms.Label roomUnderMaintenance;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel7;
        private System.Windows.Forms.Label lblTotalRoomAvailable;
        private System.Windows.Forms.Label todaysAvailable;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel8;
        private System.Windows.Forms.Label lbltotalRoomOccupied;
        private System.Windows.Forms.Label roomOccupied;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private System.Windows.Forms.Label lblTotalRooms;
        private System.Windows.Forms.Label totalRoom;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button createRoombtn;
        private System.Windows.Forms.DataGridViewImageColumn colImgae;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemFood;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewComboBoxColumn colStatusOrder;
    }
}
