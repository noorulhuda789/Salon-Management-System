using SalonManagmentSystem.BL;
using SalonManagmentSystem.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonManagmentSystem.UI.ProductsUi
{
    public partial class editprodoductType : UserControl
    {
        public static string parameter1 = "";
        public editprodoductType()
        {
            InitializeComponent();
            populate();
        }
        public void populate()
        {
            productGrid.DataSource = productTypeDl.viewProductType();
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

        private void productGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0) {
                addProductType p=new addProductType();
                p.GetButton().Text = "update";
                p.GetLabel().Text = "Update Product Type";
                 parameter1 = productGrid.Rows[e.RowIndex].Cells[2].Value?.ToString();
                string parameter2 = productGrid.Rows[e.RowIndex].Cells[3].Value?.ToString();
                p.GetTextBox().Text = parameter1;
                p.Getd().Text = parameter2;

                popUpForm f1 = new popUpForm();
                Panel pa = p.GetMainPanel();
                f1.Add(p, pa);

                f1.FormClosed += popUpForm_Closed;
                f1.Show();

            }
            if(e.ColumnIndex == 1) {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {

                    string parameter1 = productGrid.Rows[e.RowIndex].Cells[2].Value?.ToString();
                    string parameter2 = productGrid.Rows[e.RowIndex].Cells[3].Value?.ToString();

                    productTypeDl.deleteType(GetCompany(parameter1, parameter2));
                    populate();
                }
            }
            
        }
        private void popUpForm_Closed(object sender, FormClosedEventArgs e)
        {
            populate();
        }
        public  ProductsType GetCompany(string p1,string p2)
        {
            ProductsType p = new ProductsType(p1, DateTime.Now, p2);
            return p;
        }
        public static string nameApproach()
        {
            return parameter1;
        }
    }
}
