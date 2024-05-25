namespace SalonManagmentSystem.UI.EmployeeUi
{
    partial class generateSalaries
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.att_gv = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Paid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Fine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.generate_btn = new Guna.UI2.WinForms.Guna2Button();
            this.year_cb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.month_cb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.all_btn = new Guna.UI2.WinForms.Guna2Button();
            this.emp = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.att_gv)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(167)))));
            this.guna2Panel1.Controls.Add(this.tableLayoutPanel1);
            this.guna2Panel1.Controls.Add(this.emp);
            this.guna2Panel1.Location = new System.Drawing.Point(18, 26);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1125, 573);
            this.guna2Panel1.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.att_gv, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1083, 485);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // att_gv
            // 
            this.att_gv.AllowUserToAddRows = false;
            this.att_gv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tw Cen MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.att_gv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tw Cen MT", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.att_gv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.att_gv.ColumnHeadersHeight = 25;
            this.att_gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.att_gv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Paid,
            this.Fine});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(35)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(35)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.att_gv.DefaultCellStyle = dataGridViewCellStyle4;
            this.att_gv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.att_gv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.att_gv.Location = new System.Drawing.Point(3, 63);
            this.att_gv.Name = "att_gv";
            this.att_gv.RowHeadersVisible = false;
            this.att_gv.RowHeadersWidth = 10;
            this.att_gv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.att_gv.RowTemplate.Height = 24;
            this.att_gv.Size = new System.Drawing.Size(1077, 419);
            this.att_gv.TabIndex = 13;
            this.att_gv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.att_gv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.att_gv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.att_gv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.att_gv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.att_gv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.att_gv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.att_gv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.att_gv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.att_gv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.att_gv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.att_gv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.att_gv.ThemeStyle.HeaderStyle.Height = 25;
            this.att_gv.ThemeStyle.ReadOnly = false;
            this.att_gv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.att_gv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.att_gv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.att_gv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.att_gv.ThemeStyle.RowsStyle.Height = 24;
            this.att_gv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.att_gv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.att_gv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.att_gv_CellContentClick);
            // 
            // Paid
            // 
            this.Paid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Paid.HeaderText = "Paid";
            this.Paid.MinimumWidth = 6;
            this.Paid.Name = "Paid";
            this.Paid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Paid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Paid.Text = "Pay";
            this.Paid.UseColumnTextForButtonValue = true;
            // 
            // Fine
            // 
            this.Fine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.Fine.DefaultCellStyle = dataGridViewCellStyle3;
            this.Fine.HeaderText = "Fine";
            this.Fine.MinimumWidth = 6;
            this.Fine.Name = "Fine";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.generate_btn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.year_cb, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.month_cb, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.all_btn, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1077, 54);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // generate_btn
            // 
            this.generate_btn.BackColor = System.Drawing.Color.Transparent;
            this.generate_btn.BorderColor = System.Drawing.Color.Transparent;
            this.generate_btn.BorderRadius = 12;
            this.generate_btn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.generate_btn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.generate_btn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.generate_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.generate_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.generate_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.generate_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.generate_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generate_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(117)))));
            this.generate_btn.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F);
            this.generate_btn.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.generate_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.generate_btn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.generate_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(35)))), ((int)(((byte)(76)))));
            this.generate_btn.Location = new System.Drawing.Point(475, 3);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(196, 48);
            this.generate_btn.TabIndex = 40;
            this.generate_btn.Text = "Generate";
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // year_cb
            // 
            this.year_cb.BackColor = System.Drawing.Color.Transparent;
            this.year_cb.BorderRadius = 10;
            this.year_cb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.year_cb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.year_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.year_cb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.year_cb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.year_cb.Font = new System.Drawing.Font("Tw Cen MT", 10.8F);
            this.year_cb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(35)))), ((int)(((byte)(76)))));
            this.year_cb.ItemHeight = 43;
            this.year_cb.Items.AddRange(new object[] {
            "Year",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.year_cb.Location = new System.Drawing.Point(228, 3);
            this.year_cb.Name = "year_cb";
            this.year_cb.Size = new System.Drawing.Size(241, 49);
            this.year_cb.StartIndex = 1;
            this.year_cb.TabIndex = 38;
            // 
            // month_cb
            // 
            this.month_cb.BackColor = System.Drawing.Color.Transparent;
            this.month_cb.BorderRadius = 10;
            this.month_cb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.month_cb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.month_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.month_cb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.month_cb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.month_cb.Font = new System.Drawing.Font("Tw Cen MT", 10.8F);
            this.month_cb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(35)))), ((int)(((byte)(76)))));
            this.month_cb.ItemHeight = 43;
            this.month_cb.Items.AddRange(new object[] {
            "Month",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.month_cb.Location = new System.Drawing.Point(3, 3);
            this.month_cb.Name = "month_cb";
            this.month_cb.Size = new System.Drawing.Size(219, 49);
            this.month_cb.StartIndex = 0;
            this.month_cb.TabIndex = 37;
            // 
            // all_btn
            // 
            this.all_btn.BackColor = System.Drawing.Color.Transparent;
            this.all_btn.BorderColor = System.Drawing.Color.Transparent;
            this.all_btn.BorderRadius = 12;
            this.all_btn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.all_btn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.all_btn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.all_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.all_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.all_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.all_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.all_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.all_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(117)))));
            this.all_btn.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F);
            this.all_btn.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.all_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.all_btn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.all_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(35)))), ((int)(((byte)(76)))));
            this.all_btn.Location = new System.Drawing.Point(677, 3);
            this.all_btn.Name = "all_btn";
            this.all_btn.Size = new System.Drawing.Size(182, 48);
            this.all_btn.TabIndex = 36;
            this.all_btn.Text = "Paid to all";
            this.all_btn.Click += new System.EventHandler(this.all_btn_Click);
            // 
            // emp
            // 
            this.emp.BackColor = System.Drawing.Color.Transparent;
            this.emp.Dock = System.Windows.Forms.DockStyle.Left;
            this.emp.Font = new System.Drawing.Font("Tw Cen MT", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emp.Location = new System.Drawing.Point(0, 0);
            this.emp.Name = "emp";
            this.emp.Size = new System.Drawing.Size(494, 573);
            this.emp.TabIndex = 1;
            this.emp.Text = "Monthly Salaries  Of Employees";
            this.emp.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // generateSalaries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "generateSalaries";
            this.Size = new System.Drawing.Size(1161, 616);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.att_gv)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView att_gv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel emp;
        private Guna.UI2.WinForms.Guna2Button all_btn;
        private Guna.UI2.WinForms.Guna2ComboBox year_cb;
        private Guna.UI2.WinForms.Guna2ComboBox month_cb;
        private Guna.UI2.WinForms.Guna2Button generate_btn;
        private System.Windows.Forms.DataGridViewButtonColumn Paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fine;
    }
}
