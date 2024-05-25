using iTextSharp.text;
using SalonManagmentSystem.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonManagmentSystem.UI.ProductsUi
{
    public partial class orderDetails : UserControl
    {
        int ownerActive;
        List<string> list = new List<string>();
        public orderDetails(int ownerActive)
        {
            InitializeComponent();
           // productGrid.Rows[1].Cells["Status"].Value = "Status";
            this.ownerActive = ownerActive;
            populate();
            

        }
        public void populate()
        {
            // Get data from viewOrderDetails()
            DataTable orderDetails = productDL.viewOrderDetails();

            // Set the modified DataTable as the DataSource
            productGrid.DataSource = orderDetails;

            // Assuming list contains strings, add the additional data to the DataTable


            // Adjust column widths
            foreach (DataGridViewColumn column in productGrid.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            productGrid.DataBindingComplete += (sender, e) =>
            {
                // Call PopulateTextBoxes() after the DataGridView is fully populated
                PopulateTextBoxes();
            };
        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void productGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==0) 
            {
                string parameter1 = productGrid.Rows[e.RowIndex].Cells[2].Value?.ToString();
                string parameter2 = productGrid.Rows[e.RowIndex].Cells[4].Value?.ToString();
                purchase f1 = new purchase(ownerActive, parameter1, parameter2);
                popUpForm f = new popUpForm();
                Panel p = f1.GetMainPanel();
                f.Add(f1, p);
                
                f.Show();
               f.FormClosed += popUpForm_Closed;

            }
        }
        private void popUpForm_Closed(object sender, FormClosedEventArgs e)
        {
            PopulateTextBoxes();
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
        public void PopulateTextBoxes()
        {
            var connection = Configuration.getInstance().getConnection();
            if (connection.State != ConnectionState.Open) { connection.Open(); }

            string query = @"
        SELECT
            CASE
                WHEN p.TotalQuantity IS NULL THEN 'Empty'
                WHEN od.Quantity = p.TotalQuantity THEN 'Completed'
                ELSE 'Partially Completed'
            END AS Status
        FROM
            OrderDetails od
        LEFT JOIN (
            SELECT
                OrderID,
                SUM(Quantity) AS TotalQuantity
            FROM
                Purchase
            GROUP BY
                OrderID
        ) p ON od.Id = p.orderid";

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int rowIndex = 0;
                while (reader.Read())
                {
                    // Check if the current row index is within the bounds of the DataGridView's row count
                    if (rowIndex < productGrid.Rows.Count)
                    {
                        string orderStatus = reader.GetString(0);
                        list.Add(orderStatus);

                        // Set the cell value of the "Status" column in the current row
                        productGrid.Rows[rowIndex].Cells["Status"].Value = orderStatus;
                       
                        rowIndex++;
                    }
                }

                    reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if an exception occurs
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }



    }
}
