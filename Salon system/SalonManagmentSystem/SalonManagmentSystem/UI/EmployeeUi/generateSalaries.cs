using SalonManagmentSystem.BL;
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

namespace SalonManagmentSystem.UI.EmployeeUi
{
    public partial class generateSalaries : UserControl
    {
        public generateSalaries()
        {
            InitializeComponent();
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(month_cb.SelectedItem);
            int year = Convert.ToInt32(year_cb.SelectedItem);
            var con = Configuration.getInstance().getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("InsertInSalonSalary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@Year", year);

                if(con.State != ConnectionState.Open)
                    con.Open();
                int newSalaryID = Convert.ToInt32(cmd.ExecuteScalar());

                if (newSalaryID > 0)
                {
                    MessageBox.Show("Salon salary record added successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close(); // Close the connection
                addDataToTable(); // Call the method to add data to the table (assuming it's defined elsewhere)
            }
        }

        private void addDataToTable()
        {
            try
            {
                int month = Convert.ToInt32(month_cb.SelectedItem);
                int year = Convert.ToInt32(year_cb.SelectedItem);

                var con = Configuration.getInstance().getConnection();

                // Create a new SqlCommand for calling the stored procedure
                SqlCommand cmd = new SqlCommand("GetEmployeeSalariesByMonthYear", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);

                // Create a SqlDataAdapter to fill the DataTable
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Bind the DataTable to the DataGridView
                att_gv.DataSource = dt;
                att_gv.Columns["id"].Visible = false;


                // Loop through the rows and set the default value for the "Fine" column
                foreach (DataGridViewRow row in att_gv.Rows)
                {
                    DataGridViewTextBoxCell fineCell = row.Cells["Fine"] as DataGridViewTextBoxCell;
                    fineCell.Value = "0"; // Set the default value for the "Fine" column
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void all_btn_Click(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(month_cb.SelectedItem);
            int year = Convert.ToInt32(year_cb.SelectedItem);
            int salaryId = SalaryDL.FindSalaryId(month, year);

            try
            {
                // Loop through each row in the DataGridView
                foreach (DataGridViewRow row in att_gv.Rows)
                {
                    // Retrieve the employee ID and fine from the current row
                    int employeeId = Convert.ToInt32(row.Cells["id"].Value);
                    decimal fine = Convert.ToDecimal(row.Cells["Fine"].Value);
                    decimal amount = Convert.ToDecimal(row.Cells["salary"].Value);

                    // Check if the salary is already transferred for this employee in the selected month and year
                    if (!SalaryDL.IsSalaryTransferred(employeeId, month, year))
                    {
                        // If the salary is not transferred, create a new EmployeeSalary object
                        EmployeeSalary employeeSalary = new EmployeeSalary(salaryId, employeeId, DateTime.Now, amount, fine, Convert.ToDecimal(row.Cells["attendancePercentage"].Value));

                        // Pay the employee salary
                        SalaryDL.InsertEmployeeSalary(employeeSalary);
                    }
                }
                // Clear the DataGridView
                att_gv.DataSource = null;
                att_gv.Rows.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void att_gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == att_gv.Columns["Paid"].Index && e.RowIndex >= 0)
            {
                // Retrieve the employee ID from the clicked row
                int employeeId = Convert.ToInt32(att_gv.Rows[e.RowIndex].Cells["id"].Value);

                // Get the selected month and year
                int month = Convert.ToInt32(month_cb.SelectedItem);
                int year = Convert.ToInt32(year_cb.SelectedItem);
                int salaryId = SalaryDL.FindSalaryId(month, year);

                // Check if the salary is already transferred for this employee in the selected month and year
                if (!SalaryDL.IsSalaryTransferred(employeeId, month, year))
                {
                    // Retrieve the salary ID for the selected month and year

                    // Retrieve the employee's record from the DataGridView
                    DataGridViewRow selectedRow = att_gv.Rows[e.RowIndex];

                    // Retrieve necessary information from the selected row
                    decimal amount = Convert.ToDecimal(selectedRow.Cells["salary"].Value);
                    decimal fine = Convert.ToDecimal(selectedRow.Cells["Fine"].Value);
                    decimal attendancePercentage = Convert.ToDecimal(selectedRow.Cells["attendancePercentage"].Value);

                    // Create an EmployeeSalary object
                    EmployeeSalary employeeSalary = new EmployeeSalary(salaryId, employeeId, DateTime.Now, amount, fine, attendancePercentage);

                    // Pay the employee salary
                    SalaryDL.InsertEmployeeSalary(employeeSalary);

                    // Remove the row from the DataGridView
                    att_gv.Rows.RemoveAt(e.RowIndex);

                    MessageBox.Show("Employee salary transferred successfully.");
                }
                else
                {
                    MessageBox.Show("Employee salary has already been transferred.");
                }
            }
        }
    }
}
