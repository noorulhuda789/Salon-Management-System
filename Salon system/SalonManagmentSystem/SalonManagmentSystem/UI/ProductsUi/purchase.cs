using SalonManagmentSystem.BL;
using SalonManagmentSystem.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SalonManagmentSystem.UI.ProductsUi
{
    public partial class purchase : UserControl
    {
        int ownerActive;
        public purchase(int ownerActive,string oderid,string productid)
        {
            InitializeComponent();
            this.ownerActive = ownerActive; 
            orderId.Text = oderid;
            productId.Text=productid;
            LookupDL.loadLookupFromDB();
        }

        public Panel GetMainPanel()
        {
            return mainpanel;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void orderId_TextChanged(object sender, EventArgs e)
        {

        }

        private void productId_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string errorMessage = "An error occurred:";
            try {
                if (string.IsNullOrEmpty(price.Text)
                || string.IsNullOrEmpty(quantity.Text) ){
                    errorMessage += "\nPlease fill in all the required fields.";
                    throw new Exception(errorMessage);
                }
                if (!validations.IsValidInteger(quantity.Text, 0)|| !validations.IsValidInteger(price.Text, 0))
                {
                    utils.ShowIntegerError("It");
                    return;
                }
                if (productDL.CheckQuantity("OrderDetails", GetProductInput()))
                {
                    errorMessage += "The ordered quantity is less than the  quantity you enterted";
                    throw new Exception(errorMessage);

                }

                productDL.purchaseProduct(GetProductInput());
               
                productDL.restockLevel(ownerActive, productId.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public product GetProductInput()
        {
         
            DateTime time = DateTime.Parse(timePicker.Text);
            product p = new product(
                 int.Parse(orderId.Text),
                int.Parse(quantity.Text),
                productId.Text,
                int.Parse(price.Text),
                time,
                DateTime.Now,
                DateTime.Now,
                ownerActive,
                LookupDL.getId("no"),
                LookupDL.getId("return"));

            return p;


        }
    }
}
