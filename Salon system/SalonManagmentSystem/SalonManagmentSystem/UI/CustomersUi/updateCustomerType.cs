using SalonManagmentSystem.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalonManagmentSystem.DL;

namespace SalonManagmentSystem.UI.CustomersUi
{
    public partial class updateCustomerType : Form
    {
        CustomerType cT;
        int ownerActive;
        public delegate void CustomerTypeUpdatedEventHandler(object sender, EventArgs e);
        public event CustomerTypeUpdatedEventHandler CustomerTypeUpdated;
        public updateCustomerType(CustomerType customerType, int ownerActive)
        {
            InitializeComponent();
            this.ownerActive = ownerActive;
            this.cT = customerType;
            fillInputs();

        }
        protected virtual void OnCustomerTypeUpdated(EventArgs e)
        {
            CustomerTypeUpdated?.Invoke(this, e);
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fillInputs()
        {
            nameTxt.Text = cT.Name;
            discountTxt.Text = cT.discountPercentage.ToString();
            appointmentsTxt.Text = cT.noOfAppointments.ToString();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int id = CustomerTypeDL.getCustomerTypeID(cT.Name);
            CustomerType customerType = new CustomerType();
            customerType.Id = id;
            customerType.Name = nameTxt.Text;
            customerType.discountPercentage = Convert.ToDecimal(discountTxt.Text);
            customerType.noOfAppointments = Convert.ToInt32(appointmentsTxt.Text);
            CustomerTypeDL.updateCustomerTypeInDb(customerType, ownerActive);
            OnCustomerTypeUpdated(EventArgs.Empty);
        }
    }
}
