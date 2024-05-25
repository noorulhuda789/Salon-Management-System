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

namespace SalonManagmentSystem.UI.CustomersUi
{
    public partial class updtAttendPopUp : Form
    {
        public updtAttendPopUp()
        {
            InitializeComponent();
        }

        public updtAttendPopUp(int attendanceID, int employeeID, string name, string status)
        {
            InitializeComponent();
            AttendanceID = attendanceID;
            EmployeeID = employeeID;
            name_lbl.Text = "Employee Name: " + name;
            status_lbl.Text = "Old Status: " + status;
 
        }

        public int AttendanceID { get; }
        public int EmployeeID { get; }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveUpdated_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (status_cb.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a new status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string newStatus = status_cb.SelectedItem.ToString();

                // Update the attendance record in the database
                EmployeeDL.UpdateEmployeeAttendance(AttendanceID, EmployeeID, newStatus);

                MessageBox.Show("Attendance record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the attendance record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
