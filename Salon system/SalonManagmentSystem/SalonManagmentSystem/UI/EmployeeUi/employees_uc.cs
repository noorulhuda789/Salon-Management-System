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

namespace SalonManagmentSystem.UI.EmployeeUi
{
    public partial class employees_uc : UserControl
    {
        private int ownerId;
        public employees_uc(int ownerId)
        {
            InitializeComponent();
            RefreshGridView();
            this.ownerId = ownerId;
        }
        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            // Refresh grid view when search text becomes empty
            if (string.IsNullOrEmpty(search_tb.Text))
            {
                RefreshGridView();
            }
        }
        public void RefreshGridView()
        {
            try
            {
                // Call the view to get all data of employees
                string query = "SELECT * FROM vw_AllEmployees";
                DataTable result = DataHandler.ExecuteQuery(query);

                // Bind the result to DataGridView
                employee_gv.DataSource = result;
                if (employee_gv.Columns.Contains("id"))
                    employee_gv.Columns["id"].Visible = false;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            foreach (DataGridViewColumn column in employee_gv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


        private void enter_btn_Click(object sender, EventArgs e)
        {
            string filter = filter_cb.SelectedItem?.ToString(); // Get the selected filter
            string searchText = search_tb.Text.Trim(); // Get the search text

            if (!string.IsNullOrEmpty(filter) && !string.IsNullOrEmpty(searchText))
            {
                try
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    // For other columns, use LIKE operator
                    string query = $"SELECT P.id, P.name, P.email, P.address, P.city, P.country, P.phone, L1.value AS gender, L2.value AS role, E.username, E.salary, E.joiningDate, E.updatedOn  FROM   dbo.Employee AS E   INNER JOIN  dbo.Person AS P ON E.personId = P.id  INNER JOIN  dbo.Lookup AS L1 ON P.gender = L1.lookupId AND L1.category = 'gender'  INNER JOIN  dbo.Lookup AS L2 ON P.role = L2.lookupId AND L2.category = 'role' WHERE  L2.value <> 'owner' AND {filter} LIKE @searchText";
                    parameters.Add("@searchText", "%" + searchText + "%");

                    DataTable result = DataHandler.ExecuteQuery(query, parameters);

                    //Display result it in a DataGridView
                    employee_gv.DataSource = result;
                    if (employee_gv.Columns.Contains("id"))
                        employee_gv.Columns["id"].Visible = false;
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show(ex.Message); 
                }
            }
            else
            {
                utils.ShowMessage("Please select a filter and enter search text.","Incomplete Input");
            }
        }

      
        private void employee_gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == employee_gv.Columns["Update"].Index)
                {
                    // Handle update button click
                    DataGridViewRow selectedRow = employee_gv.Rows[e.RowIndex];
                    // Extract data from the selected row and pass it to the update form
                    string employeeId = selectedRow.Cells["id"].Value.ToString();
                    // Call method to open update form with employee data
                    updateEmp updateForm = new updateEmp(employeeId);
                    updateForm.ShowDialog();
                    RefreshGridView();

                }
                else if (e.ColumnIndex == employee_gv.Columns["Delete"].Index)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Change Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DataGridViewRow selectedRow = employee_gv.Rows[e.RowIndex];
                        string employeeId = selectedRow.Cells["id"].Value.ToString();

                        // Call method to change the status of the employee
                        int rowsAffected = EmployeeDL.DeleteEmployeeById(employeeId);
                        if (rowsAffected > 0)
                        {
                            NotifyReceptionists(employeeId);
                            MessageBox.Show("Employee status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshGridView(); // Refresh the grid view after updating
                        }
                        else
                        {
                            MessageBox.Show("Failed to update employee status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
        }
        private void NotifyReceptionists(string employeeId)
        {
            List<int> appIds = EmployeeDL.CheckEmployeeInAppointments(Convert.ToInt32(employeeId));
            if (appIds.Count > 0)
            {
                if (EmployeeDL.SendNotificationToReceptionist(ownerId, employeeId, appIds))
                {
                    MessageBox.Show("Notification has been sent to receptionists to manage this employee's appointments.");
                }
            }
        }
    }
}
