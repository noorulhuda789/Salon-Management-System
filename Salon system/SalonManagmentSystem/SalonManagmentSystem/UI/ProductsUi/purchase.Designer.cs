namespace SalonManagmentSystem.UI.ProductsUi
{
    partial class purchase
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainpanel = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.productId = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.orderId = new Guna.UI2.WinForms.Guna2TextBox();
            this.quantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.timePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.price = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.mainpanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.28773F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.71227F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tableLayoutPanel1.Controls.Add(this.mainpanel, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.571428F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.42857F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1375, 742);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // mainpanel
            // 
            this.mainpanel.Controls.Add(this.tableLayoutPanel2);
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(314, 65);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(677, 665);
            this.mainpanel.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(155)))));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.59184F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.26531F));
            this.tableLayoutPanel2.Controls.Add(this.orderId, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.productId, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.quantity, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.timePicker, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.price, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.guna2Button1, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.86842F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.13158F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(677, 665);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // productId
            // 
            this.productId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.productId.DefaultText = "";
            this.productId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.productId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.productId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.productId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.productId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productId.Enabled = false;
            this.productId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(35)))), ((int)(((byte)(76)))));
            this.productId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.productId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.productId.Location = new System.Drawing.Point(73, 167);
            this.productId.Margin = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.productId.Name = "productId";
            this.productId.PasswordChar = '\0';
            this.productId.PlaceholderText = "Product Id";
            this.productId.SelectedText = "";
            this.productId.Size = new System.Drawing.Size(488, 57);
            this.productId.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.productId.TabIndex = 3;
            this.productId.TextChanged += new System.EventHandler(this.productId_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 22.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(145, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Purchase Product";
            // 
            // orderId
            // 
            this.orderId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.orderId.DefaultText = "";
            this.orderId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.orderId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.orderId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.orderId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.orderId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderId.Enabled = false;
            this.orderId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(35)))), ((int)(((byte)(76)))));
            this.orderId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.orderId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.orderId.Location = new System.Drawing.Point(73, 71);
            this.orderId.Margin = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.orderId.Name = "orderId";
            this.orderId.PasswordChar = '\0';
            this.orderId.PlaceholderText = "OrderID";
            this.orderId.SelectedText = "";
            this.orderId.Size = new System.Drawing.Size(488, 56);
            this.orderId.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.orderId.TabIndex = 1;
            this.orderId.TextChanged += new System.EventHandler(this.orderId_TextChanged);
            // 
            // quantity
            // 
            this.quantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.quantity.DefaultText = "";
            this.quantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.quantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.quantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.quantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.quantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(35)))), ((int)(((byte)(76)))));
            this.quantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.quantity.Location = new System.Drawing.Point(73, 264);
            this.quantity.Margin = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.quantity.Name = "quantity";
            this.quantity.PasswordChar = '\0';
            this.quantity.PlaceholderText = "Quantity";
            this.quantity.SelectedText = "";
            this.quantity.Size = new System.Drawing.Size(488, 52);
            this.quantity.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.quantity.TabIndex = 4;
            // 
            // timePicker
            // 
            this.timePicker.Checked = true;
            this.timePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.timePicker.Location = new System.Drawing.Point(73, 356);
            this.timePicker.Margin = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.timePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.timePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.timePicker.Name = "timePicker";
            this.timePicker.Size = new System.Drawing.Size(488, 50);
            this.timePicker.TabIndex = 2;
            this.timePicker.Value = new System.DateTime(2024, 5, 7, 21, 57, 19, 762);
            // 
            // price
            // 
            this.price.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.price.DefaultText = "";
            this.price.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.price.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.price.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.price.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.price.Dock = System.Windows.Forms.DockStyle.Fill;
            this.price.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(35)))), ((int)(((byte)(76)))));
            this.price.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.price.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.price.Location = new System.Drawing.Point(73, 446);
            this.price.Margin = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.price.Name = "price";
            this.price.PasswordChar = '\0';
            this.price.PlaceholderText = "Price";
            this.price.SelectedText = "";
            this.price.Size = new System.Drawing.Size(488, 54);
            this.price.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.price.TabIndex = 5;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(35)))), ((int)(((byte)(76)))));
            this.guna2Button1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F);
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(155)))));
            this.guna2Button1.Location = new System.Drawing.Point(227, 587);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 75);
            this.guna2Button1.TabIndex = 7;
            this.guna2Button1.Text = "Purchase";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "purchase";
            this.Size = new System.Drawing.Size(1375, 742);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.mainpanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel mainpanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox orderId;
        private Guna.UI2.WinForms.Guna2DateTimePicker timePicker;
        private Guna.UI2.WinForms.Guna2TextBox productId;
        private Guna.UI2.WinForms.Guna2TextBox quantity;
        private Guna.UI2.WinForms.Guna2TextBox price;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
