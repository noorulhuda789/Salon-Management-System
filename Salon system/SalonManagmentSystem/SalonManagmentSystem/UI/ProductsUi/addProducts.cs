using Org.BouncyCastle.Bcpg;
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
    public partial class addProducts : UserControl
    {
        int ownerActive;
        

        public addProducts(int ownerActive)
        {
            
            InitializeComponent();
            this.ownerActive = ownerActive;
            LookupDL.loadLookupFromDB();
            populateComboBox();
        }
        

        public void populateComboBox()
        {
           
            producttypeCb.DataSource = productTypeDl.getNames();
            companyCB.DataSource = companyDL.getCompanyName();
            supplierComboBox.DataSource = supplierDL.getSupplierName();
        }





        private void add_btn_Click(object sender, EventArgs e)
        {


            string errorMessage = "An error occurred:";
            try
            {
                if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(restock.Text))
                {

                    errorMessage += "\nPlease fill in all the required fields.";
                    throw new Exception(errorMessage);
                }
                if (!validations.IsAlphaWithSpaces(name.Text))
                {
                    utils.ShowNameError();
                    return ;

                }
                if (!validations.IsValidInteger(restock.Text, 0))
                {
                    utils.ShowIntegerError("Restock Level");
                    return;
                }
                if (GetButton().Text == "update")
                {
                    productDL.updateProduct(getProductInput());
;
                }
                else {
                    if (productDL.nameAlreadyExists(getProductInput()))
                    {

                        errorMessage += "\nThe data already exists in the database. Please enter unique data.";
                        throw new Exception(errorMessage);
                    }

                    productDL.addProduct(getProductInput());

                    clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void clear()
        {
            name.Clear();
            restock.Clear();
        }

        public product getProductInput()
        {
            product p = new product(
                name.Text,
                int.Parse(restock.Text),
                supplierComboBox.SelectedValue.ToString(),
                companyCB.SelectedValue.ToString(),
                producttypeCb.SelectedValue.ToString(),
                DateTime.Now,
                DateTime.Now,
                LookupDL.getId("no"),0,0


                );
            return p;

        }

        private void supplier_Click(object sender, EventArgs e)
        {
            addSupplier f1 = new addSupplier(ownerActive);
            popUpForm f = new popUpForm();
            Panel p = f1.GetMainPanel();
            f.Add(f1, p);
            f.FormClosed += popUpForm_Closed; // Subscribe to FormClosed event
            f.Show();

        }

        private void company_Click(object sender, EventArgs e)
        {
            addCompany f1 = new addCompany();
            popUpForm f = new popUpForm();
            Panel p = f1.GetMainPanel();
            f.Add(f1, p);

            f.FormClosed += popUpForm_Closed; // Subscribe to FormClosed event
            f.Show();

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void producttype_Click(object sender, EventArgs e)
        {
            addProductType f1 = new addProductType();
            popUpForm f = new popUpForm();
            Panel p = f1.GetMainPanel();
            f.Add(f1, p);
            f.FormClosed += popUpForm_Closed; // Subscribe to FormClosed event
            f.Show();
        }

        private void popUpForm_Closed(object sender, FormClosedEventArgs e)
        {
            populateComboBox();
        }

        public Label GetLabel1()
        {
            return label1;
        }
        public  Guna.UI2.WinForms.Guna2Button GetButton()
        {
            return add_btn;
        }
        public Panel GetMainPanel()
        {
            return mainpanel;
        }
        public Guna.UI2.WinForms.Guna2TextBox addBox()
        {
            return name;
        }
        public Guna.UI2.WinForms.Guna2TextBox restocklevelBox()
        {
            return restock;
        }




    }
}

