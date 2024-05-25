using SalonManagmentSystem.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Drawing;

namespace SalonManagmentSystem.DL
{
    public class ServiceDL
    {
        public static bool CheckServiceTypeAlreadyExists(string typeName)
        {
            // Check if the type already exists in the database
            string checkExistingQuery = $"SELECT COUNT(*) FROM Lookup WHERE category = 'servicetype' AND value = @typeName";

            // Create a dictionary to hold the parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@typeName", typeName.ToLower());

            // Execute the query with parameters
            int existingCount = (int)DataHandler.ExecuteScalar(checkExistingQuery, parameters);

            if (existingCount > 0)
            {
                MessageBox.Show("Service type already exists.");
                return true;
            }
            return false;
        }
        public static bool UpdateServiceType(int typeId, string newTypeName)
        {
            try
            {
                // Check if the type already exists in the database
                if (CheckServiceTypeAlreadyExists(newTypeName))
                {
                    MessageBox.Show("Service type already exists.");
                    return false;
                }

                // Update the service type in the database
                string updateQuery = $"UPDATE Lookup SET value = '{newTypeName.ToLower()}' WHERE lookupid = {typeId}";
                int rowsAffected = DataHandler.ExecuteNonQuery(updateQuery);

                // Check if the update was successful
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Service type updated successfully.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to update service type. Please try again.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        internal static bool AddService(Service s)
        {
            var connection = Configuration.getInstance().getConnection();
            try
            {
                using (SqlCommand command = new SqlCommand("AddService", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", s.name);
                    command.Parameters.AddWithValue("@Description", s.description);
                    command.Parameters.AddWithValue("@ServiceCharges", s.serviceCharges);
                    command.Parameters.AddWithValue("@TimeDuration", s.timeDuration);
                    command.Parameters.AddWithValue("@ServiceTypeId", s.serviceTypeId);
                    command.Parameters.AddWithValue("@CreatedOn", s.createdOn);
                    command.Parameters.AddWithValue("@UpdatedOn", s.updateOn);
                    command.Parameters.AddWithValue("@IsDeleted", s.isDeleted);
  
                    command.ExecuteNonQuery();
                    MessageBox.Show("Service Added Successfully");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
        public static List<ServiceType> GetServiceTypes()
        {
            List<ServiceType> serviceTypes = new List<ServiceType>();

            string query = "SELECT lookupId,value FROM Lookup WHERE category = 'servicetype'";
            DataTable result = DataHandler.ExecuteQuery(query);

            foreach (DataRow row in result.Rows)
            {
                int id = Convert.ToInt32(row["lookupId"]);
                string name = row["value"].ToString();
                serviceTypes.Add(new ServiceType(id, name));
            }
            return serviceTypes;
        }

        public static int GetServiceTypeId(string serviceName)
        {
            string query = "SELECT lookupId FROM Lookup WHERE value = @serviceName and category = 'servicetype'";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@serviceName"] = serviceName;

            object result = DataHandler.ExecuteScalar(query, parameters);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                // Handle case when service type ID is not found
                return -1;
            }
        }
        public static void AddServiceProducts(int serviceId, List<int> productIds)
        {
            foreach (int productId in productIds)
            {
                string query = "INSERT INTO [ServiceProducts] (serviceId, productId) VALUES (@serviceId, @productId)";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters["@serviceId"] = serviceId;
                parameters["@productId"] = productId;

                // Execute the query
                int rowsAffected = DataHandler.ExecuteNonQuery(query, parameters);

                // Check if the query was executed successfully
                if (rowsAffected <= 0)
                {
                    MessageBox.Show(productId + " not added in service");
                }
            }
        }

        public static int GetLastInsertedServiceId(Service service1)
        {
            string query = "SELECT id FROM Service WHERE name = @serviceName";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@serviceName"] = service1.name;

            
            object result = DataHandler.ExecuteScalar(query, parameters);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                // Handle case when service type ID is not found
                return -1;
            }
        }

        public static bool UpdateService(Service service)
        {
            try
            {
                var connection = Configuration.getInstance().getConnection();
                SqlCommand command = new SqlCommand("UpdateService", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                 // Add parameters
                 command.Parameters.AddWithValue("@ServiceId", service.id);
                 command.Parameters.AddWithValue("@Name", service.name);
                 command.Parameters.AddWithValue("@Description", service.description);
                 command.Parameters.AddWithValue("@ServiceCharges", service.serviceCharges);
                 command.Parameters.AddWithValue("@TimeDuration", service.timeDuration);
                 command.Parameters.AddWithValue("@ServiceTypeId", service.serviceTypeId);
                 command.Parameters.AddWithValue("@UpdatedOn", DateTime.Now);
                
                 if (connection.State != ConnectionState.Open)
                 {
                     connection.Open();
                 }
                
                 int rowsAffected = command.ExecuteNonQuery();
                
                 connection.Close();
                
                 if (rowsAffected > 0)
                 {
                     MessageBox.Show("Service updated successfully.");
                 }
                 return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }

        }

        public static void UpdateServiceProducts(int serviceId, List<int> productIds)
        {
            // Delete all occurrences of the serviceId in the ServiceProducts table
            string deleteQuery = "DELETE FROM ServiceProducts WHERE serviceId = @serviceId";
            Dictionary<string, object> deleteParameters = new Dictionary<string, object>();
            deleteParameters["@serviceId"] = serviceId;
            DataHandler.ExecuteNonQuery(deleteQuery, deleteParameters);

            // Insert the new productIds into the ServiceProducts table
            AddServiceProducts(serviceId, productIds);
        }

        public static List<int> GetServiceAppointments(int serviceId) 
        {
            List<int> appointmentIds = new List<int>();

            try
            {
                // Get the database connection
                var con = Configuration.getInstance().getConnection();

                string query = $"SELECT a.Id " +
                               $"FROM AppointmentDetails ad " +
                               $"JOIN Appointment a ON a.Id = ad.appointmentId " +
                               $"WHERE CONVERT(datetime, a.Date + ' ' + a.startTime) <= GETDATE() " +
                               $"AND ad.serviceId = @serviceId";

                // Create a command object with the query and connection
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@serviceId", serviceId);

                // Open the connection
                if (con.State != ConnectionState.Open)
                    con.Open();

                // Execute the query and read the results
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Add each appointment ID to the list
                    appointmentIds.Add(reader.GetInt32(0));
                }

                // Close the reader and connection
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // Return the list of appointment IDs
            return appointmentIds;
        }

        public static bool DeleteService(int serviceId)
        {
            try
            {
                // Get the database connection
                var con = Configuration.getInstance().getConnection();

                // Define the query to update the isDeleted status of the service
                string updateQuery = $"UPDATE Service " +
                                     $"SET isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'yes') " +
                                     $"WHERE id = @serviceId";

                // Create a command object with the query and connection
                SqlCommand command = new SqlCommand(updateQuery, con);
                command.Parameters.AddWithValue("@serviceId", serviceId);

                // Open the connection
                if (con.State != ConnectionState.Open)
                    con.Open();

                // Execute the query
                int rowsAffected = command.ExecuteNonQuery();

                // Close the connection
                con.Close();

                // Check if any rows were affected
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }


        public static List<string> allServices()
        {
            List<string> services = new List<string>();
            string query = "SELECT Name FROM Service";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    string service = reader["Name"].ToString();
                    services.Add(service);
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
            return services;
        } 
    }
}
