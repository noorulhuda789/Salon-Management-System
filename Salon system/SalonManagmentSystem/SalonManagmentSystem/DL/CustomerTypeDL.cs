using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalonManagmentSystem.BL;

namespace SalonManagmentSystem.DL
{
    public class CustomerTypeDL
    {
        public static List<CustomerType> customerTypes = new List<CustomerType>();

        public static void addCustomerType(CustomerType customerType)
        {
            customerTypes.Add(customerType);
        }

        public static void removeCustomerType(CustomerType customerType)
        {
            customerTypes.Remove(customerType);
        }

        public static string getCustomerTypeName(int id)
        {
            return (customerTypes.Find(c => c.Id == id)).Name;
        }
        public static int getCustomerTypeID(string name)
        {
            return (customerTypes.Find(c => c.Name == name.ToLower())).Id;
        }
        public static decimal getcustomerTypeDiscountPercentage(int id)
        {
            return (customerTypes.Find(c => c.Id == id)).discountPercentage;
        }

        public static List<CustomerType> getCustomerTypes()
        {
            return customerTypes;
        }

        public static void updateCustomerType(CustomerType customerType)
        {
            var cust = customerTypes.Find(c => c.Id == customerType.Id);
            cust = customerType;
        }


        public static void addCustomerTypeDatatoList()
        {
            customerTypes.Clear();
            string query = "SELECT * FROM customerType";
            var con = Configuration.getInstance().getConnection();
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }   
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    CustomerType customerType = new CustomerType();
                    customerType.Id = (int)reader["Id"];
                    customerType.Name = reader["name"].ToString();
                    customerType.discountPercentage = Convert.ToDecimal(reader["discountPercentage"]);
                    customerType.noOfAppointments = (int)reader["noOfAppointments"];
                    customerType.addedBy = (int)reader["createdBy"];
                    customerType.createdOn = reader["createdOn"].ToString();
                    customerType.updatedBy = reader["updatedBy"] != DBNull.Value ? (int)reader["updatedBy"] : (int?)null;
                    customerType.updatedOn = reader["updatedOn"] != DBNull.Value ? reader["updatedOn"].ToString() : null;   
                    addCustomerType(customerType);
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

        public static bool addValueToDB(CustomerType cT, int ownerActive)
        {
            bool isAdded = false;
            string query = $"EXEC stpAddCustomerType '{cT.Name}', {cT.discountPercentage}, {cT.noOfAppointments}, {ownerActive}";
            var connection = Configuration.getInstance().getConnection();
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    isAdded = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                addCustomerType(cT);
            }
            return isAdded;
        }
        public static List<string> GetCustomerTypeNames()
        {
            List<string> cT = new List<string>();
            foreach (CustomerType c in customerTypes)
            {
                cT.Add(c.Name);
            }
            return cT;
        }

        public static List<List<string>> getCustomerTypesToView()
        {
            List<List<string>> CustomerTypeData = new List<List<string>>();
            foreach (CustomerType c in customerTypes)
            {
                List<string> CustomerType = new List<string>();
                CustomerType.Add(c.Name);
                CustomerType.Add(c.discountPercentage.ToString());
                CustomerType.Add(c.noOfAppointments.ToString());
                CustomerType.Add(EmployeeDL.getName(c.addedBy));
                CustomerType.Add(c.createdOn);
                if (c.updatedBy != null)
                {
                    CustomerType.Add(EmployeeDL.getName((int)c.updatedBy));
                    CustomerType.Add(c.updatedOn);
                }
                else
                {
                    CustomerType.Add("N/A");
                    CustomerType.Add("N/A");
                }
                CustomerTypeData.Add(CustomerType);
            }
            return CustomerTypeData;
        }

        public static void updateCustomerTypeInDb(CustomerType uCustomerType, int ownerActive)
        {
            string query = $"EXEC stpUpdateCustomerType '{uCustomerType.Name}', {uCustomerType.discountPercentage}, {uCustomerType.noOfAppointments}, {ownerActive}, {uCustomerType.Id}";
            var connection = Configuration.getInstance().getConnection();
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Customer Type Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                updateCustomerType(uCustomerType);
            }
        }

        public static void deleteCustomerTypeFromDB(int id)
        {
            string query1 = $"SELECT count(*) FROM Customer Where customerTypeid = {id}";
            var connection1 = Configuration.getInstance().getConnection();
            int count = 0;
            try
            {
                using (SqlCommand command = new SqlCommand(query1, connection1))
                {
                    count = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (count > 0)
            {
                MessageBox.Show("Customer Type is in use and cannot be deleted");
                return;
            }
            else
            {
                string query = $"EXEC stpDeleteCustomerType {id}";
                var connection = Configuration.getInstance().getConnection();
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Customer Type Deleted Successfully");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        public static List<List<string>> getListBySearch(string filter, string searchTxt)
        {
            string query = $"SELECT name, noOfAppointment, discountPercentage, addedBy, createdOn, updatedBy, updatedOn FROM CustomerType Where {filter} like {searchTxt}";
            var connection = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            return null;
        }

    }
}
