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
    public partial class viewSalaries_uc : UserControl
    {
        public viewSalaries_uc()
        {
            InitializeComponent();
        }

        private void month_cb_TextChanged(object sender, EventArgs e)
        {
            if(month_cb.SelectedIndex <= 0 && year_cb.SelectedIndex <= 0)
            emp_gv.DataSource = null;
        }

        private void view_btn_Click(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(month_cb.SelectedItem);
            int year = Convert.ToInt32(year_cb.SelectedItem);
            int salaryId = SalaryDL.FindSalaryId(month, year);

            // Create a connection
            var con = Configuration.getInstance().getConnection();
            // Create a command to execute the stored procedure
            SqlCommand cmd = new SqlCommand("GetEmployeeSalariesBySalaryId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@salaryId", salaryId);

            // Create a data adapter and fill the DataTable
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Check if the DataTable is empty
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No salaries found for the selected month and year.");
                }
                else
                {
                    // Bind the DataTable to the DataGridView
                    emp_gv.DataSource = dt;
                    emp_gv.Columns["employeeId"].Visible = false;
                }
            }
            foreach (DataGridViewColumn column in emp_gv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
