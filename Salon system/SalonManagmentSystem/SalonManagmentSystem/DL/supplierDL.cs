using SalonManagmentSystem.BL;
using SalonManagmentSystem.UI.ProductsUi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonManagmentSystem.DL
{
    internal class supplierDL
    {

        public static  void addSupplier(supplier s)
        {

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "INSERT INTO Supplier (name, contact,address, createdBy," +
                                "createdOn,updatedOn, isDeleted) VALUES (@name, @contact,@address,@createdBy ,@createdOn,@updatedOn, @isdeleted)";
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", s.name);
                cmd.Parameters.AddWithValue("@address", s.address);
                cmd.Parameters.AddWithValue("@contact", s.contact);
                cmd.Parameters.AddWithValue("@isdeleted", s.isdeletd);
                cmd.Parameters.AddWithValue("@createdOn", s.createdOn);
                cmd.Parameters.AddWithValue("@updatedOn", s.updatedOn);
                cmd.Parameters.AddWithValue("@createdBy", s.addedBy);
                


                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }
        List <string> supplierList;
        public static List<string> getSupplierName()
        {
            List<string> supplierList = new List<string>();

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "SELECT name FROM Supplier WHERE isdeleted = (select lookupid from Lookup where value=@value)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@value","no");
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string supplierName = reader["name"].ToString();
                    supplierList.Add(supplierName);
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return supplierList;
        }

        public static bool nameAlreadyExists(supplier s)
        {
            bool check = false;

            try
            {

                var con = Configuration.getInstance().getConnection();
                string query = "SELECT COUNT(*) FROM Supplier WHERE name= @TypeName AND " +
                                "isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')" +
                                "and contact =@contact";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@TypeName", s.name);
                command.Parameters.AddWithValue("@contact", s.contact);
                if (con.State != ConnectionState.Open) { con.Open(); }
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    check = true;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return check;

        }

        public static DataTable viewSupplier()
        {
            DataTable result = new DataTable();
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(@"
                                        SELECT 
                                               Supplier.name AS SupplierName,
                                               Supplier.address AS SupplierAddress,
                                               Supplier.contact AS SupplierContact,
                                               Product.name AS ProductName
                                        FROM Product
                                        Right JOIN Supplier ON Product.supplierId = Supplier.id
                                        WHERE Supplier.isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no');
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
        public static void deleteSupplier(supplier s)
        {

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = $"EXEC DeleteSupplier '{s.name}', '{s.updatedOn}'";


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
        public static void updateSupplier(string name, supplier s)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "UPDATE Supplier SET name = @name, contact = @contact, address = @address, " +
                               "updatedOn = @updatedOn, isDeleted = @isdeleted WHERE name = @Check";

                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlTransaction transaction = null;
                transaction = con.BeginTransaction(IsolationLevel.Serializable);
                SqlCommand cmd = new SqlCommand(query, con, transaction);
                cmd.Parameters.AddWithValue("@name", s.name);
                cmd.Parameters.AddWithValue("@address", s.address);
                cmd.Parameters.AddWithValue("@contact", s.contact);
                cmd.Parameters.AddWithValue("@isdeleted", s.isdeletd);
                cmd.Parameters.AddWithValue("@updatedOn", s.updatedOn);
                cmd.Parameters.AddWithValue("@Check", name); 
                cmd.ExecuteNonQuery();
                transaction.Commit(); 
                MessageBox.Show("Successfully Updated ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



    }
}
