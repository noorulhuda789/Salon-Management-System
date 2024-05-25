using SalonManagmentSystem.DL;
using SalonManagmentSystem.UI.ServicesUi;
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

namespace SalonManagmentSystem.UI.CustomersUi
{
    public partial class userRoles_uc : UserControl
    {
        public userRoles_uc()
        {
            InitializeComponent();
            PopulateRolesGridView();
        }

        private void PopulateRolesGridView()
        {
            // Define the query to fetch roles from the lookup table excluding the owner role
            string query = "SELECT lookupid, category, value as Role FROM Lookup WHERE category = 'role' AND value <> 'owner'";

            // Execute the query to fetch roles
            DataTable rolesData = DataHandler.ExecuteQuery(query);

            // Bind the fetched data to the DataGridView
            role_gv.DataSource = rolesData;
            role_gv.Columns["lookupId"].Visible = false;
            role_gv.Columns["category"].Visible = false;
            foreach (DataGridViewColumn column in role_gv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void employee_gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == role_gv.Columns["Delete"].Index)
            {
                // Handle delete button click
                DataGridViewRow selectedRow = role_gv.Rows[e.RowIndex];
                // Extract data from the selected row
                int typeId = Convert.ToInt32(selectedRow.Cells["lookupId"].Value);
                try
                {
                    // Check if the role is assigned to any person
                    bool isRoleAssigned = CheckIfRoleAssigned(typeId);

                    if (!isRoleAssigned)
                    {
                        // Delete record from database
                        using (var connection = Configuration.getInstance().getConnection())
                        {
                            if (connection.State != ConnectionState.Open) { connection.Open(); }

                            using (SqlCommand command = new SqlCommand("DELETE FROM Lookup WHERE lookupId = @typeId", connection))
                            {
                                command.Parameters.AddWithValue("@typeId", typeId);
                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Refresh or update DataGridView if needed
                                    PopulateRolesGridView();
                                }
                                else
                                {
                                    MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("This role is assigned to one or more persons and cannot be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool CheckIfRoleAssigned(int typeId)
        {
            bool isRoleAssigned = false;
            string query = "SELECT COUNT(*) FROM Person WHERE role = (Select lookupId from Lookup Where lookupId = @typeId)";


            using (var connection = Configuration.getInstance().getConnection())
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@typeId", typeId);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                        isRoleAssigned = true;
                }
            }

            return isRoleAssigned;
        }



        private void add_btn_Click(object sender, EventArgs e)
        {
            // Get the role name from the user input
            string roleName = name_tb.Text.Trim();

            if (!validateInput())
                return;
            // Check if the role name is not empty
            if (!string.IsNullOrEmpty(roleName))
            {
                if (roleName.ToLower() == "owner")
                {
                    MessageBox.Show("You cannot add the 'owner' role.");
                    return;
                }

                // Check if the role already exists in the database
                string checkExistingQuery = $"SELECT COUNT(*) FROM Lookup WHERE category = 'role' AND value = '{roleName}'";
                int existingCount = (int)DataHandler.ExecuteNonQuery(checkExistingQuery);

                if (existingCount > 0)
                {
                    MessageBox.Show("Role already exists.");
                    return;
                }


                // Insert the new role into the database
                string insertQuery = $"INSERT INTO Lookup (category, value) VALUES ('role', '{roleName}')";

                // Execute the insert query
                int rowsAffected = DataHandler.ExecuteNonQuery(insertQuery);

                // Check if the insertion was successful
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Role added successfully.");
                    // Refresh the roles grid view to reflect the changes
                    PopulateRolesGridView();
                    // Clear the text box after adding the role
                    name_tb.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to add role. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Role name cannot be empty.");
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string roleName = name_tb.Text;
            string query = $"SELECT * FROM Lookup WHERE category = 'role' AND value <> 'owner' AND value LIKE '%{roleName}%'";
            DataTable filteredRolesData = DataHandler.ExecuteQuery(query);
            role_gv.DataSource = filteredRolesData;
            role_gv.Columns["lookupId"].Visible = false;
        }

        private void name_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name_tb.Text))
                PopulateRolesGridView();
        }
        private bool validateInput()
        {
            if(!validations.IsAlphaWithoutSpaces(name_tb.Text))
            {
                MessageBox.Show("Role can be only aphabets.");
                return false;
            }
            return true;
        }

    }
}
