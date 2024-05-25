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

namespace SalonManagmentSystem.UI.ServicesUi
{
    public partial class addServiceProducts : Form
    {
        public List<int> ProductIds { get; private set; } = new List<int>();

        private List<int> productIds = new List<int>();
        public addServiceProducts()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addProd_btn_Click(object sender, EventArgs e)
        {
            string name = name_tb.Text.Trim();



            // Check if the product exists
            string query = "SELECT id, name FROM Product WHERE name = @name AND isdeleted = (SELECT lookupId from Lookup Where category = 'isdeleted' and value = 'no')";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@name"] = name;

            DataTable result = DataHandler.ExecuteQuery(query, parameters);

            // If the product exists, add its ID to the list
            if (result.Rows.Count > 0)
            {
                int productId = Convert.ToInt32(result.Rows[0]["id"]);

                // Add the product to the list of product IDs
                productIds.Add(productId);

                // Add the product details to the DataGridView
                DataRow row = result.Rows[0];
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = productId }); // Add to Product ID column
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = row["name"] }); // Add to Product Name column
                prod_gv.Rows.Add(dataGridViewRow);
            }
            else
            {
                MessageBox.Show("Product not found.");
            }
        }

        private void prod_gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the "Remove" button column
            if (e.ColumnIndex == prod_gv.Columns["Remove"].Index && e.RowIndex >= 0)
            {
                MessageBox.Show("" + prod_gv.Rows[e.RowIndex].Cells["id"].Value.ToString());
                // Retrieve the product ID from the corresponding row
                int productId = Convert.ToInt32(prod_gv.Rows[e.RowIndex].Cells["id"].Value);

                // Remove the product ID from the list
                productIds.Remove(productId);

                // Remove the corresponding row from the DataGridView
                prod_gv.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void saveUpdated_btn_Click(object sender, EventArgs e)
        {
            // Store the list of product IDs
            ProductIds = productIds;

            // Close the form
            this.Close();
        }
        private void InitializeDataGridView()
        {
            // Add columns to the DataGridView
            prod_gv.Columns.Add("id", "Product ID"); // Column for productId
            prod_gv.Columns.Add("name", "Product Name"); // Column for product name

            // Add button column for deleting rows
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "Remove";
            buttonColumn.HeaderText = "Remove";
            buttonColumn.Text = "Remove";
            buttonColumn.UseColumnTextForButtonValue = true;
            prod_gv.Columns.Add(buttonColumn);
        }
    }
}
