using SalonManagmentSystem.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagmentSystem.DL
{
    public class SalaryDL
    {
        public static int FindSalaryId(int month, int year)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                // Retrieve the salary ID based on the month and year
                SqlCommand salaryIdCmd = new SqlCommand("SELECT id FROM SalonSalary WHERE month = @month AND year = @year", con);
                salaryIdCmd.Parameters.AddWithValue("@month", month);
                salaryIdCmd.Parameters.AddWithValue("@year", year);

                if (con.State != ConnectionState.Open)
                    con.Open();

                int salaryId = Convert.ToInt32(salaryIdCmd.ExecuteScalar());
                return salaryId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error finding salary ID: " + ex.Message);
            }
        }

        public static void InsertEmployeeSalary(EmployeeSalary employeeSalary)
        {
                var con = Configuration.getInstance().getConnection();
            try
            {

                // Call the stored procedure
                using (SqlCommand cmd = new SqlCommand("InsertEmployeeSalary", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeSalary.EmployeeId);
                    cmd.Parameters.AddWithValue("@SalaryId", employeeSalary.SalaryId);
                    cmd.Parameters.AddWithValue("@TransferredOn", employeeSalary.TransferredOn);
                    cmd.Parameters.AddWithValue("@Amount", employeeSalary.Amount);
                    cmd.Parameters.AddWithValue("@Fine", employeeSalary.Fine);
                    cmd.Parameters.AddWithValue("@AttendancePercentage", employeeSalary.AttendancePercentage);

                    if(con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting employee salary: " + ex.Message);
            }
            finally
            {
                con.Close(); // Close the connection
            }
        }


        public static bool IsSalaryTransferred(int employeeId, int month, int year)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM EmployeeSalary WHERE employeeId = @employeeId AND MONTH(transferredOn) = @month AND YEAR(transferredOn) = @year", con);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                if (con.State != ConnectionState.Open)
                    con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking salary transfer status: " + ex.Message);
            }
        }
    }
}
