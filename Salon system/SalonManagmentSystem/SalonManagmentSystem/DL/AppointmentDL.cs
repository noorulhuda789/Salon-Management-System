using SalonManagmentSystem.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections;

namespace SalonManagmentSystem.DL
{
    public class AppointmentDL
    {

        public static bool addAppointments(Appointment a, string customerPhone)
        {
            bool isAdded = false;
            string query2 = "INSERT INTO AppointmentDetails(appointmentId, employeeId, serviceId) VALUES(@AppId, (SELECT id FROM Person Where name = @employeeName), (SELECT id FROM Service WHERE name = @serviceName))";
            string query = $"EXEC stpAddAppointment '{a.CustomerId}','{a.Time}', '{a.Date}', @AppID OUTPUT ";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                SqlParameter insertedIdParam = new SqlParameter("@AppId", SqlDbType.Int);
                insertedIdParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(insertedIdParam);

                cmd.ExecuteNonQuery();
                int AppId = Convert.ToInt32(insertedIdParam.Value);
                for (int i = 0; i < a.ServiceandEmployee.Count; i++)
                {
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.AddWithValue("@AppId", AppId);
                    cmd2.Parameters.AddWithValue("@employeeName", a.ServiceandEmployee[i].Item2);
                    cmd2.Parameters.AddWithValue("@serviceName", a.ServiceandEmployee[i].Item1);
                    cmd2.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                isAdded = true;
            }
            return isAdded;

        }

        public static int getCustomerID(int id)
        {
            string query = $"SELECT customerId FROM Appointment WHERE id = {id}";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            if (con.State != ConnectionState.Open) { con.Open(); }
            int customerId = Convert.ToInt32(cmd.ExecuteScalar());
            return customerId;
        }


        public static void checkDateAndAppointmentStatus()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string query = $"Update Appointment SET status = (SELECT LookupId From Lookup Where value = 'cancelled')  Where date < '{date}' and status = (SELECT LookupId From Lookup Where value = 'pending')"; 
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public static bool updateAppointment(Appointment a)
        {
            bool isUpdated = false;
            string query  = $"Update Appointment Set customerId = {a.CustomerId}, date ='{a.Date}', starttime = '{a.Time}', updatedBy = {a.updatedBY} , updatedOn = getdate() Where id = {a.AppointmentId}"; ;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                isUpdated = true;
                
            }
            return isUpdated;
        }
        public static bool cancelAppointmentByAppId(int id, int employeeActive)
        {
            bool isUpdated = false;
            string query = $"Exec stpCancelAppointmentByAppId {id}, {employeeActive}";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                isUpdated = true;
            }
            return isUpdated;
        }
        public static bool cancelAppointmentByCustomerId(int id, int employeeActive)
        {
            bool isUpdated = false;
            string query = $"Exec stpCancelAppointmentByCustomerId {id}, {employeeActive}";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                isUpdated = true;
            }
            return isUpdated;
        }

        public static void setAppCompleted(int id, int ownerActive)
        {
            string query = $"Exec stpsetAppointmentCompleted {id}, {ownerActive}";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<string> Customers()
        {
            List<string> customers = new List<string>();
            string query = "SELECT name, phone FROM Person Where role = (Select lookupid from lookup Where value = 'customer') And status = (Select lookupid from lookup Where value = 'active')";
            var con = Configuration.getInstance().getConnection();
            if(con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    string customer = reader["name"].ToString() + " - " + reader["phone"].ToString();
                    customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
            }
            return customers;
        }

        public static List<string> Employees(string type)
        {
            List<string> employees = new List<string>();

            var con = Configuration.getInstance().getConnection();
            string query = $"SELECT Name From Person Where role in (SELECT lookupid from lookup where value like '{type}%' or value = 'expert')";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    string employee = reader["name"].ToString();
                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
            }
            return employees;
        }

        public static List<Appointment> getAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            string query = "SELECT A.id, A.customerId, A.date, A.startTime, A.status, A.updatedOn, A.updatedBy, A.isDeleted FROM Appointment A";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            if (con.State != ConnectionState.Open) { con.Open(); }
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Appointment a = new Appointment();
                    a.AppointmentId = Convert.ToInt32(reader["id"]);
                    a.CustomerId = (int)reader["customerId"];
                    a.Date = reader["date"].ToString();
                    a.Time = reader["startTime"].ToString();
                    a.Status = (int)reader["status"];
                    if (reader["updatedOn"] == DBNull.Value)
                    {
                        a.updatedOn = "";
                    }
                    else
                    {
                        a.updatedOn = reader["updatedOn"].ToString();
                    }
                    if (reader["updatedBy"] == DBNull.Value)
                    {
                        a.updatedBY = 0;
                    }
                    else
                    {
                        a.updatedBY = Convert.ToInt32(reader["updatedBy"]);
                    }
                    if (reader["isDeleted"] == DBNull.Value)
                    {
                        a.isDeleted = -1;
                    }
                    else
                    {
                        a.isDeleted = Convert.ToInt32(reader["isDeleted"]);

                    }
                    appointments.Add(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
            }

            return appointments;

        }

        public static List<Tuple<string, string>> getAppointmentServices(int id)
        {
            List<Appointment> app = getAppointments();
            List<Tuple<string, string>> serviceandemployee = new List<Tuple<string, string>>();

            string query = $"SELECT P.name as empName, S.name serviceName FROM AppointmentDetails AP JOIN Person P ON P.id = AP.employeeId JOIN Service S ON S.id = AP.serviceId Where appointmentId = {id}";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    serviceandemployee.Add(new Tuple<string, string>(reader["empName"].ToString(), reader["serviceName"].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
            }

            return serviceandemployee;
        }

        public static List<Tuple<string, int>> getAppointmentServicesWithPrice(int id)
        {
            List<Appointment> app = getAppointments();
            List<Tuple<string, int>> serviceCharges = new List<Tuple<string, int>>();

            string query = $"SELECT S.name serviceName , S.serviceCharges as price FROM AppointmentDetails AP JOIN Service S ON S.id = AP.serviceId Where appointmentId = {id}";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    serviceCharges.Add(new Tuple<string, int>(reader["serviceName"].ToString(), Convert.ToInt32(reader["price"])));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
            }

            return serviceCharges;
        }
        
        public static List<List<string>> getAppointmentstoSearch(string filter, string searchTxt, string date)
        {
            List<List<string>> apps = new List<List<string>>();
            string query = "SELECT Distinct(A.id), A.customerId, A.date, A.startTime, A.status, A.updatedOn, A.updatedBy, A.isDeleted FROM Appointment A";
            if (filter == "Customer Name")
            {
                query = query + $" JOIN Person P ON P.id = A.customerId Where P.name like '%{searchTxt}%' AND A.date = '{date}'";
            }
            else if (filter == "Employee Name")
            {
                query = query + $" JOIN AppointmentDetails AP ON A.id = AP.appointmentId JOIN Person P ON P.id = AP.EmployeeId Where P.name like '%{searchTxt}%' AND A.date = '{date}'";
            }
            else if(filter == "Status")
            {
                query = query + $" JOIN Lookup L ON L.lookupid = A.Status WHERE L.value = '%{searchTxt}%' AND A.date = '{date}'";
            }

            var con = Configuration.getInstance().getConnection();
            SqlCommand sqlCommand = new SqlCommand(query, con);
            SqlDataReader reader = null;
            try
            {
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    List<string> app = new List<string>();
                    app.Add(reader["Id"].ToString());
                    app.Add(CustomerDL.getCustomerById(Convert.ToInt32(reader["customerId"])).Name);
                    app.Add(reader["date"].ToString());
                    app.Add(reader["startTime"].ToString());
                    app.Add(LookupDL.getValue(Convert.ToInt32(reader["status"])));
                    apps.Add(app);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
            }
            return apps;

        }
    }
}
