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
    public partial class discardProduct : UserControl
    {
        int ownerActive;
        public static string parameter1 = "";
        public discardProduct(int ownerActive)
        {
            InitializeComponent();
            this.ownerActive = ownerActive;
            polpulateGrid();
        }

        public void polpulateGrid()
        {
            productytpecb.DataSource= productTypeDl.getNames();
            companyCb.DataSource = companyDL.getCompanyName();
            productCb.DataSource = productDL.getNames();
            

        }
        public Panel GetMainPanel()
        {
            return mainpanel;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            string errorMessage = "An error occurred:";
            try
            {
                
                if (
                    string.IsNullOrEmpty(quantity.Text) ){
                    errorMessage += "\nPlease fill in all the required fields.";
                    throw new Exception(errorMessage);
                }
                if (!validations.IsValidInteger(quantity.Text, 0))
                {
                    utils.ShowIntegerError("Quantity");
                    return;
                }
                if (productDL.productQuantity( GetProductInput()))
                {
                    errorMessage += "The product quantity is less than the  quantity you enterted";
                    throw new Exception(errorMessage);
                }
                parameter1=productCb.SelectedValue.ToString();
                if (productDL.productExists(GetProductInput()))
                {
                    productDL.discardProduct(GetProductInput());
                }
                else{
                    errorMessage += "\nProduct does not exists.";
                    throw new Exception(errorMessage);

                }
               
            }
            catch(Exception ex) {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public product GetProductInput()
        {
            product p = new product(
                productCb.SelectedValue.ToString(),
                int.Parse(quantity.Text),
                productytpecb.SelectedValue.ToString(),
                companyCb.SelectedValue.ToString(),
                DateTime.Now,
                ownerActive
               );
            return p;

        }
        public static string nameapproach()
        {

            return parameter1;
        }
    }
}
