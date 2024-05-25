using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using SalonManagmentSystem.DL;
using SalonManagmentSystem.BL;

namespace SalonManagmentSystem.UI.CustomersUi
{
    public partial class addCustomerTypes_uc : UserControl
    {
        int ownerActive;
        public addCustomerTypes_uc(int ownerActive)
        {
            InitializeComponent();
            this.ownerActive = ownerActive;
            CustomerTypeDL.addCustomerTypeDatatoList();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (checkInputs())
            {
                if (checkIfTypeExists(nameTxt.Text))
                {
                    CustomerType customerType = new CustomerType();
                    customerType.Name = nameTxt.Text;
                    customerType.discountPercentage = Convert.ToDecimal(discountTxt.Text);
                    customerType.noOfAppointments = Convert.ToInt32(appointmentsTxt.Text);
                    if(CustomerTypeDL.addValueToDB(customerType, ownerActive))
                    {
                        MessageBox.Show("Customer type added successfully");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add customer type");
                    }
                }
                else
                {
                    MessageBox.Show("Customer type already exists");
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields");
            }
        }

        private bool checkInputs()
        {
            if (nameTxt.Text == "")
            {
                MessageBox.Show("Please enter the name of the customer type");
                return false;
            }
            if (discountTxt.Text == "")
            {
                MessageBox.Show("Please enter the discount percentage of the customer type");
                return false;
            }
            if (appointmentsTxt.Text == "")
            {
                MessageBox.Show("Please enter the number of appointments of the customer type");
                return false;
            }
            return true;
        }


        private bool checkIfTypeExists(string name)
        {
            foreach (CustomerType type in CustomerTypeDL.customerTypes)
            {
                if (type.Name == name)
                {
                    return false;
                }
            }
            return true;
        }

        private void clear()
        {
            nameTxt.Text = "";
            discountTxt.Text = "";
            appointmentsTxt.Text = "";
        }
    }
}
