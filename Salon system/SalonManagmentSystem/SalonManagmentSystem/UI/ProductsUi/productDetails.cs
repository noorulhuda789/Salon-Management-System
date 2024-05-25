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
    public partial class productDetails : UserControl
    {
        int ownerActive;
        public productDetails(int ownerActive)
        {
            InitializeComponent();
            populateGrid();
            this.ownerActive = ownerActive;
            populateFilter();



        }
        public void populateFilter()
        {
            List<string> filters = new List<string>();
            filters.Add("name");
            filters.Add("quantity");
            filters.Add("restock level");
            filters.Add("supplier name");
            filters.Add("product type");
            filters.Add("company name");
            filters.Add("out of stock");
            
            filter.DataSource = filters;


        }
        public  void populateGrid()
        {
           
            productGrid.DataSource = null;
            productGrid.DataSource = productDL.GetProductList();
            sizeset(productGrid);
        }
        private void sizeset(DataGridView productGrid)
        {
            for (int i = 0; i < productGrid.Columns.Count; i++)
            {
                productGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void enter_btn_Click(object sender, EventArgs e)
        {
            string errorMessage = "An error occurred:";
            try
            {
                if (!string.IsNullOrWhiteSpace(searchBar.Text))
                {
                    productGrid.DataSource = productDL.searchProduct(filter.SelectedValue.ToString(), searchBar.Text);
                }
                else
                {
                    errorMessage += "\nPlease fill in the  fields.";
                    populateGrid();
                    throw new Exception(errorMessage);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

        }

        private void emp_gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    DataGridViewRow selectedRow = productGrid.Rows[e.RowIndex];
                    productDL.deleteproduct(selectedRow.Cells[3].Value.ToString());
                    populateGrid();


                }
            }
            if (e.ColumnIndex == 2)
            {
                actions f1 = new actions(ownerActive);
                popUpForm f = new popUpForm();
                Panel p = f1.GetMainPanel();
                f.Add(f1, p);
                f.Show();
                
                f.FormClosed += popUpForm_Closed;

            }

            if (e.ColumnIndex == 0)
            {

                addProducts f = new addProducts(ownerActive);
                f.GetButton().Text = "update";
                f.GetLabel1().Text = "Update Product";
                string parameter1 = productGrid.Rows[e.RowIndex].Cells[3].Value?.ToString();
                string parameter2 = productGrid.Rows[e.RowIndex].Cells[9].Value?.ToString();
                f.addBox().Text = parameter1;
                //f.addBox().Enabled = false;
                f.restocklevelBox().Text = parameter2;
                popUpForm f1 = new popUpForm();
                Panel p = f.GetMainPanel();
                f1.Add(f, p);
                f1.Show();
                
                
                f1.FormClosed += popUpForm_Closed; // Subscribe to FormClosed event
            }


        }
        private void popUpForm_Closed(object sender, FormClosedEventArgs e)
        {
            populateGrid();
        }


    }
}
