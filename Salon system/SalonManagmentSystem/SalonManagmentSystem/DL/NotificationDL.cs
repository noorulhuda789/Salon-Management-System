using SalonManagmentSystem.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SalonManagmentSystem.DL
{
    public class NotificationDL
    {
        public static void SendNotificationEmployeeDeleted(int ownerId, string employeeId, List<int> appIds, int recepId)
        {
            try
            {
                // Create the notification message
                string message = $"Employee with ID {employeeId} has been removed. They were associated with appointments: {string.Join(", ", appIds)}. Please reassign their appointments to someone else.";

                // Insert the notification into the Notification table
                DateTime timestamp = DateTime.Now;
                int done = InsertNotification(message, timestamp, ownerId);
                int statusId = GetNotificationStatusId("delivered");
                int notificationId = GetNotificationId(message,timestamp);

                int result = InsertEmployeeNotification(recepId, notificationId, statusId);
                if (result == -1)
                {
                    MessageBox.Show("Failed to insert notification ID into EmployeeNotification table.");
                    return;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the process
                MessageBox.Show("Error sending notification: " + ex.Message);
            }
        }

        public static int GetNotificationStatusId(string statusValue)
        {
            try
            {
                string query = $"SELECT lookupId FROM Lookup WHERE category = 'notification' AND value = '{statusValue}'";
                object result = DataHandler.ExecuteScalar(query);

                // Check if the result is not null and is convertible to an integer
                if (result != null && int.TryParse(result.ToString(), out int statusId))
                {
                    return statusId;
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve notification status ID for status '{statusValue}'.");
                    return -1; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving notification status ID: " + ex.Message);
                return -1; 
            }
        }

        public static int InsertNotification(string message, DateTime timestamp, int statusId)
        {
            try
            {
                string query = $"INSERT INTO Notification (message, dateCreated, sentBy) VALUES (@Message, @Timestamp, @Sent)";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@Message", message);
                parameters.Add("@Timestamp", timestamp);
                parameters.Add("@Sent", statusId);
                MessageBox.Show(statusId.ToString());
                return DataHandler.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting notification: " + ex.Message);
                return -1;
            }
        }
        public static int GetNotificationId(string message, DateTime timestamp)
        {
            try
            {
                string query = "SELECT TOP 1 id FROM Notification WHERE message = @Message AND dateCreated = @Timestamp ORDER BY id DESC";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@Message", message);
                parameters.Add("@Timestamp", timestamp);

                return Convert.ToInt32(DataHandler.ExecuteScalar(query, parameters));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving notification ID: " + ex.Message);
                return -1;
            }
        }
        public static int InsertEmployeeNotification(int employeeId, int notificationId, int statusId)
        {
            try
            {
                string query = "INSERT INTO EmployeeNotification (notificationId, employeeId, status) VALUES (@NotificationId, @EmployeeId, @status)";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@EmployeeId", employeeId);
                parameters.Add("@NotificationId", notificationId);
                parameters.Add("@status", statusId);
                int ans = DataHandler.ExecuteNonQuery(query, parameters);
                return ans;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting employee notification: " + ex.Message);
                return -1;
            }
        }
        public static int DeleteNotification(string msg, DateTime dt)
        {
            try
            {
                string query = @"UPDATE EmployeeNotification 
                 SET status = (SELECT lookupId FROM Lookup WHERE category = 'notification' AND value = 'deleted') 
                 WHERE notificationId=(select id from Notification where message = @msg AND dateCreated = @dt)";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@msg", msg);
                parameters.Add("@dt", dt);
                return DataHandler.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting employee notification: " + ex.Message);
                return -1;
            }
        }
        public static void InsertNotificationForProduct(string message, DateTime timestamp, int statusId)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "INSERT INTO Notification (message, dateCreated, sentBy) VALUES (@Message, @Timestamp, @Sent)";
                SqlCommand cmd = new SqlCommand(query, con);

                
                cmd.Parameters.AddWithValue("@Message", message);
                cmd.Parameters.AddWithValue("@Timestamp", timestamp);
                cmd.Parameters.AddWithValue("@Sent", statusId);

                if (con.State != ConnectionState.Open) { con.Open(); }

                
                cmd.ExecuteNonQuery();

               
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting notification: " + ex.Message);
            }
        }

    }
}
