using SalonManagmentSystem.BL;
using SalonManagmentSystem.UI.ProductsUi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace SalonManagmentSystem.DL
{
    public class productTypeDl
    {

        public static void addProductType(ProductsType product)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "INSERT INTO ProductType (type, description, createdOn,updatedOn, isDeleted) VALUES (@name, @description, @createdOn,@updatedOn, @isdeleted)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@isdeleted", product.isdeleted);
                cmd.Parameters.AddWithValue("@createdOn", product.createdOn);
                cmd.Parameters.AddWithValue("@updatedOn", product.updatedOn);
                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added");
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }
         public static bool alreadyExists(ProductsType p) {
            bool check = false;

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = $"SELECT COUNT(*) FROM ProductType WHERE type = '{p.Name}'  and " +
                             $"isDeleted=( SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')";
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(query, con);
                int count = (int)cmd.ExecuteScalar();
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
        public static List<string> getNames()
        {
            List<string> typeList = new List<string>();

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "SELECT type FROM ProductType WHERE " +
                                 "isdeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')";
                SqlCommand cmd = new SqlCommand(query, con);
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string supplierName = reader["type"].ToString();
                    typeList.Add(supplierName);
                    
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return typeList;
        }

        public static DataTable viewProductType()
        {
            DataTable result = new DataTable();
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(@"
                                        SELECT 
                                               ProductType.type AS Name,
                                              .ProductType.description AS Description,
                                               
                                               Product.name AS ProductName
                                        FROM Product
                                        Right JOIN ProductType ON Product.productType= ProductType.id
                                        WHERE ProductType.isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no');
", con);
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
        public static void deleteType(ProductsType type)
        {
            try
            {

                var con = Configuration.getInstance().getConnection();
                string query = "UPDATE ProductType SET IsDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'yes') ,updatedOn=@updatedOn WHERE type=@name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", type.Name);
                cmd.Parameters.AddWithValue("@updatedOn", type.updatedOn);

                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted");
                con.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }

        }
        public static void updateType(string name ,ProductsType product)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "UPDATE ProductType SET type = @name, description = @description, updatedOn = @updatedOn, isDeleted = @isdeleted WHERE type = @Check";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@isdeleted", product.isdeleted);
                cmd.Parameters.AddWithValue("@updatedOn", product.updatedOn);
                cmd.Parameters.AddWithValue("@Check", name);
                if (con.State != ConnectionState.Open) { con.Open(); }
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Successfully Updated");
                }
                else
                {
                    MessageBox.Show("No rows updated");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }

}

