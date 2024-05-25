using SalonManagmentSystem.BL;
using SalonManagmentSystem.UI.EmployeeUi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SalonManagmentSystem.DL
{
    public static class EmployeeDL
    {
        public static List<Employee> Employees = new List<Employee>();
        public static List<Employee> GetEmployees()
        {
            return Employees;
        }
        public static void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public static string getName(int id)
        {
            return Employees.Find(c => c.Id == id).Name;
        }
        public static int getrole(int id)
        {
            return Employees.Find(c => c.Id == id).role;
        }

        public static int getId(string name)
        {
            return Employees.Find(c => c.Name == name).Id;
        }
        public static bool AddEmployeeInDb(Person P, Employee E)
        {
            var connection = Configuration.getInstance().getConnection();
            try
            {
                using (SqlCommand command = new SqlCommand("stpAddEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", P.Name);
                    command.Parameters.AddWithValue("@email", P.Email);
                    command.Parameters.AddWithValue("@address", P.Address);
                    command.Parameters.AddWithValue("@city", P.City);
                    command.Parameters.AddWithValue("@country", "Pakistan");
                    command.Parameters.AddWithValue("@phone", P.Phone);
                    command.Parameters.AddWithValue("@gender", P.gender);
                    command.Parameters.AddWithValue("@role", P.role);
                    command.Parameters.AddWithValue("@joiningDate", E.JoiningDate);
                    command.Parameters.AddWithValue("@salary", E.Salary);
                    command.Parameters.AddWithValue("@username", E.Username);
                    command.Parameters.AddWithValue("@password", E.Password);

                    // Open the connection and execute the command
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    command.ExecuteNonQuery();
                    MessageBox.Show("Employee Added Successfully");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
        public static bool CheckUniqueUsername(string username)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Employee WHERE username = @username", con);
                checkCmd.Parameters.AddWithValue("@username", username);

                // Open the connection and execute the command
                if (con.State != ConnectionState.Open)
                    con.Open();

                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Username already taken! \nTry another username.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        public static int GetGenderFromLookup(string gender)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand checkCmd = new SqlCommand("SELECT lookupid from Lookup Where Category = 'gender' AND value = @g", con);
                checkCmd.Parameters.AddWithValue("@g", gender);
                // Open the connection and execute the command
                if (con.State != ConnectionState.Open)
                    con.Open();

                object result = checkCmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return -1;
        }

        internal static int GetRoleFromLookup(string role)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand checkCmd = new SqlCommand("SELECT lookupid from Lookup Where Category = 'role' AND value = @r and value <> 'owner' and value <> 'customer'", con);
                checkCmd.Parameters.AddWithValue("@r", role);

                // Open the connection and execute the command
                if (con.State != ConnectionState.Open)
                    con.Open();

                object result = checkCmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return -1;
        }
        public static void PopulateRoleDropdown(ComboBox comboBox)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT value FROM Lookup WHERE Category = 'role' and value <> 'owner'AND value <> 'customer'", con);
                // Open the connection and execute the command
                if (con.State != ConnectionState.Open)
                    con.Open();


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["value"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public static void PopulateGenderDropdown(ComboBox comboBox)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT value FROM Lookup WHERE Category = 'gender'", con);
                // Open the connection and execute the command
                if (con.State != ConnectionState.Open)
                    con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["value"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public static int DeleteEmployeeById(string employeeId)
        {
            int rowsAffected = -1; // Initialize rowsAffected to a default value
            var con = Configuration.getInstance().getConnection();

            try
            {

                // Define the command to call the stored procedure
                using (SqlCommand command = new SqlCommand("DeleteEmployeeById", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    // Open the connection and execute the command
                    if(con.State != ConnectionState.Open)
                         con.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }

                // Return the number of rows affected
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the operation
                MessageBox.Show("Error: " + ex.Message);
                return rowsAffected; // Return the default value
            }
            finally
            {
                // Ensure the connection is closed after execution
                con.Close();
            }
        }



        internal static DataTable GetEmployeeById(string employeeId)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                using (SqlCommand command = new SqlCommand("stpGetEmployeeById", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null; // Return null in case of an exception
            }
        }


        internal static bool UpdateEmployeeInDb(int employeeId, Person person, Employee employee)
        {
            var connection = Configuration.getInstance().getConnection();
            try
            {
                using (SqlCommand command = new SqlCommand("stpUpdateEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", employeeId);
                    command.Parameters.AddWithValue("@name", person.Name);
                    command.Parameters.AddWithValue("@email", person.Email);
                    command.Parameters.AddWithValue("@address", person.Address);
                    command.Parameters.AddWithValue("@city", person.City);
                    command.Parameters.AddWithValue("@country", "Pakistan");
                    command.Parameters.AddWithValue("@phone", person.Phone);
                    command.Parameters.AddWithValue("@gender", person.gender);
                    command.Parameters.AddWithValue("@role", person.role);
                    command.Parameters.AddWithValue("@joiningDate", employee.JoiningDate);
                    command.Parameters.AddWithValue("@salary", employee.Salary);
                    command.Parameters.AddWithValue("@username", employee.Username);
                    command.Parameters.AddWithValue("@password", employee.Password);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
        public static DataTable GetEmployeeAttendanceByDate(DateTime attendanceDate)
        {
            var con = Configuration.getInstance().getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("GetEmployeeAttendanceByDate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AttendanceDate", attendanceDate);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        public static void UpdateEmployeeAttendance(int attendanceID, int employeeId, string newStatus)
        {
            try
            {
                // Get the connection
                var con = Configuration.getInstance().getConnection();

                // Get the role ID from the lookup table based on the provided role value
                string statusQuery = "SELECT lookupId FROM Lookup WHERE category = 'attendanceStatus' AND value = @NewRole";
                SqlCommand Cmd = new SqlCommand(statusQuery, con);
                Cmd.Parameters.AddWithValue("@NewRole", newStatus);
                int statusID = Convert.ToInt32(Cmd.ExecuteScalar());

                // Define the SQL query to update the attendance record
                string query = @"UPDATE EmployeeAttendance 
                         SET attendanceStatus = @NewStatus
                         WHERE attendanceId = @AttendanceID 
                         AND employeeId = @EmployeeID";

                // Create a SqlCommand object
                SqlCommand cmd = new SqlCommand(query, con);

                // Add parameters
                cmd.Parameters.AddWithValue("@NewStatus", statusID);
                cmd.Parameters.AddWithValue("@AttendanceID", attendanceID);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                // Execute the query
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating employee attendance: " + ex.Message);
            }
        }

        public static void loadEmployeeDataFromDB()
        {
            string query = "SELECT P.id, P.name, P.email, P.address, P.city, P.country, P.phone,P.status,P.gender ,P.role, E.username, E.salary, E.joiningDate, E.updatedOn, E.password FROM   dbo.Employee AS E   INNER JOIN  dbo.Person AS P ON E.personId = P.id ";
            var con = Configuration.getInstance().getConnection();
            if(con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Employee employee = new Employee();

                    employee.Id = (int)reader["Id"];
                    employee.Name = reader["name"].ToString();
                    employee.Email = reader["email"].ToString();
                    employee.Address = reader["address"].ToString();
                    employee.City = reader["city"].ToString();
                    employee.role = Convert.ToInt32(reader["role"]);
                    employee.Country = reader["country"].ToString();
                    employee.Phone = reader["phone"].ToString();
                    employee.gender = Convert.ToInt32(reader["gender"]);
                    if (reader["salary"] != DBNull.Value)
                    {
                        employee.Salary = Convert.ToInt32(reader["Salary"]);
                    }
                    else
                    {
                        employee.Salary = 0;
                    }
                    employee.status = Convert.ToInt32(reader["status"]);
                    employee.JoiningDate = reader["joiningDate"].ToString();
                    employee.updatedOn = reader["updatedOn"].ToString();
                    employee.Username = reader["username"].ToString();
                    employee.Password = reader["password"].ToString();
                    AddEmployee(employee);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                reader.Close();
            }
        }

        public static List<int> CheckEmployeeInAppointments(int empId)
        {
            List<int> appointmentIds = new List<int>();

            try
            {
                var con = Configuration.getInstance().getConnection();
                using (SqlCommand command = new SqlCommand("CheckEmployeeInAppointments", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@empId", empId);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        appointmentIds.Add(reader.GetInt32(0));
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return appointmentIds;
        }

        public static bool SendNotificationToReceptionist(int ownerId, string employeeId, List<int> appIds)
        {
            try
            {
                // Get the list of receptionist IDs
                List<int> receptionistIds = GetReceptionistIds();
                // Check if any IDs are returned
                if (receptionistIds.Count > 0)
                {
                    // Notify each receptionist
                    foreach (int receptionistId in receptionistIds)
                    {
                        NotificationDL.SendNotificationEmployeeDeleted(ownerId, employeeId, appIds, receptionistId);
                        Console.WriteLine($"Notification sent to receptionist with ID: {receptionistId}");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No receptionists found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        
        public static List<int> GetReceptionistIds()
        {
            List<int> receptionistIds = new List<int>();

            try
            {
                var con = Configuration.getInstance().getConnection();
                string recQuery = $"SELECT personId FROM Employee JOIN Person ON Employee.personId = Person.Id WHERE role = (SELECT lookupId FROM Lookup WHERE category = 'role' AND value = 'receptionist')";

                // Create a command object with the query and connection
                SqlCommand command = new SqlCommand(recQuery, con);


                // Open the connection
                if (con.State != ConnectionState.Open)
                    con.Open();

                // Execute the query and read the results
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Add each receptionist ID to the list
                    receptionistIds.Add(reader.GetInt32(0));
                }

                // Close the reader and connection
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Console.WriteLine("Error: " + ex.Message);
            }

            // Return the list of receptionist IDs
            return receptionistIds;
        }
    }
}