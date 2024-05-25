using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SalonManagmentSystem.BL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SalonManagmentSystem.DL
{
    public class CustomerDL
    {
        public static  List<Customer> customers = new List<Customer>();

        private static void addCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public static Customer getCustomerById(int id)
        {
            return customers.Find(c => c.Id == id);
        }
        public static int getCustomerType(int id)
        {
            return customers.Find(c => c.Id == id).customerType;
        }

        public static Customer getCustomerByName(string name, string phone)
        {
            return customers.Find(c => c.Name == name && c.Phone == phone);
        }

        public static Customer getCustomer(string name)
        {
            return customers.Find(c => c.Name == name);
        }

        public List<Customer> getCustomers()
        {
            return customers;
        }

        private void updateCustomer(Customer customer)
        {
            var cust = customers.Find(c => c.Id == customer.Id);
            cust = customer;
        }

        public static bool addCustomerInDb(Customer customer)
        {
            bool isAdded = false;
            string query = $"EXEC stpAddCustomer '{customer.Name}', '{customer.Email}', '{customer.Address}','{customer.City}', '{customer.Country}', '{customer.Phone}',{customer.gender},{customer.addedBy}";
            var connection = Configuration.getInstance().getConnection();
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    isAdded = true;
                }
                addCustomer(customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return isAdded;
        }

        public static bool checkData(Customer c)
        {
            bool check = true;
            string query = $"SELECT count(*) FROM person WHERE name = '{c.Name}' and email = '{c.Email}' and address = '{c.Address}' and city = '{c.City}' and country = '{c.Country}' and phone = '{c.Phone}' ";
            var connection = Configuration.getInstance().getConnection();
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        check = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return check;
        }


        public static List<List<string>> getCustomersToView()
        {
            List<List<string>> CustomerData = new List<List<string>>();
            foreach (Customer c in customers)
            {
                if (c.status == LookupDL.getId("active"))
                {
                    List<string> Customer = new List<string>();
                    Customer.Add(c.Name);
                    Customer.Add(c.Email);
                    Customer.Add(c.Phone);
                    Customer.Add(c.Address);
                    Customer.Add(c.City);
                    Customer.Add(c.Country);
                    Customer.Add(LookupDL.getValue(c.gender));
                    Customer.Add(CustomerTypeDL.getCustomerTypeName(c.customerType));
                    Customer.Add(EmployeeDL.getName(c.addedBy));
                    Customer.Add(c.createdOn.ToString());
                    if (c.updatedBy != null)
                    {
                        Customer.Add(EmployeeDL.getName((int)c.updatedBy));
                    }
                    else Customer.Add("Not updated yet");
                    if (c.updatedOn != null)
                    {
                        Customer.Add(c.updatedOn.ToString());
                    }
                    else Customer.Add("Not updated yet");
                    CustomerData.Add(Customer);
                }
             }
            return CustomerData;
        }

        public static void updateCustomerInDb(Customer pCustomer, Customer uCustomer, int ownerActive)
        {

            string query1 = $"Update Person SET name = '{uCustomer.Name}', email = '{uCustomer.Email}', address = '{uCustomer.Address}', city = '{uCustomer.City}', gender = {uCustomer.gender}, phone = '{uCustomer.Phone}' WHERE id = (SELECT id FROM Person Where name = '{pCustomer.Name}' AND email = '{pCustomer.Email}' AND phone = '{pCustomer.Phone}' AND address = '{pCustomer.Address}' AND city = '{pCustomer.City}')";
            string query2 = $"Update Customer SET customerTypeid = {uCustomer.customerType}, updatedBy = {ownerActive}, updatedOn ='{DateTime.Now}' WHERE personid = (SELECT id FROM Person Where name = '{uCustomer.Name}' AND email = '{uCustomer.Email}' AND phone = '{uCustomer.Phone}' AND address = '{uCustomer.Address}' AND city = '{uCustomer.City}')";
            var con = Configuration.getInstance().getConnection();
            SqlCommand sqlCommand1 = new SqlCommand(query1, con);
            SqlCommand sqlCommand2 = new SqlCommand(query2, con);
            try
            {
                sqlCommand1.ExecuteNonQuery();
                sqlCommand2.ExecuteNonQuery();
                MessageBox.Show("Updated Succesfully");
                CustomerDL.loadCustomerDataFromDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public static bool deleteCustomerFromDB(int id , int ownerActive)
        {

            string query = $"EXEC stpDeleteCustomer {id}, {ownerActive}";
            var con = Configuration.getInstance().getConnection();
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
       
        public static void loadCustomerDataFromDB()
        {
            customers.Clear();
            string query = "SELECT * From viewCustomers";
            var con = Configuration.getInstance().getConnection();
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = (int)reader["Id"];
                    customer.Name = reader["name"].ToString();
                    customer.Email = reader["email"].ToString();
                    customer.Address = reader["address"].ToString();
                    customer.City = reader["city"].ToString();
                    customer.Country = reader["country"].ToString();
                    customer.Phone = reader["phone number"].ToString();
                    customer.gender = (int)reader["gender"];
                    customer.customerType = (int)reader["customerTypeId"];
                    customer.status = (int)reader["status"];
                    customer.createdOn = reader["createdOn"].ToString();
                    customer.updatedOn = reader["updatedOn"].ToString();
                    customer.addedBy = (int)reader["addedBy"];
                    if (reader["updatedBy"] != DBNull.Value)
                    {
                        customer.updatedBy = (int)reader["updatedBy"];
                    }
                    else
                    {
                        customer.updatedBy = null;
                    }
                    addCustomer(customer);
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

        public static List<List<string>> GetListBySearch( string f, string searchText) 
        {
            string query = "SELECT P.name, P.email, P.phone, P.address, P.city, P.country,  L1.value AS gender,  CS.name [customerType], C.createdOn, C.updatedOn , C.addedBy, C.updatedBy FROM   dbo.customer AS C   INNER JOIN  dbo.Person AS P ON C.personId = P.id  INNER JOIN  dbo.Lookup AS L1 ON P.gender = L1.lookupId AND L1.category = 'gender'  JOIN CustomerType CS ON CS.id = C.CustomerTypeId ";
            if (f == "name")
            {
                query = query +  $"Where P.name Like '%{searchText}%' AND P.status = (SELECT lookupid FROM lookup where value = 'active')";
            }
            else if(f == "customer Type")
            {
                query = query +  $"Where CS.name Like '%{searchText}%' AND P.status = (SELECT lookupid FROM lookup where value = 'active')";
            }
            else
            {
                query =  query + $" Where {f} Like '%{searchText}%' AND P.status = (SELECT lookupid FROM lookup where value = 'active')";
            }
            var con = Configuration.getInstance().getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            List<List<string>> customers = new List<List<string>>();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    List<string> customer = new List<string>();
                    customer.Add(reader["name"].ToString());
                    customer.Add(reader["email"].ToString());
                    customer.Add(reader["phone"].ToString());
                    customer.Add(reader["address"].ToString());
                    customer.Add(reader["city"].ToString());
                    customer.Add(reader["country"].ToString());
                    customer.Add(reader["gender"].ToString());
                    customer.Add(reader["CustomerType"].ToString());
                    customer.Add(EmployeeDL.getName((int)reader["addedBy"]));
                    customer.Add(reader["createdOn"].ToString());
                    if (reader["updatedBy"] == DBNull.Value)
                    {
                        customer.Add("N/A");
                    }
                    else
                    {
                        customer.Add(EmployeeDL.getName((int)reader["updatedBy"]));
                    }
                    if (reader["updatedOn"] == DBNull.Value)
                    {
                        customer.Add("N/A");
                    }
                    else
                    {
                        customer.Add(reader["updatedOn"].ToString());
                    }
                    customers.Add(customer);
                    
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
            return customers;
        }

        
    }
}
