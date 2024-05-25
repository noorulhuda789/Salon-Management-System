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
    public partial class markAttendance_uc : UserControl
    {
        public markAttendance_uc()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            att_gv.DataSource = null;
        }
        public void addDataToTable()
        {
              DateTime attendanceDate = attendance_dtp.Value;
             try
             {
                 var con = Configuration.getInstance().getConnection();
                 SqlCommand cmd = new SqlCommand("GetSalonAttendance", con);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@AttendanceDate", attendanceDate);
   
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 att_gv.DataSource = dt;
                 att_gv.Columns["employeeID"].Visible = false;
                 att_gv.Columns["attendanceID"].Visible = false;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
            foreach (DataGridViewColumn column in att_gv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("If not exists (select * from SalonAttendance where CONVERT(date, AttendanceDate) = CONVERT(date, @AttendanceDate)) " +
                                             "Begin " +
                                             "Insert into SalonAttendance (AttendanceDate) values (@AttendanceDate) " +
                                             "Select scope_identity() as NewAttendanceID " +
                                             "End", con);
            cmd.Parameters.AddWithValue("@AttendanceDate", attendance_dtp.Value);
            if (con.State != ConnectionState.Open)
                con.Open();
                                int newAttendanceID = Convert.ToInt32(cmd.ExecuteScalar());

            // Display a message box based on the result
            if (newAttendanceID > 0)
            {
                MessageBox.Show("Attendance record added successfully");
                addDataToTable();
            }
            else
            {
                MessageBox.Show("Attendance already marked for date: " + attendance_dtp.Value.ToShortDateString()+ "\nYou can now view it in update page");
            }
        }

        private void saveAtt_btn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in att_gv.Rows)
                {
                    var con = Configuration.getInstance().getConnection();
                    // Retrieve the AttendanceDate value from the current row
                    DateTime attendanceDate = attendance_dtp.Value;
                    // Retrieve the AttendanceID value from the current row
                    int attendanceID = Convert.ToInt32(row.Cells["attendanceID"].Value);
                    // Retrieve the EmployeeID value from the current row
                    int employeeID = Convert.ToInt32(row.Cells["employeeID"].Value);
                    string attendanceStatusText = Convert.ToString(Convert.ToString(row.Cells["Status"].Value) != "" ? Convert.ToString(row.Cells["Status"].Value) : "present");
                    // Retrieve the lookup ID for the selected attendance status text
                    int attendanceStatusID = GetLookupIDForAttendanceStatus(attendanceStatusText);

                    // Execute the query for the current row
                    SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeAttendance VALUES (@attendanceId,@empId,@AttendanceStatus)", con);
                    //here run a query to get id from lookup that wil  be stored in attendance stauts based on present absent leave late stpored in lookup table with categiry attendance status
                    cmd.Parameters.AddWithValue("@empId", employeeID);
                    cmd.Parameters.AddWithValue("@AttendanceId", attendanceID);
                    cmd.Parameters.AddWithValue("@AttendanceStatus", attendanceStatusID);

                    cmd.ExecuteNonQuery();
                }
                refresh();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        // Function to retrieve the lookup ID for the given attendance status 
        public static int GetLookupIDForAttendanceStatus(string attendanceStatusText)
        {
            int attendanceStatusID = 0;

            try
            {
                // Connect to the database
                var con = Configuration.getInstance().getConnection();

                // Define the query to retrieve the lookup ID for the given attendance status text
                string query = "SELECT lookupId FROM Lookup WHERE category = 'attendancestatus' AND value = @attendanceStatusText";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameter for the attendance status text
                    cmd.Parameters.AddWithValue("@attendanceStatusText", attendanceStatusText);

                    // Execute the query to retrieve the lookup ID
                    object result = cmd.ExecuteScalar();

                    // Check if a lookup ID was retrieved
                    if (result != null)
                    {
                        attendanceStatusID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving lookup ID for attendance status: " + ex.Message);
            }

            return attendanceStatusID;
        }

        private void att_gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
