namespace HotelManagementSystem.MyControl
{
    partial class ucHighlights : System.Windows.Forms.UserControl
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
            this.MAINpanel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.MAINpanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // MAINpanel1
            // 
            this.MAINpanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.MAINpanel1.Controls.Add(this.guna2Panel1);
            this.MAINpanel1.Controls.Add(this.label12);
            this.MAINpanel1.Controls.Add(this.label21);
            this.MAINpanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAINpanel1.Location = new System.Drawing.Point(0, 0);
            this.MAINpanel1.Name = "MAINpanel1";
            this.MAINpanel1.Size = new System.Drawing.Size(1110, 854);
            this.MAINpanel1.TabIndex = 0;
            this.MAINpanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.MAINpanel1_Paint);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(25, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(320, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Discover featured offers and hotel experiences.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(21, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(176, 45);
            this.label21.TabIndex = 29;
            this.label21.Text = "Highlights";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.flowLayoutPanel1);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(29, 103);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1058, 748);
            this.guna2Panel1.TabIndex = 30;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panelTop);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1058, 748);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblPageTitle);
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(200, 40);
            this.panelTop.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPageTitle.Location = new System.Drawing.Point(5, 8);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(177, 25);
            this.lblPageTitle.TabIndex = 30;
            this.lblPageTitle.Text = "Available Higlights";
            // 
            // ucHighlights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MAINpanel1);
            this.Name = "ucHighlights";
            this.Size = new System.Drawing.Size(1110, 854);
            this.MAINpanel1.ResumeLayout(false);
            this.MAINpanel1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MAINpanel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label21;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private System.Windows.Forms.Label lblPageTitle;
    }
}
