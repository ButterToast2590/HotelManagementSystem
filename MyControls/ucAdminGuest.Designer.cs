namespace HotelManagementSystem.MyControls
{
    partial class ucAdminGuest
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
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNumOfCheckoutToday = new Guna.UI2.WinForms.Guna2Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.guna2Panel8 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCurrentGuest = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.guna2Panel9 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNumOfGuest = new System.Windows.Forms.Label();
            this.totalGuest = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.guna2Panel10 = new Guna.UI2.WinForms.Guna2Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.lblNumOfCheckoutToday.SuspendLayout();
            this.guna2Panel8.SuspendLayout();
            this.guna2Panel9.SuspendLayout();
            this.guna2Panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.guna2Panel10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 854);
            this.panel1.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(12, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(302, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "All registered guests and their current status.";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblNumOfCheckoutToday, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.guna2Panel8, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.guna2Panel9, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(16, 79);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1076, 103);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // lblNumOfCheckoutToday
            // 
            this.lblNumOfCheckoutToday.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumOfCheckoutToday.BackColor = System.Drawing.Color.Transparent;
            this.lblNumOfCheckoutToday.BorderRadius = 15;
            this.lblNumOfCheckoutToday.Controls.Add(this.label15);
            this.lblNumOfCheckoutToday.Controls.Add(this.label16);
            this.lblNumOfCheckoutToday.FillColor = System.Drawing.Color.White;
            this.lblNumOfCheckoutToday.Location = new System.Drawing.Point(719, 3);
            this.lblNumOfCheckoutToday.Name = "lblNumOfCheckoutToday";
            this.lblNumOfCheckoutToday.Size = new System.Drawing.Size(354, 97);
            this.lblNumOfCheckoutToday.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(18, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 32);
            this.label15.TabIndex = 1;
            this.label15.Text = "__";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(10, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(219, 30);
            this.label16.TabIndex = 0;
            this.label16.Text = "Checking Out Today";
            // 
            // guna2Panel8
            // 
            this.guna2Panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel8.BorderRadius = 15;
            this.guna2Panel8.Controls.Add(this.lblCurrentGuest);
            this.guna2Panel8.Controls.Add(this.label18);
            this.guna2Panel8.FillColor = System.Drawing.Color.White;
            this.guna2Panel8.Location = new System.Drawing.Point(361, 3);
            this.guna2Panel8.Name = "guna2Panel8";
            this.guna2Panel8.Size = new System.Drawing.Size(352, 97);
            this.guna2Panel8.TabIndex = 28;
            // 
            // lblCurrentGuest
            // 
            this.lblCurrentGuest.AutoSize = true;
            this.lblCurrentGuest.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentGuest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurrentGuest.Location = new System.Drawing.Point(18, 48);
            this.lblCurrentGuest.Name = "lblCurrentGuest";
            this.lblCurrentGuest.Size = new System.Drawing.Size(36, 32);
            this.lblCurrentGuest.TabIndex = 1;
            this.lblCurrentGuest.Text = "__";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label18.Location = new System.Drawing.Point(10, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(226, 30);
            this.label18.TabIndex = 0;
            this.label18.Text = "Currently Checked In";
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel9.BorderRadius = 15;
            this.guna2Panel9.Controls.Add(this.lblNumOfGuest);
            this.guna2Panel9.Controls.Add(this.totalGuest);
            this.guna2Panel9.FillColor = System.Drawing.Color.White;
            this.guna2Panel9.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel9.Name = "guna2Panel9";
            this.guna2Panel9.Size = new System.Drawing.Size(352, 97);
            this.guna2Panel9.TabIndex = 27;
            // 
            // lblNumOfGuest
            // 
            this.lblNumOfGuest.AutoSize = true;
            this.lblNumOfGuest.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfGuest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNumOfGuest.Location = new System.Drawing.Point(18, 48);
            this.lblNumOfGuest.Name = "lblNumOfGuest";
            this.lblNumOfGuest.Size = new System.Drawing.Size(36, 32);
            this.lblNumOfGuest.TabIndex = 1;
            this.lblNumOfGuest.Text = "__";
            // 
            // totalGuest
            // 
            this.totalGuest.AutoSize = true;
            this.totalGuest.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalGuest.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.totalGuest.Location = new System.Drawing.Point(10, 18);
            this.totalGuest.Name = "totalGuest";
            this.totalGuest.Size = new System.Drawing.Size(139, 30);
            this.totalGuest.TabIndex = 0;
            this.totalGuest.Text = "Total Guests";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(8, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(119, 45);
            this.label21.TabIndex = 27;
            this.label21.Text = "Guests";
            // 
            // guna2Panel10
            // 
            this.guna2Panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel10.AutoSize = true;
            this.guna2Panel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel10.BorderRadius = 15;
            this.guna2Panel10.Controls.Add(this.dataGridView1);
            this.guna2Panel10.Controls.Add(this.label23);
            this.guna2Panel10.FillColor = System.Drawing.Color.White;
            this.guna2Panel10.Location = new System.Drawing.Point(16, 188);
            this.guna2Panel10.Name = "guna2Panel10";
            this.guna2Panel10.Size = new System.Drawing.Size(1076, 663);
            this.guna2Panel10.TabIndex = 30;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label23.Location = new System.Drawing.Point(10, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(113, 30);
            this.label23.TabIndex = 0;
            this.label23.Text = "Guest List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colRoom,
            this.colCheckIn,
            this.colCheckOut,
            this.colStatus,
            this.colBill});
            this.dataGridView1.Location = new System.Drawing.Point(16, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1045, 571);
            this.dataGridView1.TabIndex = 1;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 300;
            // 
            // colRoom
            // 
            this.colRoom.HeaderText = "Room";
            this.colRoom.Name = "colRoom";
            this.colRoom.Width = 140;
            // 
            // colCheckIn
            // 
            this.colCheckIn.HeaderText = "Check-In";
            this.colCheckIn.Name = "colCheckIn";
            this.colCheckIn.Width = 140;
            // 
            // colCheckOut
            // 
            this.colCheckOut.HeaderText = "Check-Out";
            this.colCheckOut.Name = "colCheckOut";
            this.colCheckOut.Width = 140;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 140;
            // 
            // colBill
            // 
            this.colBill.HeaderText = "Bill";
            this.colBill.Name = "colBill";
            this.colBill.Width = 140;
            // 
            // ucAdminGuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucAdminGuest";
            this.Size = new System.Drawing.Size(1110, 854);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.lblNumOfCheckoutToday.ResumeLayout(false);
            this.lblNumOfCheckoutToday.PerformLayout();
            this.guna2Panel8.ResumeLayout(false);
            this.guna2Panel8.PerformLayout();
            this.guna2Panel9.ResumeLayout(false);
            this.guna2Panel9.PerformLayout();
            this.guna2Panel10.ResumeLayout(false);
            this.guna2Panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Panel lblNumOfCheckoutToday;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel8;
        private System.Windows.Forms.Label lblCurrentGuest;
        private System.Windows.Forms.Label label18;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private System.Windows.Forms.Label lblNumOfGuest;
        private System.Windows.Forms.Label totalGuest;
        private System.Windows.Forms.Label label21;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel10;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBill;
    }
}
