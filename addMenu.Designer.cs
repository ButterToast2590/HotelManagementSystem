namespace HotelManagementSystem
{
    partial class addMenu
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
            this.addMenubtn = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.layoutFname = new System.Windows.Forms.TableLayoutPanel();
            this.txtMenuName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFloorNum = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuPicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.userTitlepanel.SuspendLayout();
            this.layoutFname.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuPicture)).BeginInit();
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
            this.userTitlepanel.Size = new System.Drawing.Size(476, 35);
            this.userTitlepanel.TabIndex = 91;
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
            this.btnMinimize.Location = new System.Drawing.Point(406, 5);
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
            this.btnClose.Location = new System.Drawing.Point(437, 5);
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
            this.label23.Size = new System.Drawing.Size(119, 30);
            this.label23.TabIndex = 0;
            this.label23.Text = "Add Menu";
            // 
            // addMenubtn
            // 
            this.addMenubtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addMenubtn.BorderRadius = 10;
            this.addMenubtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addMenubtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addMenubtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addMenubtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addMenubtn.FillColor = System.Drawing.SystemColors.HotTrack;
            this.addMenubtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMenubtn.ForeColor = System.Drawing.Color.White;
            this.addMenubtn.Location = new System.Drawing.Point(38, 513);
            this.addMenubtn.Name = "addMenubtn";
            this.addMenubtn.Size = new System.Drawing.Size(401, 54);
            this.addMenubtn.TabIndex = 101;
            this.addMenubtn.Text = "Add Menu";
            this.addMenubtn.Click += new System.EventHandler(this.addMenubtn_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(41, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 20);
            this.label4.TabIndex = 99;
            this.label4.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtDescription.BorderRadius = 10;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Location = new System.Drawing.Point(38, 393);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(401, 87);
            this.txtDescription.TabIndex = 100;
            // 
            // layoutFname
            // 
            this.layoutFname.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutFname.ColumnCount = 1;
            this.layoutFname.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutFname.Controls.Add(this.txtMenuName, 0, 1);
            this.layoutFname.Controls.Add(this.lblFloorNum, 0, 0);
            this.layoutFname.Location = new System.Drawing.Point(40, 297);
            this.layoutFname.Name = "layoutFname";
            this.layoutFname.RowCount = 2;
            this.layoutFname.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutFname.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutFname.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutFname.Size = new System.Drawing.Size(197, 70);
            this.layoutFname.TabIndex = 98;
            // 
            // txtMenuName
            // 
            this.txtMenuName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtMenuName.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtMenuName.BorderRadius = 10;
            this.txtMenuName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMenuName.DefaultText = "";
            this.txtMenuName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMenuName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMenuName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMenuName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMenuName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMenuName.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtMenuName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMenuName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMenuName.ForeColor = System.Drawing.Color.Black;
            this.txtMenuName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMenuName.Location = new System.Drawing.Point(4, 24);
            this.txtMenuName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.PlaceholderText = "";
            this.txtMenuName.SelectedText = "";
            this.txtMenuName.Size = new System.Drawing.Size(189, 42);
            this.txtMenuName.TabIndex = 17;
            // 
            // lblFloorNum
            // 
            this.lblFloorNum.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFloorNum.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFloorNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFloorNum.ForeColor = System.Drawing.Color.DimGray;
            this.lblFloorNum.Location = new System.Drawing.Point(3, 0);
            this.lblFloorNum.Name = "lblFloorNum";
            this.lblFloorNum.Size = new System.Drawing.Size(191, 20);
            this.lblFloorNum.TabIndex = 11;
            this.lblFloorNum.Text = "Menu Name";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblPrice, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(246, 297);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(197, 70);
            this.tableLayoutPanel1.TabIndex = 102;
            // 
            // lblPrice
            // 
            this.lblPrice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblPrice.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblPrice.BorderRadius = 10;
            this.lblPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblPrice.DefaultText = "";
            this.lblPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lblPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lblPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lblPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrice.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.Black;
            this.lblPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblPrice.Location = new System.Drawing.Point(4, 24);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.PlaceholderText = "";
            this.lblPrice.SelectedText = "";
            this.lblPrice.Size = new System.Drawing.Size(189, 42);
            this.lblPrice.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Price";
            // 
            // menuPicture
            // 
            this.menuPicture.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuPicture.BorderRadius = 10;
            this.menuPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuPicture.Image = global::HotelManagementSystem.Properties.Resources.picture__3_;
            this.menuPicture.ImageRotate = 0F;
            this.menuPicture.Location = new System.Drawing.Point(40, 56);
            this.menuPicture.Name = "menuPicture";
            this.menuPicture.Size = new System.Drawing.Size(403, 222);
            this.menuPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.menuPicture.TabIndex = 97;
            this.menuPicture.TabStop = false;
            this.menuPicture.Click += new System.EventHandler(this.menuPicture_Click);
            // 
            // addMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(476, 583);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.addMenubtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.layoutFname);
            this.Controls.Add(this.menuPicture);
            this.Controls.Add(this.userTitlepanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addMenu";
            this.userTitlepanel.ResumeLayout(false);
            this.userTitlepanel.PerformLayout();
            this.layoutFname.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userTitlepanel;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label label23;
        private Guna.UI2.WinForms.Guna2Button addMenubtn;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private System.Windows.Forms.TableLayoutPanel layoutFname;
        private Guna.UI2.WinForms.Guna2TextBox txtMenuName;
        private System.Windows.Forms.Label lblFloorNum;
        private Guna.UI2.WinForms.Guna2PictureBox menuPicture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2TextBox lblPrice;
        private System.Windows.Forms.Label label1;
    }
}