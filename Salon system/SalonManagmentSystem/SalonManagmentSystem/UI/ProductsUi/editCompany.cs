using SalonManagmentSystem.BL;
using SalonManagmentSystem.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonManagmentSystem.UI.ProductsUi
{
    public partial class editCompany : UserControl
    {
        public static string parameter1 = "";
        public editCompany()
        {
            InitializeComponent();
            populate();
        }
        public void populate()
        {
            productGrid.DataSource = companyDL.populate();
            foreach (DataGridViewColumn column in productGrid.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void productGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {

                    string parameter1 = productGrid.Rows[e.RowIndex].Cells[2].Value?.ToString();
                    string parameter2 = productGrid.Rows[e.RowIndex].Cells[3].Value?.ToString();

                    companyDL.deleteCompany(GetCompany(parameter1, parameter2));
                    populate();
                }



            }
            if (e.ColumnIndex == 0)
            {
                addCompany s = new addCompany();

                s.GetButton().Text = "update";
                s.GetLabel().Text = "Update Company ";
                parameter1 = productGrid.Rows[e.RowIndex].Cells[2].Value?.ToString();

                s.GetTextBox().Text = parameter1;


                popUpForm f1 = new popUpForm();
                Panel p = s.GetMainPanel();
                f1.Add(s, p);

                f1.FormClosed += popUpForm_Closed;
                f1.Show();
            }
        }
        private void popUpForm_Closed(object sender, FormClosedEventArgs e)
        {
            populate();
        }
        public static string nameApproach()
        {
            return parameter1;
        }
        public company GetCompany(string parameter1, string parameter2)
        {
            company c = new company(parameter1, parameter1, DateTime.Now);
            return c;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void enter_btn_Click(object sender, EventArgs e)
        {
            string searchTerm = name_tb.Text;

            // Perform search
            if (!string.IsNullOrEmpty(searchTerm))
            {
                productGrid.ClearSelection();

                DataTable filteredData = ((DataTable)productGrid.DataSource).Clone();
                foreach (DataRow row in ((DataTable)productGrid.DataSource).Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        if (item != null && item.ToString().IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            filteredData.ImportRow(row);
                            break;
                        }
                    }
                }

                productGrid.DataSource = filteredData;
            }
            else
            {
                populate();
            }
        }

    }
}
