using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalonManagmentSystem.BL;
using System.Data.SqlClient;
using SalonManagmentSystem.DL;

namespace SalonManagmentSystem.UI.CustomersUi
{
    public partial class addCustomer_uc : UserControl
    {
        private List<string> PakistanCities = new List<string> 
        {
            "Lahore", "Faisalabad", "Rawalpindi", "Multan", "Karachi", "Hyderabad", "Sukkur", "Larkana", "Peshawar", "Abbottabad", "Swat", "Mardan", "Quetta", "Gwadar", "Khuzdar", "Turbat", "Gilgit", "Skardu", "Hunza", "Ghizer", "Muzaffarabad", "Mirpur", "Kotli", "Rawalakot"
        };
        private int ownerActive;
        public addCustomer_uc(int ownerActive)
        {
            InitializeComponent();
            this.ownerActive = ownerActive;
            LookupDL.loadLookupFromDB();
            CustomerTypeDL.addCustomerTypeDatatoList();
            LoadCities();
        }
        private void LoadCities()
        {
            foreach (string city in PakistanCities)
            {
                cityComboBox.Items.Add(city);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (checkInputs())
            {
                Customer customer = createObject();
                if (CustomerDL.checkData(customer))
                {
                    bool flag = CustomerDL.addCustomerInDb(customer);
                    if (flag)
                    {
                        clear();
                        MessageBox.Show("Customer Added Successfully");
                        CustomerDL.loadCustomerDataFromDB();
                    }

                }
                else
                {
                    MessageBox.Show("Customer Already Exists");
                }
            }
            else
            {
                MessageBox.Show("Fill All Fields");
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
            customer.customerType = CustomerTypeDL.getCustomerTypeID("Basic");
            if (maleRBtn.Checked)
            {
                customer.gender = LookupDL.getId("male");
            }
            if (femaleRBtn.Checked)
            {
                customer.gender = LookupDL.getId("female");
            }
            MessageBox.Show("g" + customer.gender + "r" + customer.role);
            return customer;
        }

        


        private bool checkInputs()
        {
            bool check = true;
            if (fulllNameTxt.Text == "" || emailTxt.Text == "" || phoneTxt.Text == "" || streeAddressTxt.Text == "" || (maleRBtn.Checked && femaleRBtn.Checked) || cityComboBox.SelectedIndex == -1)
            {
                check = false;
            }
            return check;
        }

        

        private void clear()
        {
            fulllNameTxt.Text = "";
            emailTxt.Text = "";
            streeAddressTxt.Text = "";
            phoneTxt.Text = "";
            maleRBtn.Checked = false;
            femaleRBtn.Checked = false;
            cityComboBox.SelectedIndex = -1;
        }


    }
}

