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

namespace SalonManagmentSystem.UI.Notifications
{
    public partial class notifications_uc : UserControl
    {
        private int receiverId;
        public notifications_uc(int receiverId)
        {
            InitializeComponent();
            this.receiverId = receiverId;
            PopulateGridView();
           
        }

        
        private int GetOwnerId()
        {
            int ownerId=0;
            try
            {
                string query = "SELECT id FROM Person WHERE role = (SELECT lookupId FROM Lookup WHERE category = 'role' AND value = 'owner')";

                var connection = Configuration.getInstance().getConnection();
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                var command = new SqlCommand(query, connection);
                 ownerId = (int)command.ExecuteScalar();

                connection.Close();

               


            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);
            }
            return ownerId;
        }
        private void PopulateGridView()
        {
            try
            {
                // Create a DataTable to store the results
                DataTable dataTable = new DataTable();

                // Define your SQL query
                string query = $"SELECT\r\n    " +
                    $"CASE" +
                    $"     WHEN n.sentBy = -1 " +
                    $"      THEN 'System'" +
                    $"      ELSE p.name + ' - ' + l.value " +
                    $"END AS sentBy, " +
                    $"n.message, n.dateCreated,en.notificationId " +
                    $"FROM  Notification n  " +
                    $"JOIN  EmployeeNotification en ON n.id = en.notificationId " +
                    $"JOIN  Employee e ON n.sentBy = e.personId " +
                    $"JOIN  Person p ON n.sentBy = p.id  " +
                    $"JOIN  Lookup l ON p.role = l.lookupId  " +
                    $"WHERE    en.status = (SELECT lookupId FROM Lookup WHERE category = 'notification' AND value = 'delivered') " +
                    $"    AND en.employeeId = @EmployeeId " +
                    $"ORDER BY    n.dateCreated DESC;";


                var connection = Configuration.getInstance().getConnection();
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                // Create a SqlDataAdapter with the query and connection
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    // Add parameter for employeeId
                    adapter.SelectCommand.Parameters.AddWithValue("@EmployeeId", receiverId);
                    // Fill the DataTable with the results from the query
                    adapter.Fill(dataTable);
                }

                // Bind the DataTable to the DataGridView
                emp_gv.DataSource = dataTable;
                if (emp_gv.Columns.Contains("notificationId"))
                    emp_gv.Columns["notificationId"].Visible = false;
                foreach (DataGridViewColumn column in emp_gv.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void name_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name_tb.Text))
                PopulateGridView();
        }

        private void enter_btn_Click(object sender, EventArgs e)
        {
            string searchText = name_tb.Text.Trim(); // Get the search text

            if (!string.IsNullOrEmpty(searchText))
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                string query = $"SELECT\r\n    " +
                    $"CASE" +
                    $"     WHEN n.sentBy = -1 " +
                    $"      THEN 'System'" +
                    $"      ELSE p.name + ' - ' + l.value " +
                    $"END AS sentBy, " +
                    $"n.message, n.dateCreated,en.notificationId " +
                    $"FROM  Notification n  " +
                    $"JOIN  EmployeeNotification en ON n.id = en.notificationId " +
                    $"JOIN  Employee e ON n.sentBy = e.personId " +
                    $"JOIN  Person p ON n.sentBy = p.id  " +
                    $"JOIN  Lookup l ON p.role = l.lookupId  " +
                    $"WHERE    en.status = (SELECT lookupId FROM Lookup WHERE category = 'notification' AND value = 'delivered') " +
                    $"    AND en.employeeId = @EmployeeId And message LIKE @searchText " +
                    $"ORDER BY    n.dateCreated DESC ";
                parameters.Add("@searchText", "%" + searchText + "%");
                parameters.Add("@EmployeeId", receiverId);
                DataTable result = DataHandler.ExecuteQuery(query, parameters);

                //Display result it in a DataGridView
                emp_gv.DataSource = result;
                if (emp_gv.Columns.Contains("id"))
                    emp_gv.Columns["id"].Visible = false;
            }
            else
            {
                utils.ShowMessage("Please select a filter and enter search text.", "Incomplete Input");
            }
        }

        private void emp_gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == emp_gv.Columns["Delete"].Index)
            {
                DataGridViewRow selectedRow = emp_gv.Rows[e.RowIndex];
                string name = selectedRow.Cells[2].Value.ToString(); // Assuming the name is in cell index 1
                DateTime role = Convert.ToDateTime(selectedRow.Cells[3].Value); // Assuming the role is in cell index 2

                if (NotificationDL.DeleteNotification(name, role) != -1)
                {
                    MessageBox.Show("Notification deleted successfully!");
                    PopulateGridView();
                }
                else
                {
                    MessageBox.Show("Failed to delete notification.");
                }
            }

        }
    }
}
