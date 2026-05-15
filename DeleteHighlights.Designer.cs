namespace HotelManagementSystem
{
    partial class DeleteHighlights
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
            this.userTitlepanel = new System.Windows.Forms.Panel();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.label23 = new System.Windows.Forms.Label();
            this.dataGridViewHighlights = new System.Windows.Forms.DataGridView();
            this.colHighlights = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.userTitlepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHighlights)).BeginInit();
            this.SuspendLayout();
            // 
            // userTitlepanel
            // 
            this.userTitlepanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userTitlepanel.Controls.Add(this.btnMinimize);
            this.userTitlepanel.Controls.Add(this.btnClose);
            this.userTitlepanel.Controls.Add(this.label23);
            this.userTitlepanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userTitlepanel.Location = new System.Drawing.Point(0, 0);
            this.userTitlepanel.Name = "userTitlepanel";
            this.userTitlepanel.Size = new System.Drawing.Size(460, 35);
            this.userTitlepanel.TabIndex = 92;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Animated = true;
            this.btnMinimize.AutoRoundedCorners = true;
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMinimize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.IndianRed;
            this.btnMinimize.Image = global::HotelManagementSystem.Properties.Resources.minus;
            this.btnMinimize.ImageSize = new System.Drawing.Size(15, 15);
            this.btnMinimize.Location = new System.Drawing.Point(390, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.PressedColor = System.Drawing.Color.IndianRed;
            this.btnMinimize.Size = new System.Drawing.Size(18, 22);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Animated = true;
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.IndianRed;
            this.btnClose.Image = global::HotelManagementSystem.Properties.Resources.cross;
            this.btnClose.ImageSize = new System.Drawing.Size(15, 15);
            this.btnClose.Location = new System.Drawing.Point(421, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedColor = System.Drawing.Color.IndianRed;
            this.btnClose.Size = new System.Drawing.Size(25, 22);
            this.btnClose.TabIndex = 0;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label23.Location = new System.Drawing.Point(3, 1);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(190, 30);
            this.label23.TabIndex = 0;
            this.label23.Text = "Delete Highlights";
            // 
            // dataGridViewHighlights
            // 
            this.dataGridViewHighlights.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewHighlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHighlights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHighlights,
            this.colStatus});
            this.dataGridViewHighlights.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewHighlights.Location = new System.Drawing.Point(25, 72);
            this.dataGridViewHighlights.Name = "dataGridViewHighlights";
            this.dataGridViewHighlights.Size = new System.Drawing.Size(413, 440);
            this.dataGridViewHighlights.TabIndex = 93;
            this.dataGridViewHighlights.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHighlights_CellValueChanged);
            this.dataGridViewHighlights.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHighlights_CellValueChanged);
            this.dataGridViewHighlights.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewHighlights_CurrentCellDirtyStateChanged);
            // 
            // colHighlights
            // 
            this.colHighlights.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHighlights.DataPropertyName = "Highlights";
            this.colHighlights.HeaderText = "Highlights";
            this.colHighlights.Name = "colHighlights";
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Items.AddRange(new object[] {
            "Active",
            "Delete"});
            this.colStatus.Name = "colStatus";
            // 
            // DeleteHighlights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(460, 544);
            this.Controls.Add(this.dataGridViewHighlights);
            this.Controls.Add(this.userTitlepanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeleteHighlights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeleteHighlights";
            this.Load += new System.EventHandler(this.DeleteHighlights_Load);
            this.userTitlepanel.ResumeLayout(false);
            this.userTitlepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHighlights)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userTitlepanel;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dataGridViewHighlights;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHighlights;
        private System.Windows.Forms.DataGridViewComboBoxColumn colStatus;
    }
}