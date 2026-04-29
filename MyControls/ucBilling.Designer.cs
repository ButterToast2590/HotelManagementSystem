namespace HotelManagementSystem.MyControls
{
    partial class ucBilling
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.panelRight = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChargesTitle = new System.Windows.Forms.Label();
            this.dgvCharges = new System.Windows.Forms.DataGridView();
            this.label0 = new System.Windows.Forms.Label();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.panelRow1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRoomText = new System.Windows.Forms.Label();
            this.lblRoomValue = new System.Windows.Forms.Label();
            this.lblFnBValue = new System.Windows.Forms.Label();
            this.lblFnBText = new System.Windows.Forms.Label();
            this.lblServicesValue = new System.Windows.Forms.Label();
            this.lblServicesText = new System.Windows.Forms.Label();
            this.lblTaxValue = new System.Windows.Forms.Label();
            this.lblTaxText = new System.Windows.Forms.Label();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.lblSubtotalText = new System.Windows.Forms.Label();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnDownload = new Guna.UI2.WinForms.Guna2Button();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharges)).BeginInit();
            this.panelRow1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.tlpMain);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblSubtitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 854);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblTitle.Location = new System.Drawing.Point(16, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(125, 45);
            this.lblTitle.TabIndex = 31;
            this.lblTitle.Text = "My Bill";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 60);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(270, 20);
            this.lblSubtitle.TabIndex = 30;
            this.lblSubtitle.Text = "Review all charges for your current stay.";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.panelRight, 1, 0);
            this.tlpMain.Controls.Add(this.panelLeft, 0, 0);
            this.tlpMain.Location = new System.Drawing.Point(24, 83);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1058, 771);
            this.tlpMain.TabIndex = 32;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelLeft.BorderRadius = 10;
            this.panelLeft.Controls.Add(this.label0);
            this.panelLeft.Controls.Add(this.dgvCharges);
            this.panelLeft.Controls.Add(this.lblChargesTitle);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.FillColor = System.Drawing.Color.White;
            this.panelLeft.Location = new System.Drawing.Point(3, 3);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(523, 765);
            this.panelLeft.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.BorderRadius = 10;
            this.panelRight.Controls.Add(this.btnPay);
            this.panelRight.Controls.Add(this.btnDownload);
            this.panelRight.Controls.Add(this.guna2Panel2);
            this.panelRight.Controls.Add(this.guna2Panel1);
            this.panelRight.Controls.Add(this.panelRow1);
            this.panelRight.Controls.Add(this.lblSummaryTitle);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.FillColor = System.Drawing.Color.White;
            this.panelRight.Location = new System.Drawing.Point(532, 3);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(523, 765);
            this.panelRight.TabIndex = 1;
            // 
            // lblChargesTitle
            // 
            this.lblChargesTitle.AutoSize = true;
            this.lblChargesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblChargesTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargesTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblChargesTitle.Location = new System.Drawing.Point(12, 13);
            this.lblChargesTitle.Name = "lblChargesTitle";
            this.lblChargesTitle.Size = new System.Drawing.Size(191, 25);
            this.lblChargesTitle.TabIndex = 31;
            this.lblChargesTitle.Text = "ITEMIZED CHARGES";
            // 
            // dgvCharges
            // 
            this.dgvCharges.AllowUserToAddRows = false;
            this.dgvCharges.AllowUserToDeleteRows = false;
            this.dgvCharges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCharges.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCharges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCharges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colDescription,
            this.colCategory,
            this.colAmount});
            this.dgvCharges.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCharges.Location = new System.Drawing.Point(17, 61);
            this.dgvCharges.MultiSelect = false;
            this.dgvCharges.Name = "dgvCharges";
            this.dgvCharges.ReadOnly = true;
            this.dgvCharges.RowHeadersVisible = false;
            this.dgvCharges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCharges.Size = new System.Drawing.Size(491, 678);
            this.dgvCharges.TabIndex = 32;
            // 
            // label0
            // 
            this.label0.AutoSize = true;
            this.label0.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label0.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label0.Location = new System.Drawing.Point(13, 38);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(242, 20);
            this.label0.TabIndex = 33;
            this.label0.Text = "Date Description Category Amount";
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDate.HeaderText = "DATE";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 70;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDescription.FillWeight = 80F;
            this.colDescription.HeaderText = "DESCRIPTION";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 139;
            // 
            // colCategory
            // 
            this.colCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCategory.FillWeight = 80F;
            this.colCategory.HeaderText = "CATEGORY";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 140;
            // 
            // colAmount
            // 
            this.colAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.colAmount.FillWeight = 80F;
            this.colAmount.HeaderText = "AMOUNT";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 139;
            // 
            // lblSummaryTitle
            // 
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummaryTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSummaryTitle.Location = new System.Drawing.Point(15, 13);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(153, 25);
            this.lblSummaryTitle.TabIndex = 32;
            this.lblSummaryTitle.Text = "BILL SUMMARY";
            // 
            // panelRow1
            // 
            this.panelRow1.BorderColor = System.Drawing.Color.Black;
            this.panelRow1.BorderThickness = 1;
            this.panelRow1.Controls.Add(this.lblServicesValue);
            this.panelRow1.Controls.Add(this.lblServicesText);
            this.panelRow1.Controls.Add(this.lblFnBValue);
            this.panelRow1.Controls.Add(this.lblFnBText);
            this.panelRow1.Controls.Add(this.lblRoomValue);
            this.panelRow1.Controls.Add(this.lblRoomText);
            this.panelRow1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelRow1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.panelRow1.CustomizableEdges.TopLeft = false;
            this.panelRow1.CustomizableEdges.TopRight = false;
            this.panelRow1.Location = new System.Drawing.Point(20, 61);
            this.panelRow1.Name = "panelRow1";
            this.panelRow1.Size = new System.Drawing.Size(486, 171);
            this.panelRow1.TabIndex = 33;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.lblTaxValue);
            this.guna2Panel1.Controls.Add(this.lblTaxText);
            this.guna2Panel1.Controls.Add(this.lblSubtotalValue);
            this.guna2Panel1.Controls.Add(this.lblSubtotalText);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.guna2Panel1.CustomizableEdges.TopLeft = false;
            this.guna2Panel1.CustomizableEdges.TopRight = false;
            this.guna2Panel1.Location = new System.Drawing.Point(20, 251);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(486, 142);
            this.guna2Panel1.TabIndex = 34;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.lblStatus);
            this.guna2Panel2.Controls.Add(this.lblTotalValue);
            this.guna2Panel2.Controls.Add(this.lblTotalText);
            this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.guna2Panel2.CustomizableEdges.TopLeft = false;
            this.guna2Panel2.CustomizableEdges.TopRight = false;
            this.guna2Panel2.Location = new System.Drawing.Point(20, 411);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(486, 103);
            this.guna2Panel2.TabIndex = 35;
            // 
            // lblRoomText
            // 
            this.lblRoomText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRoomText.AutoSize = true;
            this.lblRoomText.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomText.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRoomText.Location = new System.Drawing.Point(13, 30);
            this.lblRoomText.Name = "lblRoomText";
            this.lblRoomText.Size = new System.Drawing.Size(219, 25);
            this.lblRoomText.TabIndex = 34;
            this.lblRoomText.Text = "Room Charges (2 nights)";
            // 
            // lblRoomValue
            // 
            this.lblRoomValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRoomValue.AutoSize = true;
            this.lblRoomValue.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRoomValue.Location = new System.Drawing.Point(391, 30);
            this.lblRoomValue.Name = "lblRoomValue";
            this.lblRoomValue.Size = new System.Drawing.Size(69, 25);
            this.lblRoomValue.TabIndex = 35;
            this.lblRoomValue.Text = "₱6,400";
            this.lblRoomValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFnBValue
            // 
            this.lblFnBValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFnBValue.AutoSize = true;
            this.lblFnBValue.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFnBValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFnBValue.Location = new System.Drawing.Point(391, 71);
            this.lblFnBValue.Name = "lblFnBValue";
            this.lblFnBValue.Size = new System.Drawing.Size(69, 25);
            this.lblFnBValue.TabIndex = 37;
            this.lblFnBValue.Text = "₱2,860";
            this.lblFnBValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFnBValue.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblFnBText
            // 
            this.lblFnBText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFnBText.AutoSize = true;
            this.lblFnBText.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFnBText.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFnBText.Location = new System.Drawing.Point(13, 71);
            this.lblFnBText.Name = "lblFnBText";
            this.lblFnBText.Size = new System.Drawing.Size(157, 25);
            this.lblFnBText.TabIndex = 36;
            this.lblFnBText.Text = "Food && Beverage";
            // 
            // lblServicesValue
            // 
            this.lblServicesValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServicesValue.AutoSize = true;
            this.lblServicesValue.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicesValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblServicesValue.Location = new System.Drawing.Point(394, 114);
            this.lblServicesValue.Name = "lblServicesValue";
            this.lblServicesValue.Size = new System.Drawing.Size(55, 25);
            this.lblServicesValue.TabIndex = 39;
            this.lblServicesValue.Text = "₱560";
            this.lblServicesValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblServicesText
            // 
            this.lblServicesText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServicesText.AutoSize = true;
            this.lblServicesText.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicesText.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblServicesText.Location = new System.Drawing.Point(13, 114);
            this.lblServicesText.Name = "lblServicesText";
            this.lblServicesText.Size = new System.Drawing.Size(80, 25);
            this.lblServicesText.TabIndex = 38;
            this.lblServicesText.Text = "Services";
            // 
            // lblTaxValue
            // 
            this.lblTaxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTaxValue.AutoSize = true;
            this.lblTaxValue.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTaxValue.Location = new System.Drawing.Point(401, 80);
            this.lblTaxValue.Name = "lblTaxValue";
            this.lblTaxValue.Size = new System.Drawing.Size(69, 25);
            this.lblTaxValue.TabIndex = 43;
            this.lblTaxValue.Text = "₱1,178";
            this.lblTaxValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTaxText
            // 
            this.lblTaxText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTaxText.AutoSize = true;
            this.lblTaxText.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxText.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTaxText.Location = new System.Drawing.Point(20, 80);
            this.lblTaxText.Name = "lblTaxText";
            this.lblTaxText.Size = new System.Drawing.Size(245, 25);
            this.lblTaxText.TabIndex = 42;
            this.lblTaxText.Text = "Tax && Service Charge (12%)";
            // 
            // lblSubtotalValue
            // 
            this.lblSubtotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSubtotalValue.AutoSize = true;
            this.lblSubtotalValue.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSubtotalValue.Location = new System.Drawing.Point(398, 37);
            this.lblSubtotalValue.Name = "lblSubtotalValue";
            this.lblSubtotalValue.Size = new System.Drawing.Size(69, 25);
            this.lblSubtotalValue.TabIndex = 41;
            this.lblSubtotalValue.Text = "₱9,820";
            this.lblSubtotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotalText
            // 
            this.lblSubtotalText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSubtotalText.AutoSize = true;
            this.lblSubtotalText.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalText.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSubtotalText.Location = new System.Drawing.Point(20, 37);
            this.lblSubtotalText.Name = "lblSubtotalText";
            this.lblSubtotalText.Size = new System.Drawing.Size(82, 25);
            this.lblSubtotalText.TabIndex = 40;
            this.lblSubtotalText.Text = "Subtotal";
            // 
            // lblTotalText
            // 
            this.lblTotalText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalText.AutoSize = true;
            this.lblTotalText.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalText.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblTotalText.Location = new System.Drawing.Point(19, 9);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(123, 32);
            this.lblTotalText.TabIndex = 32;
            this.lblTotalText.Text = "Total Due";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTotalValue.Location = new System.Drawing.Point(364, 9);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(106, 32);
            this.lblTotalValue.TabIndex = 33;
            this.lblTotalValue.Text = "₱10,998";
            this.lblTotalValue.Click += new System.EventHandler(this.lblTotalValue_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.IndianRed;
            this.lblStatus.Location = new System.Drawing.Point(19, 56);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(118, 32);
            this.lblStatus.TabIndex = 34;
            this.lblStatus.Text = "● Unpaid";
            // 
            // btnDownload
            // 
            this.btnDownload.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnDownload.BorderRadius = 10;
            this.btnDownload.BorderThickness = 1;
            this.btnDownload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDownload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDownload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDownload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDownload.FillColor = System.Drawing.Color.Transparent;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.btnDownload.Location = new System.Drawing.Point(20, 545);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(486, 58);
            this.btnDownload.TabIndex = 36;
            this.btnDownload.Text = "🖨  Download PDF";
            this.btnDownload.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnPay
            // 
            this.btnPay.BorderRadius = 10;
            this.btnPay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(20, 626);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(486, 58);
            this.btnPay.TabIndex = 37;
            this.btnPay.Text = "💳  Pay Now";
            // 
            // ucBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucBilling";
            this.Size = new System.Drawing.Size(1110, 854);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharges)).EndInit();
            this.panelRow1.ResumeLayout(false);
            this.panelRow1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private Guna.UI2.WinForms.Guna2Panel panelRight;
        private Guna.UI2.WinForms.Guna2Panel panelLeft;
        private System.Windows.Forms.DataGridView dgvCharges;
        private System.Windows.Forms.Label lblChargesTitle;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private Guna.UI2.WinForms.Guna2Panel panelRow1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblRoomText;
        private System.Windows.Forms.Label lblRoomValue;
        private System.Windows.Forms.Label lblServicesValue;
        private System.Windows.Forms.Label lblServicesText;
        private System.Windows.Forms.Label lblFnBValue;
        private System.Windows.Forms.Label lblFnBText;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Label lblTaxValue;
        private System.Windows.Forms.Label lblTaxText;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.Label lblSubtotalText;
        private Guna.UI2.WinForms.Guna2Button btnPay;
        private Guna.UI2.WinForms.Guna2Button btnDownload;
        private System.Windows.Forms.Label lblStatus;
    }
}
