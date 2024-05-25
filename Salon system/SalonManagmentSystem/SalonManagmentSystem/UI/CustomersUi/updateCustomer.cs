using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SalonManagmentSystem.BL;
using SalonManagmentSystem.DL;
using System.Net.NetworkInformation;

namespace SalonManagmentSystem.UI.CustomersUi
{
    public partial class updateCustomer : Form
    {
       
        public delegate void CustomerUpdatedEventHandler(object sender, EventArgs e);
        public event CustomerUpdatedEventHandler CustomerUpdated;
        Customer c;
        int ownerActive;
        private List<string> customerTypes = new List<string>();
        private List<string> PakistanCities = new List<string>
        {
            "Lahore", "Faisalabad", "Rawalpindi", "Multan", "Karachi", "Hyderabad", "Sukkur", "Larkana", "Peshawar", "Abbottabad", "Swat", "Mardan", "Quetta", "Gwadar", "Khuzdar", "Turbat", "Gilgit", "Skardu", "Hunza", "Ghizer", "Muzaffarabad", "Mirpur", "Kotli", "Rawalakot"
        };
        public updateCustomer(Customer c, int ownerActive)
        {
            InitializeComponent();
            this.c = c;
            this.ownerActive = ownerActive;
           this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            populateComboBoxes();
            fillInputs();
        }
        protected virtual void OnCustomerUpdated(EventArgs e)
        {
            CustomerUpdated?.Invoke(this, e);
            this.Close(); 
        }
        private void populateComboBoxes()
        {
            List<string> list = CustomerTypeDL.GetCustomerTypeNames();
            foreach (string type in list)
            {
                CustomerTypeComboBox.Items.Add(type);
            }

            foreach (string city in PakistanCities)
            {
                cityComboBox.Items.Add(city);
            }
        }
        private int searchIndex()
        {
            for (int i= 0; i < customerTypes.Count; i++)
            {
                if (customerTypes[i] == CustomerTypeDL.getCustomerTypeName(c.customerType))
                {
                    return i;
                }
            }
            return -1;
        }

        private void fillInputs()
        {
            fulllNameTxt.Text = c.Name;
            emailTxt.Text = c.Email;
            streeAddressTxt.Text = c.Address;
            cityComboBox.SelectedItem = c.City;
            CustomerTypeComboBox.SelectedItem = CustomerTypeDL.getCustomerTypeName(c.customerType);
            phoneTxt.Text = c.Phone;
            if (LookupDL.getValue(c.gender) == "male")
            {
                maleRBtn.Checked = true;
            }
            else if (LookupDL.getValue(c.gender) == "female")
            {
                femaleRBtn.Checked = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            Customer uCustomer = createObject();
            if (CustomerDL.checkData(uCustomer))
            {
                MessageBox.Show("Customer Already Exists");
                return;
            }
            else
            {
                CustomerDL.updateCustomerInDb(c, uCustomer, ownerActive);
                CustomerDL.loadCustomerDataFromDB();
                OnCustomerUpdated(EventArgs.Empty);
            }
        }


        private Customer createObject()
        {
            Customer customer = new Customer();
            customer.Name = fulllNameTxt.Text;
            customer.Email = emailTxt.Text;
            customer.Address = streeAddressTxt.Text;
            customer.City = cityComboBox.SelectedItem.ToString();
            customer.Country = "Pakistan";
            customer.Phone = phoneTxt.Text;
            customer.status = LookupDL.getId("active");
            customer.role = LookupDL.getId("customer");
            customer.addedBy = ownerActive;
            customer.customerType = CustomerTypeDL.getCustomerTypeID(CustomerTypeComboBox.SelectedItem.ToString());
            if (maleRBtn.Checked)
            {
                customer.gender = LookupDL.getId("male");
            }
            if (femaleRBtn.Checked)
            {
                customer.gender = LookupDL.getId("female");
            }
            return customer;
        }

    }
}
