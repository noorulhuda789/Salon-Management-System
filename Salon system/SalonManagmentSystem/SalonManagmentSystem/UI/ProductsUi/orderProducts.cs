
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
    public partial class orderProducts : UserControl
    {
        int ownerActive;
        public static string parameter1 = "";
        public orderProducts(int ownerActive)
        {
            InitializeComponent();
            this.ownerActive = ownerActive;
            populateComboBox();
            LookupDL.loadLookupFromDB();
        }
        public Panel GetMainPanel()
        {
            return mainpanel;
        }
        public void populateComboBox()
        {
            productCb.DataSource = productDL.viewproducts();
            typecb.DataSource = productTypeDl.getNames();
            companyCb.DataSource = companyDL.getCompanyName();
            suppilerCb.DataSource = supplierDL.getSupplierName();


        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            addSupplier f1 = new addSupplier(ownerActive);
            popUpForm f = new popUpForm();
            Panel p = f1.GetMainPanel();
            f.Add(f1, p);
            f.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            addProductType f1 = new addProductType();
            popUpForm f = new popUpForm();
            Panel p = f1.GetMainPanel();
            f.Add(f1, p);
            f.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
 
        }
        public product GetProductInput()
        {
            
            product p = new product(
                productCb.SelectedValue.ToString(),
                int.Parse(qunatity.Text),
                companyCb.SelectedValue.ToString(),
                typecb.SelectedValue.ToString(),
                DateTime.Now,
                DateTime.Now,
                ownerActive,
                LookupDL.getId("no"));
            
            return p;
            

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {


        }

        private void company_Click(object sender, EventArgs e)
        {
            addCompany f1 = new addCompany();
            popUpForm f = new popUpForm();
            Panel p = f1.GetMainPanel();
            f.Add(f1, p);
            f.Show();

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            string errorMessage = "An error occurred:";
            try
            {
                if (string.IsNullOrEmpty(qunatity.Text))
                {

                    errorMessage += "\nPlease fill in all the required fields.";
                    throw new Exception(errorMessage);
                }
                if (!validations.IsValidInteger(qunatity.Text, 0))
                {
                    utils.ShowIntegerError("Quantity");
                    return;
                }

                if (productDL.productExists(GetProductInput()))
                {
                    parameter1=suppilerCb.SelectedValue.ToString();
                    productDL.orderProduct(GetProductInput());
                }
                else
                {

                    errorMessage += "\nProduct Does No exists";
                    throw new Exception(errorMessage);

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static string nameapproach()
        {

            return parameter1;
        }
    }
}
