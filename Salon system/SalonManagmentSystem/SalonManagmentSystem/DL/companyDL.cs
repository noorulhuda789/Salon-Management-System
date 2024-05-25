using SalonManagmentSystem.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SalonManagmentSystem.DL
{
    internal class companyDL
    {
        public static void addCompany(company company)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "INSERT INTO Company(name, createdOn,updatedOn, isDeleted) VALUES (@name, @createdOn,@updatedOn, @isdeleted)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", company.name);
                cmd.Parameters.AddWithValue("@isdeleted",company.isdeleted);
                cmd.Parameters.AddWithValue("@createdOn", company.createdOn);
                cmd.Parameters.AddWithValue("@updatedOn", company.updatedOn);

                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public static void updateCompany(string name,company company)
        {
            SqlTransaction transaction = null;

            
            try
            {
                var con = Configuration.getInstance().getConnection();
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction(IsolationLevel.Serializable);

                string query = "UPDATE Company SET name = @name, updatedOn = @updatedOn, isDeleted = @isdeleted WHERE name = @Check";

                SqlCommand cmd = new SqlCommand(query, con, transaction);
                cmd.Parameters.AddWithValue("@name", company.name);
                cmd.Parameters.AddWithValue("@isdeleted", company.isdeleted);
                cmd.Parameters.AddWithValue("@updatedOn", company.updatedOn);
                cmd.Parameters.AddWithValue("@Check", name);

                cmd.ExecuteNonQuery();

               
                transaction.Commit();
                MessageBox.Show("Successfully Updated");
            }
            catch (Exception ex)
            {
                
                transaction?.Rollback();
                MessageBox.Show("Error: " + ex.Message);
            }

        }


        public static bool alreadyExists(company c)
        {
            bool check = false;

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = $"SELECT COUNT(*) FROM Company WHERE name= @TypeName AND" +
                    $" isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@TypeName", c.name);
                if (con.State != ConnectionState.Open) { con.Open(); }
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    check = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return check;
        }

        public static bool nameAlreadyExists(company c)
        {
            bool check = false;
            SqlConnection con = null;
            try
            {
                con = Configuration.getInstance().getConnection();
                string query = $"SELECT COUNT(*) FROM Company WHERE name = @CompanyName and " +
                    $"isDeleted=(SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@CompanyName", c.name);
                if (con.State != ConnectionState.Open) { con.Open(); }
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    check = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return check;
        }

        public static void updateCompanyStatus()
        {

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "UPDATE Company SET" +
                                 " isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no') WHERE " +
                                "name = @TypeName AND " +
                                "isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'yes')";
                SqlCommand cmd = new SqlCommand(query, con);
                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        public static void deleteCompany(company company)
        {

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = $"EXEC DeleteCompany'{company.name}', '{company.updatedOn}'";


                SqlCommand cmd = new SqlCommand(query, con);
                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        public static List<string> getCompanyName()
        {
            List<string> companyList = new List<string>();

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "SELECT name FROM Company WHERE " +
                                 "isdeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')";
                SqlCommand cmd = new SqlCommand(query, con);

                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string companyName = reader["name"].ToString();
                    companyList.Add(companyName);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return companyList;
        }
        public static DataTable populate()
        {
            DataTable result = new DataTable();
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT Company.name AS CompanyName, Product.name AS ProductName\r\nFROM Product\r\n Right JOIN Company ON Product.companyId = Company.id where Company.isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')", con);
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(result);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return result;
        }
    }
}
