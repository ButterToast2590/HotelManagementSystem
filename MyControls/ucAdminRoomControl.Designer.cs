namespace HotelManagementSystem.MyControls
{
    partial class ucAdminRoomControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDeleteHigh = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditHigh = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteRoom = new Guna.UI2.WinForms.Guna2Button();
            this.createRoombtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.colRoomId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colfloorNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoomNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPricePerNight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxOccupancy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSmokingPolicy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoomImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoomDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
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
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel7.SuspendLayout();
            this.guna2Panel8.SuspendLayout();
            this.guna2Panel9.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1110, 754);
            this.panel1.TabIndex = 34;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 174);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1076, 580);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.AutoSize = true;
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.Controls.Add(this.btnDeleteHigh);
            this.guna2Panel1.Controls.Add(this.btnEditHigh);
            this.guna2Panel1.Controls.Add(this.btnAdd);
            this.guna2Panel1.Controls.Add(this.btnEdit);
            this.guna2Panel1.Controls.Add(this.btnDeleteRoom);
            this.guna2Panel1.Controls.Add(this.createRoombtn);
            this.guna2Panel1.Controls.Add(this.guna2ComboBox1);
            this.guna2Panel1.Controls.Add(this.dataGridView2);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1070, 574);
            this.guna2Panel1.TabIndex = 32;
            // 
            // btnDeleteHigh
            // 
            this.btnDeleteHigh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteHigh.BorderRadius = 10;
            this.btnDeleteHigh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteHigh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteHigh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteHigh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteHigh.FillColor = System.Drawing.Color.IndianRed;
            this.btnDeleteHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteHigh.ForeColor = System.Drawing.Color.White;
            this.btnDeleteHigh.Location = new System.Drawing.Point(944, 10);
            this.btnDeleteHigh.Name = "btnDeleteHigh";
            this.btnDeleteHigh.Size = new System.Drawing.Size(110, 41);
            this.btnDeleteHigh.TabIndex = 107;
            this.btnDeleteHigh.Text = "Delete";
            this.btnDeleteHigh.Click += new System.EventHandler(this.btnDeleteHigh_Click);
            // 
            // btnEditHigh
            // 
            this.btnEditHigh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditHigh.BorderRadius = 10;
            this.btnEditHigh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditHigh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditHigh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditHigh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditHigh.FillColor = System.Drawing.Color.DarkGreen;
            this.btnEditHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditHigh.ForeColor = System.Drawing.Color.White;
            this.btnEditHigh.Location = new System.Drawing.Point(822, 10);
            this.btnEditHigh.Name = "btnEditHigh";
            this.btnEditHigh.Size = new System.Drawing.Size(110, 41);
            this.btnEditHigh.TabIndex = 106;
            this.btnEditHigh.Text = "Edit";
            this.btnEditHigh.Click += new System.EventHandler(this.btnEditHigh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BorderRadius = 10;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.SystemColors.HotTrack;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(700, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 41);
            this.btnAdd.TabIndex = 105;
            this.btnAdd.Text = "Add ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BorderRadius = 10;
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.FillColor = System.Drawing.Color.DarkGreen;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(788, -71);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(130, 41);
            this.btnEdit.TabIndex = 104;
            this.btnEdit.Text = "Edit Room";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRoom.BorderRadius = 10;
            this.btnDeleteRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteRoom.FillColor = System.Drawing.Color.IndianRed;
            this.btnDeleteRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRoom.ForeColor = System.Drawing.Color.White;
            this.btnDeleteRoom.Location = new System.Drawing.Point(924, -71);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(130, 41);
            this.btnDeleteRoom.TabIndex = 78;
            this.btnDeleteRoom.Text = "Delete";
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);
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
            this.createRoombtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createRoombtn.ForeColor = System.Drawing.Color.White;
            this.createRoombtn.Location = new System.Drawing.Point(652, -71);
            this.createRoombtn.Name = "createRoombtn";
            this.createRoombtn.Size = new System.Drawing.Size(130, 41);
            this.createRoombtn.TabIndex = 77;
            this.createRoombtn.Text = "Add Room";
            this.createRoombtn.Click += new System.EventHandler(this.createRoombtn_Click);
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
            "Select Room Type",
            "View All Room",
            "Single",
            "Double",
            "Twin",
            "Triple",
            "Suite",
            "Deluxe",
            "Executive"});
            this.guna2ComboBox1.Location = new System.Drawing.Point(165, 10);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(289, 41);
            this.guna2ComboBox1.StartIndex = 0;
            this.guna2ComboBox1.TabIndex = 3;
            this.guna2ComboBox1.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRoomId,
            this.colfloorNum,
            this.colRoomNum,
            this.colRoomType,
            this.colPricePerNight,
            this.colMaxOccupancy,
            this.colSmokingPolicy,
            this.colRoomImage,
            this.colRoomDesc,
            this.colStatus});
            this.dataGridView2.Location = new System.Drawing.Point(15, 63);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.Size = new System.Drawing.Size(1039, 501);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            // 
            // colRoomId
            // 
            this.colRoomId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRoomId.HeaderText = "Room ID";
            this.colRoomId.Name = "colRoomId";
            this.colRoomId.ReadOnly = true;
            // 
            // colfloorNum
            // 
            this.colfloorNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colfloorNum.HeaderText = "Floor Number";
            this.colfloorNum.Name = "colfloorNum";
            // 
            // colRoomNum
            // 
            this.colRoomNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRoomNum.HeaderText = "Room Number";
            this.colRoomNum.Name = "colRoomNum";
            // 
            // colRoomType
            // 
            this.colRoomType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRoomType.HeaderText = "Room Type";
            this.colRoomType.Name = "colRoomType";
            // 
            // colPricePerNight
            // 
            this.colPricePerNight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPricePerNight.HeaderText = "Price Per Night";
            this.colPricePerNight.Name = "colPricePerNight";
            // 
            // colMaxOccupancy
            // 
            this.colMaxOccupancy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMaxOccupancy.HeaderText = "Max Occupancy";
            this.colMaxOccupancy.Name = "colMaxOccupancy";
            // 
            // colSmokingPolicy
            // 
            this.colSmokingPolicy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSmokingPolicy.HeaderText = "Smoking Policy";
            this.colSmokingPolicy.Name = "colSmokingPolicy";
            // 
            // colRoomImage
            // 
            this.colRoomImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRoomImage.HeaderText = "Room Image";
            this.colRoomImage.Name = "colRoomImage";
            this.colRoomImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRoomImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colRoomDesc
            // 
            this.colRoomDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRoomDesc.HeaderText = "Description";
            this.colRoomDesc.Name = "colRoomDesc";
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(10, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Room Details";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(12, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(293, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Room Status, Availabilty, and Create Room";
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(16, 68);
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
            this.roomUnderMaintenance.Size = new System.Drawing.Size(145, 30);
            this.roomUnderMaintenance.TabIndex = 0;
            this.roomUnderMaintenance.Text = "Maintenance";
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
            this.todaysAvailable.Size = new System.Drawing.Size(106, 30);
            this.todaysAvailable.TabIndex = 0;
            this.todaysAvailable.Text = "Available";
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
            this.roomOccupied.Size = new System.Drawing.Size(175, 30);
            this.roomOccupied.TabIndex = 0;
            this.roomOccupied.Text = "Room Occupied";
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
            this.lblTotalRooms.Click += new System.EventHandler(this.lblTotalRooms_Click);
            // 
            // totalRoom
            // 
            this.totalRoom.AutoSize = true;
            this.totalRoom.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRoom.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.totalRoom.Location = new System.Drawing.Point(10, 18);
            this.totalRoom.Name = "totalRoom";
            this.totalRoom.Size = new System.Drawing.Size(140, 30);
            this.totalRoom.TabIndex = 0;
            this.totalRoom.Text = "Total Rooms";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(8, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(123, 45);
            this.label21.TabIndex = 27;
            this.label21.Text = "Rooms";
            // 
            // ucAdminRoomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucAdminRoomControl";
            this.Size = new System.Drawing.Size(1110, 754);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button createRoombtn;
        private Guna.UI2.WinForms.Guna2Button btnDeleteRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoomId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colfloorNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoomNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPricePerNight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxOccupancy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSmokingPolicy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoomImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoomDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDeleteHigh;
        private Guna.UI2.WinForms.Guna2Button btnEditHigh;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
    }
}
