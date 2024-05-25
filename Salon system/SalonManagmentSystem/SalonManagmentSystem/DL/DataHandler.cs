using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SalonManagmentSystem.DL
{
    public class DataHandler
    {
        public static DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dataTable = new DataTable();
            var connection = Configuration.getInstance().getConnection();
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters if provided
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
             return dataTable;
        }
        public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            int rowsAffected = 0;
            var connection = Configuration.getInstance().getConnection();

            SqlCommand command = new SqlCommand(query, connection);
            {
                // Add parameters if provided
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                rowsAffected = command.ExecuteNonQuery();

                connection.Close();
            }
            return rowsAffected;
        }
        public static object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            object result = null;
            SqlConnection connection = Configuration.getInstance().getConnection();
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters if provided
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    // Execute the scalar query
                    result = command.ExecuteScalar();
                }
            }
            return result;
        }
    }
}
