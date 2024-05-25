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

namespace SalonManagmentSystem.UI.ProductsUi
{
   
    public partial class returnProducts : UserControl
    {
        public static string parameter1 = "";
        int ownerActive;
        public returnProducts(int ownerActive)
        {
            InitializeComponent();
            this.ownerActive = ownerActive;
            LookupDL.loadLookupFromDB();
            populate();
        }
        public Panel GetMainPanel()
        {
            return mainpanel;
        }

        public void populate()
        {
            supplierCB.DataSource=supplierDL.getSupplierName();
            companyCB.DataSource=companyDL.getCompanyName();
            productCB.DataSource=productDL.viewproducts();
            orderId.DataSource = productDL.getOrderId();

        }
        public product GetProductInput()
        {
            product p = new product(
                productCB.SelectedValue.ToString(),
                int.Parse(quantity.Text),
                reason.Text,
                int.Parse(orderId.SelectedValue.ToString()),
                supplierCB.SelectedValue.ToString(),
                companyCB.SelectedValue.ToString(),
                ownerActive,
                DateTime.Now,
                LookupDL.getId("return")
                
                );
            return p;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string errorMessage = "An error occurred:";
            try
            {

                if (
                    string.IsNullOrEmpty(quantity.Text)||
                    string.IsNullOrEmpty(reason.Text))
                {
                    errorMessage += "\nPlease fill in all the required fields.";
                    throw new Exception(errorMessage);
                    
                }
                if (!validations.IsValidInteger(quantity.Text, 0) )
                {
                    utils.ShowIntegerError("Quantity");
                    return;
                }
                if (!validations.IsAlphaWithSpaces(reason.Text))
                {
                    utils.ShowNameError();
                    return;
                }


                if (productDL.productQuantity(GetProductInput()))
                {
                    errorMessage += "The product quantity is less than the  quantity you enterted";
                    throw new Exception(errorMessage);
                    
                }
                if (productDL.productExistsForReturn(GetProductInput()))
                {
                    parameter1=productCB.SelectedValue.ToString();
                    productDL.returnProduct(GetProductInput());
                }
                else
                {
                    errorMessage += "\nProduct does not exists.";
                    throw new Exception(errorMessage);

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
        public static string nameapproach()
        {

            return parameter1;
        }
    }
}
