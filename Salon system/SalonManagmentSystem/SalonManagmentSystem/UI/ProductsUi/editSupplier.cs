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
    public partial class editSupplier : UserControl
    {
        int ownerActive;
        public static string parameter1 = "";
        public editSupplier(int ownerActive)
        {
            InitializeComponent();
            populate();
            this.ownerActive = ownerActive;
        }

        public void populate()
        {
            productGrid.DataSource= supplierDL.viewSupplier();

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
                    supplierDL.deleteSupplier(inputs(parameter1, parameter2));
                    populate();
                }

            }
            if(e.ColumnIndex == 0)
            {
                addSupplier s = new addSupplier(ownerActive);
                
                s.GetAddButton().Text = "update";
               s.getlabel().Text = "Update Supplier ";
                 parameter1 = productGrid.Rows[e.RowIndex].Cells[2].Value?.ToString();
                string parameter2 = productGrid.Rows[e.RowIndex].Cells[3].Value?.ToString();
                string parameter3 = productGrid.Rows[e.RowIndex].Cells[4].Value?.ToString();
                if (!string.IsNullOrEmpty(parameter2))
                {
                    int commaIndex = parameter2.IndexOf(',');
                    if (commaIndex != -1)
                    {
                        parameter2 = parameter2.Substring(0, commaIndex).Trim();
                    }
                }
                s.getName().Text = parameter1;
                s.Address().Text=parameter2;
                s.Contact().Text = parameter3;

                popUpForm f1 = new popUpForm();
                Panel p = s.GetMainPanel();
                f1.Add(s, p);
              
                f1.FormClosed += popUpForm_Closed; // Subscribe to FormClosed event
                f1.Show();

            }
        }
        private void popUpForm_Closed(object sender, FormClosedEventArgs e)
        {
            populate();
        }


        public supplier inputs(string p1, string p2)
        {
            supplier s = new supplier(p1, p2, DateTime.Now);
            return s;
        }
        public  static string nameapproach()
        {
            
            return parameter1;
        }
        private void enter_btn_Click(object sender, EventArgs e)
        {

        }

        private void enter_btn_Click_1(object sender, EventArgs e)
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
