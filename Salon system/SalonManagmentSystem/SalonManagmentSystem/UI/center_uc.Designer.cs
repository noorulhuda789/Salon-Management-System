namespace SalonManagmentSystem.UI
{
    partial class center_uc
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
            this.outer_tablepanel = new System.Windows.Forms.TableLayoutPanel();
            this.dropdown_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.outer_tablepanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // outer_tablepanel
            // 
            this.outer_tablepanel.AutoScroll = true;
            this.outer_tablepanel.ColumnCount = 1;
            this.outer_tablepanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outer_tablepanel.Controls.Add(this.dropdown_panel, 0, 0);
            this.outer_tablepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outer_tablepanel.Location = new System.Drawing.Point(0, 0);
            this.outer_tablepanel.Name = "outer_tablepanel";
            this.outer_tablepanel.RowCount = 2;
            this.outer_tablepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.outer_tablepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.outer_tablepanel.Size = new System.Drawing.Size(1051, 704);
            this.outer_tablepanel.TabIndex = 1;
            // 
            // dropdown_panel
            // 
            this.dropdown_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(185)))));
            this.dropdown_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dropdown_panel.Location = new System.Drawing.Point(3, 3);
            this.dropdown_panel.Name = "dropdown_panel";
            this.dropdown_panel.Size = new System.Drawing.Size(1045, 64);
            this.dropdown_panel.TabIndex = 0;
            // 
            // center_uc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outer_tablepanel);
            this.Name = "center_uc";
            this.Size = new System.Drawing.Size(1051, 704);
            this.outer_tablepanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel outer_tablepanel;
        private Guna.UI2.WinForms.Guna2Panel dropdown_panel;
    }
}
