using Org.BouncyCastle.Ocsp;
using SalonManagmentSystem.BL;
using SalonManagmentSystem.UI.ProductsUi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace SalonManagmentSystem.DL
{
    internal class productDL
    {
        public static void addProduct(product product)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = $"EXEC addProduct '{product.name}', '{product.productType}', " +
                              $"'{product.supplierName}','{product.companyName}','{product.quantity}',' {product.price}'," +
                              $"'{product.restocklevel}','{product.isdeleted}','{product.createdOn}'," + 
                              $" '{product.updatedOn}'";
                SqlCommand cmd = new SqlCommand(query, con);
                if (con.State != ConnectionState.Open) { con.Open(); }


                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        public static void updateProduct(product product)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "EXEC updateProduct @ProductName, @ProductType, @SupplierName, @CompanyName, " +
                               "@Quantity, @Price, @RestockLevel, @IsDeleted, @UpdatedOn";
                SqlCommand cmd = new SqlCommand(query, con);
                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.Parameters.AddWithValue("@ProductName", product.name);
                cmd.Parameters.AddWithValue("@ProductType", product.productType);
                cmd.Parameters.AddWithValue("@SupplierName", product.supplierName);
                cmd.Parameters.AddWithValue("@CompanyName", product.companyName);
                cmd.Parameters.AddWithValue("@Quantity", product.quantity);
                cmd.Parameters.AddWithValue("@Price", product.price);
                cmd.Parameters.AddWithValue("@RestockLevel", product.restocklevel);
                cmd.Parameters.AddWithValue("@IsDeleted", product.isdeleted);
                cmd.Parameters.AddWithValue("@UpdatedOn", product.updatedOn);

                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Update the product");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        public static bool nameAlreadyExists(product product)
        {
            bool check = false;
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = $"SELECT COUNT(*) FROM Product WHERE name = @Name and " +
                    $"isDeleted=(SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Name", product.name);

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

        public static DataTable GetProductList()
        {
            DataTable result = new DataTable();
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Exec viewproducts", con);
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

        public static void deleteproduct(string name)
        {
            try
            {
                string query = "UPDATE Product " +
               "SET isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'yes') " +
               "WHERE name = @name";

                var con = Configuration.getInstance().getConnection();

                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlTransaction transaction = con.BeginTransaction(IsolationLevel.Serializable);
              


                SqlCommand command = new SqlCommand(query, con, transaction);
                command.Parameters.AddWithValue("@name", name);
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted");
                transaction.Commit();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        public static void orderProduct(product p)
        {

            try
            {
                
                
                var con = Configuration.getInstance().getConnection();
                string query = $"exec orderProduct '{p.name}','{p.quantity}','{p.productType}','{p.companyName}','{p.addedBy}','{p.isdeleted}','{p.createdOn}','{p.updatedOn}'";
                SqlCommand cmd = new SqlCommand(query, con);
                
                string name = orderProducts.nameapproach();
               
                string queryUpdate = $"UPDATE Product " +
                        $"SET supplierId = (SELECT id FROM Supplier WHERE name = '{name}'), " +
                        $"productType = (SELECT id FROM ProductType WHERE type = '{p.productType}'), " +
                        $"companyId = (SELECT id FROM Company WHERE name = '{p.companyName}')" +
                        $"" +
                        $"where name@=name";


                if (con.State != ConnectionState.Open) { con.Open(); }

                
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);

                cmd.ExecuteNonQuery();
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Successfully Ordered the Product");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }

        }

       


        public static void discardProduct(product p)
        {
            
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = $"EXEC discardProduct '{p.name}', '{p.companyName}', '{p.productType}', {p.quantity}, {p.addedBy}, '{p.createdOn}'";
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(query, con);

                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Discard the Product");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public static void returnProduct(product p)
        {
            try
            {
                    var con = Configuration.getInstance().getConnection();

                    if (con.State != ConnectionState.Open) { con.Open(); }
                    SqlCommand command = new SqlCommand("InsertReturnedProduct", con);
                    command.CommandType = CommandType.StoredProcedure;
                
                    command.Parameters.AddWithValue("@ProductName", p.name);
                    command.Parameters.AddWithValue("@ProductType", p.supplierName);
                    command.Parameters.AddWithValue("@Company", p.companyName);
                    command.Parameters.AddWithValue("@Quantity", p.quantity);
                    command.Parameters.AddWithValue("@Reason", p.reason);
                    command.Parameters.AddWithValue("@ReceivedBy", p.addedBy);
                    command.Parameters.AddWithValue("@ReceivedOn", p.createdOn);
                    command.Parameters.AddWithValue("@Status", p.returnStatus);
                    command.Parameters.AddWithValue("@orderid", p.orderid);

                    if (con.State != ConnectionState.Open) { con.Open(); }
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfully Return the Product");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public static bool productExists(product p)
        {
            bool check = false;
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = @"
                                SELECT COUNT(*)
                                FROM Product
                                WHERE name = @Name
                                AND companyId = (SELECT id FROM Company WHERE name = @company) 
                                AND productType = (SELECT id FROM ProductType WHERE type = @productType)";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Name", p.name);
                command.Parameters.AddWithValue("@company", p.companyName);
                command.Parameters.AddWithValue("@productType", p.productType);
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
        public static bool productExistsForReturn(product p)
        {
            bool check = false;
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = @"
                                SELECT COUNT(*)
                                FROM Product
                                WHERE name = @Name
                                AND companyId = (SELECT id FROM Company WHERE name = @company) 
                                AND supplierId = (SELECT id FROM Supplier WHERE name = @productType)";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Name", p.name);
                command.Parameters.AddWithValue("@company", p.companyName);
                command.Parameters.AddWithValue("@productType", p.supplierName);
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

        public static DataTable viewOrderDetails()
        {
            DataTable result = new DataTable();
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select o.id, e.name, t.name, t.quantity " +
                                "from Person e " +
                                "INNER JOIN OrderDetails o ON o.empId = e.id " +
                                "INNER JOIN Product t ON t.id = o.productId", con);
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

        public static List<string> viewproducts()
        {
            List<string> supplierList = new List<string>();

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "Select name from Product where isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@value", "no");
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
        public static string viewproducts(int id)
        {
            string supplierName="";

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "Select name from Product where isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')and id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@value", "no");
                cmd.Parameters.AddWithValue("@id", id);
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    supplierName = reader["name"].ToString();
                    
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return supplierName;



        }
        public static int GetProductIdByName(string name)
        {
            int productId = -1; // Default value if product ID is not found

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "SELECT id FROM Product WHERE name = @name";

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name); // Add parameter to prevent SQL injection

                // Execute the query and retrieve the result
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    productId = Convert.ToInt32(result);
                }
                else
                {
                    // Handle case where product with given name is not found
                    MessageBox.Show("Product not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return productId;
        }
        public static void purchaseProduct(product p)
        {
            try
            {
                int productId = GetProductIdByName(p.name);
                var con = Configuration.getInstance().getConnection();
                if (con.State != ConnectionState.Open) { con.Open(); }

                SqlCommand cmd = new SqlCommand("purchaseProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@orderId", p.orderid);
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.Parameters.AddWithValue("@receivedBy", p.addedBy);
                cmd.Parameters.AddWithValue("@receivedOn", p.createdOn);
                cmd.Parameters.AddWithValue("@quantity", p.quantity);
                cmd.Parameters.AddWithValue("@expiryDate", p.expiryDate);
                cmd.Parameters.AddWithValue("@status", p.returnStatus);
                cmd.Parameters.AddWithValue("@price", p.price);
                cmd.Parameters.AddWithValue("@isdeleted", p.isdeleted);

                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Purchase the Product");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }

        }
        public static bool CheckQuantity(string tableName, product p)
        {
            bool check = false;
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = @"
                        SELECT COUNT(*)
                        FROM OrderDetails
                        WHERE quantity < @quantity and id=@orderId";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@quantity", p.quantity);
                command.Parameters.AddWithValue("@orderId", p.orderid);
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



        public static List<string> getNames()
        {

            List<string> typeList = new List<string>();

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "SELECT name FROM Product WHERE " +
                                 "isdeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')";
                SqlCommand cmd = new SqlCommand(query, con);
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string supplierName = reader["name"].ToString();
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

        public static bool productQuantity(product p)
        {
            bool check = false;
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = @"
                        SELECT COUNT(*)
                        FROM Product
                        WHERE quantity < @quantity and name=@name";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@quantity", p.quantity);
                command.Parameters.AddWithValue("@name", p.name);
                if (con.State != ConnectionState.Open) { con.Open(); }
                int count = (int)command.ExecuteScalar();
                con.Close();
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
        public static List<string> getOrderId()
        {

            List<string> typeList = new List<string>();

            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "SELECT id FROM OrderDetails WHERE " +
                                 "isdeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')";
                SqlCommand cmd = new SqlCommand(query, con);
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string supplierName = reader["id"].ToString();
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
        
        public static DataTable searchProduct(string columnName,string value)
        {
            DataTable result = new DataTable();
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "EXEC SearchRecords @ColumnName, @Value";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ColumnName", columnName);
                cmd.Parameters.AddWithValue("@Value", value);

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
        public static  void restockLevel(int ownerActive,string name)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = @"
                        SELECT COUNT(*)
                        FROM Product
                        WHERE quantity >= restockLevel  and name=@name";
                SqlCommand command = new SqlCommand(query, con);
                
                command.Parameters.AddWithValue("@name", name);
                if (con.State != ConnectionState.Open) { con.Open(); }
                int count = (int)command.ExecuteScalar();
                con.Close();
                if (count > 0)
                {
                    string message = "Low Stock Level Reached for " + name ;
                    DateTime timestamp = DateTime.Now;
                    NotificationDL.InsertNotification(message, timestamp, ownerActive);
                    int statusId = NotificationDL.GetNotificationStatusId("delivered");
                    int notificationId = NotificationDL.GetNotificationId(message, timestamp);
                    NotificationDL.InsertEmployeeNotification(ownerActive, notificationId, statusId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }

}


