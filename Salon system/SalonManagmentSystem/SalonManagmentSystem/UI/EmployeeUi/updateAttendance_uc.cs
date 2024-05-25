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

namespace SalonManagmentSystem.UI.CustomersUi
{
    public partial class updateAttendance_uc : UserControl
    {
        public updateAttendance_uc()
        {
            InitializeComponent();
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime attendanceDate = attendance_dtp.Value;
                DataTable dt = EmployeeDL.GetEmployeeAttendanceByDate(attendanceDate);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No records found for this date.");
                }
                else
                {
                    att_gv.DataSource = dt;
                    att_gv.Columns["employeeID"].Visible = false;
                    att_gv.Columns["attendanceID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void emp_gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked cell is the "Update" button
                if (e.ColumnIndex == att_gv.Columns["Update"].Index && e.RowIndex >= 0)
                {
                    // Get the necessary information about the selected attendance record from the DataGridView
                    int attendanceID = Convert.ToInt32(att_gv.Rows[e.RowIndex].Cells["attendanceID"].Value);
                    int employeeID = Convert.ToInt32(att_gv.Rows[e.RowIndex].Cells["employeeID"].Value);
                    string status = att_gv.Rows[e.RowIndex].Cells["status"].Value.ToString();
                    string name = att_gv.Rows[e.RowIndex].Cells["name"].Value.ToString();

                    // Open a form or dialog window for updating the attendance record
                    // Pass the retrieved information (attendance ID, employee ID, etc.) to the update form
                    updtAttendPopUp updateForm = new updtAttendPopUp(attendanceID, employeeID, name, status);
                    updateForm.ShowDialog();

                    // Refresh the data after the update
                    show_btn_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
