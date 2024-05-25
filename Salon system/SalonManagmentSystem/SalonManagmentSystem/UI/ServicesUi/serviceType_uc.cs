using SalonManagmentSystem.DL;
using SalonManagmentSystem.UI.EmployeeUi;
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

namespace SalonManagmentSystem.UI.ServicesUi
{
    public partial class serviceType_uc : UserControl
    {
        public serviceType_uc()
        {
            InitializeComponent();
            PopulateTypesGridView();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            string typeName = name_tb.Text.Trim();
            if (!validateInput())
                return;

            // Check if the type name is not empty
            if (!string.IsNullOrEmpty(typeName))
            {
                // Check if the type already exists in the database
                if (ServiceDL.CheckServiceTypeAlreadyExists(typeName))
                    return;

                    // Insert the new role into the database
                string insertQuery = $"INSERT INTO Lookup (category, value) VALUES ('servicetype', '{typeName.ToLower()}')";

                // Execute the insert query
                int rowsAffected = DataHandler.ExecuteNonQuery(insertQuery);

                // Check if the insertion was successful
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Service type added successfully.");
                    // Refresh the roles grid view to reflect the changes
                    PopulateTypesGridView();
                    // Clear the text box after adding the role
                    name_tb.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to add type. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Service type name cannot be empty.");
            }
        }

        private void PopulateTypesGridView()
        {
            // Define the query to fetch roles from the lookup table excluding the owner role
            string query = "SELECT lookupid, category, value as ServiceType FROM Lookup WHERE category = 'servicetype'";

            // Execute the query to fetch roles
            DataTable typesData = DataHandler.ExecuteQuery(query);

            // Bind the fetched data to the DataGridView
            serviceType_gv.DataSource = typesData;
            serviceType_gv.Columns["lookupId"].Visible = false;
            serviceType_gv.Columns["category"].Visible = false;
            foreach (DataGridViewColumn column in serviceType_gv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string typeName = name_tb.Text;
            string query = $"SELECT lookupid, category, value as ServiceType FROM Lookup WHERE category = 'servicetype' AND value LIKE '%{typeName}%'";
            DataTable filteredTypesData = DataHandler.ExecuteQuery(query);
            serviceType_gv.DataSource = filteredTypesData;
            serviceType_gv.Columns["lookupId"].Visible = false;
            serviceType_gv.Columns["category"].Visible = false;
        }

        private void serviceType_gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == serviceType_gv.Columns["Update"].Index)
                {
                    // Handle update button click
                    DataGridViewRow selectedRow = serviceType_gv.Rows[e.RowIndex];
                    // Extract data from the selected row and pass it to the update form
                    int typeId = Convert.ToInt32(selectedRow.Cells["lookupid"].Value);
                    // Call method to open update form with employee data
                    typeUpdate updateForm = new typeUpdate(typeId);
                    updateForm.Show();
                }
                if (e.ColumnIndex == serviceType_gv.Columns["Delete"].Index)
                {
                    // Handle update button click
                    DataGridViewRow selectedRow = serviceType_gv.Rows[e.RowIndex];
                    // Extract data from the selected row and pass it to the update form
                    int typeId = Convert.ToInt32(selectedRow.Cells["lookupid"].Value);
                    try
                    {
                        // Delete record from database
                        var connection = Configuration.getInstance().getConnection();
                        {
                            if(connection.State != ConnectionState.Open) { connection.Open(); }
                            
                            using (SqlCommand command = new SqlCommand("DELETE FROM Lookup WHERE lookupId = @typeId", connection))
                            {
                                command.Parameters.AddWithValue("@typeId", typeId);
                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Refresh or update DataGridView if needed
                                    PopulateTypesGridView();
                                }
                                else
                                {
                                    MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void name_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name_tb.Text))
                PopulateTypesGridView();
        }
        private bool validateInput()
        {
            if (validations.IsAlphaWithoutSpaces(name_tb.Text))
            {
                MessageBox.Show("Service Type can be only aphabets.");
                return false;
            }
            return true;
        }
    }
}
