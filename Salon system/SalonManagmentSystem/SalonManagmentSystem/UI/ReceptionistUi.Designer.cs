namespace SalonManagmentSystem.UI
{
    partial class ReceptionistUi
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
            this.main_tablepanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.navbar_panel = new System.Windows.Forms.Panel();
            this.home_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Appointments_btn = new Guna.UI2.WinForms.Guna2Button();
            this.employees_btn = new Guna.UI2.WinForms.Guna2Button();
            this.customers_btn = new Guna.UI2.WinForms.Guna2Button();
            this.notifications_btn = new Guna.UI2.WinForms.Guna2Button();
            this.logout_btn = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.main_tablepanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.navbar_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // main_tablepanel
            // 
            this.main_tablepanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.main_tablepanel.ColumnCount = 1;
            this.main_tablepanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.main_tablepanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.main_tablepanel.Controls.Add(this.pictureBox1, 0, 1);
            this.main_tablepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tablepanel.Location = new System.Drawing.Point(0, 0);
            this.main_tablepanel.Name = "main_tablepanel";
            this.main_tablepanel.RowCount = 2;
            this.main_tablepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.main_tablepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.main_tablepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tablepanel.Size = new System.Drawing.Size(1409, 710);
            this.main_tablepanel.TabIndex = 7;
            this.main_tablepanel.Paint += new System.Windows.Forms.PaintEventHandler(this.main_tablepanel_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.IndianRed;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.624376F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.37563F));
            this.tableLayoutPanel1.Controls.Add(this.navbar_panel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5304F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.78723F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.510638F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1403, 101);
            this.tableLayoutPanel1.TabIndex = 3;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // navbar_panel
            // 
            this.navbar_panel.BackColor = System.Drawing.Color.IndianRed;
            this.navbar_panel.Controls.Add(this.home_btn);
            this.navbar_panel.Controls.Add(this.Appointments_btn);
            this.navbar_panel.Controls.Add(this.employees_btn);
            this.navbar_panel.Controls.Add(this.customers_btn);
            this.navbar_panel.Controls.Add(this.notifications_btn);
            this.navbar_panel.Controls.Add(this.logout_btn);
            this.navbar_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navbar_panel.Location = new System.Drawing.Point(123, 15);
            this.navbar_panel.Name = "navbar_panel";
            this.navbar_panel.Size = new System.Drawing.Size(1277, 73);
            this.navbar_panel.TabIndex = 2;
            // 
            // home_btn
            // 
            this.home_btn.BackColor = System.Drawing.Color.Transparent;
            this.home_btn.BorderColor = System.Drawing.Color.White;
            this.home_btn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.home_btn.CheckedState.FillColor = System.Drawing.Color.IndianRed;
            this.home_btn.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.home_btn.CustomBorderColor = System.Drawing.Color.Transparent;
            this.home_btn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.home_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.home_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.home_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.home_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.home_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.home_btn.FillColor = System.Drawing.Color.IndianRed;
            this.home_btn.Font = new System.Drawing.Font("Tw Cen MT", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.home_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.home_btn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.home_btn.HoverState.FillColor = System.Drawing.Color.IndianRed;
            this.home_btn.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.home_btn.Location = new System.Drawing.Point(181, 0);
            this.home_btn.Name = "home_btn";
            this.home_btn.Size = new System.Drawing.Size(180, 73);
            this.home_btn.TabIndex = 7;
            this.home_btn.Text = "Home";
            this.home_btn.Click += new System.EventHandler(this.home_btn_Click);
            // 
            // Appointments_btn
            // 
            this.Appointments_btn.BackColor = System.Drawing.Color.Transparent;
            this.Appointments_btn.BorderColor = System.Drawing.Color.White;
            this.Appointments_btn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.Appointments_btn.CheckedState.FillColor = System.Drawing.Color.IndianRed;
            this.Appointments_btn.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.Appointments_btn.CustomBorderColor = System.Drawing.Color.Transparent;
            this.Appointments_btn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.Appointments_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Appointments_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Appointments_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Appointments_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Appointments_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.Appointments_btn.FillColor = System.Drawing.Color.IndianRed;
            this.Appointments_btn.Font = new System.Drawing.Font("Tw Cen MT", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appointments_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.Appointments_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.Appointments_btn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.Appointments_btn.HoverState.FillColor = System.Drawing.Color.IndianRed;
            this.Appointments_btn.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.Appointments_btn.Location = new System.Drawing.Point(361, 0);
            this.Appointments_btn.Name = "Appointments_btn";
            this.Appointments_btn.Size = new System.Drawing.Size(196, 73);
            this.Appointments_btn.TabIndex = 5;
            this.Appointments_btn.Text = "Appointments";
            this.Appointments_btn.Click += new System.EventHandler(this.Appointments_btn_Click);
            // 
            // employees_btn
            // 
            this.employees_btn.BackColor = System.Drawing.Color.Transparent;
            this.employees_btn.BorderColor = System.Drawing.Color.Transparent;
            this.employees_btn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.employees_btn.CheckedState.FillColor = System.Drawing.Color.IndianRed;
            this.employees_btn.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.employees_btn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.employees_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.employees_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.employees_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.employees_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.employees_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.employees_btn.FillColor = System.Drawing.Color.IndianRed;
            this.employees_btn.Font = new System.Drawing.Font("Tw Cen MT", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employees_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.employees_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.employees_btn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.employees_btn.HoverState.FillColor = System.Drawing.Color.IndianRed;
            this.employees_btn.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.employees_btn.Location = new System.Drawing.Point(557, 0);
            this.employees_btn.Name = "employees_btn";
            this.employees_btn.Size = new System.Drawing.Size(180, 73);
            this.employees_btn.TabIndex = 4;
            this.employees_btn.Text = "Employees";
            this.employees_btn.Click += new System.EventHandler(this.employees_btn_Click);
            // 
            // customers_btn
            // 
            this.customers_btn.BackColor = System.Drawing.Color.Transparent;
            this.customers_btn.BorderColor = System.Drawing.Color.Transparent;
            this.customers_btn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.customers_btn.CheckedState.FillColor = System.Drawing.Color.IndianRed;
            this.customers_btn.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.customers_btn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.customers_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.customers_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.customers_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.customers_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.customers_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.customers_btn.FillColor = System.Drawing.Color.IndianRed;
            this.customers_btn.Font = new System.Drawing.Font("Tw Cen MT", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customers_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.customers_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.customers_btn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.customers_btn.HoverState.FillColor = System.Drawing.Color.IndianRed;
            this.customers_btn.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.customers_btn.Location = new System.Drawing.Point(737, 0);
            this.customers_btn.Name = "customers_btn";
            this.customers_btn.Size = new System.Drawing.Size(180, 73);
            this.customers_btn.TabIndex = 3;
            this.customers_btn.Text = "Customers";
            this.customers_btn.Click += new System.EventHandler(this.customers_btn_Click);
            // 
            // notifications_btn
            // 
            this.notifications_btn.BackColor = System.Drawing.Color.Transparent;
            this.notifications_btn.BorderColor = System.Drawing.Color.Transparent;
            this.notifications_btn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.notifications_btn.CheckedState.FillColor = System.Drawing.Color.IndianRed;
            this.notifications_btn.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.notifications_btn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.notifications_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.notifications_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.notifications_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.notifications_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.notifications_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.notifications_btn.FillColor = System.Drawing.Color.IndianRed;
            this.notifications_btn.Font = new System.Drawing.Font("Tw Cen MT", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifications_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.notifications_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.notifications_btn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.notifications_btn.HoverState.FillColor = System.Drawing.Color.IndianRed;
            this.notifications_btn.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.notifications_btn.Location = new System.Drawing.Point(917, 0);
            this.notifications_btn.Name = "notifications_btn";
            this.notifications_btn.Size = new System.Drawing.Size(180, 73);
            this.notifications_btn.TabIndex = 2;
            this.notifications_btn.Text = "Notifications";
            this.notifications_btn.Click += new System.EventHandler(this.notifications_btn_Click);
            // 
            // logout_btn
            // 
            this.logout_btn.BackColor = System.Drawing.Color.Transparent;
            this.logout_btn.BorderColor = System.Drawing.Color.Transparent;
            this.logout_btn.BorderRadius = 12;
            this.logout_btn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.logout_btn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.logout_btn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.logout_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.logout_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.logout_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.logout_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.logout_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.logout_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(117)))));
            this.logout_btn.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_btn.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.logout_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.logout_btn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.logout_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(35)))), ((int)(((byte)(76)))));
            this.logout_btn.Location = new System.Drawing.Point(1097, 0);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(180, 73);
            this.logout_btn.TabIndex = 0;
            this.logout_btn.Text = "Log Out";
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::SalonManagmentSystem.Properties.Resources.Pink_Luxury_Beauty_Salon_Logo__2_;
            this.pictureBox2.Location = new System.Drawing.Point(3, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(114, 73);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.MistyRose;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::SalonManagmentSystem.Properties.Resources.Pink_Luxury_Beauty_Salon_Logo__1_;
            this.pictureBox1.Location = new System.Drawing.Point(3, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1403, 597);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ReceptionistUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 710);
            this.Controls.Add(this.main_tablepanel);
            this.Name = "ReceptionistUi";
            this.Text = "ReceptionistUi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.main_tablepanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.navbar_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel main_tablepanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel navbar_panel;
        private Guna.UI2.WinForms.Guna2Button home_btn;
        private Guna.UI2.WinForms.Guna2Button Appointments_btn;
        private Guna.UI2.WinForms.Guna2Button employees_btn;
        private Guna.UI2.WinForms.Guna2Button customers_btn;
        private Guna.UI2.WinForms.Guna2Button notifications_btn;
        private Guna.UI2.WinForms.Guna2Button logout_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}