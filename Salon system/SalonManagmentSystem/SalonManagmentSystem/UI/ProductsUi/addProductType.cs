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
using SalonManagmentSystem.BL;
using Guna.UI2.WinForms.Suite;
using Guna.UI2.WinForms;

namespace SalonManagmentSystem.UI.ProductsUi
{
    public partial class addProductType : UserControl
    {
        public addProductType()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string errorMessage = "An error occurred:";
            try
            {


                if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(description.Text))
                {
                    errorMessage += "\nPlease fill in all the required fields.";
                    throw new Exception(errorMessage);

                }
                if (!validations.IsAlphaWithSpaces(name.Text)
                   || !validations.IsAlphaWithSpaces(description.Text))
                {
                    utils.ShowNameError();
                    return;
                }


                if (GetButton().Text == "update")
                {
                    productTypeDl.updateType(editprodoductType.nameApproach(), getProductInput());

                }
                else
                {
                    if (productTypeDl.alreadyExists(getProductInput()))
                    {
                        errorMessage += "\nThe data already exists in the database. Please enter unique data.";
                        throw new Exception(errorMessage);

                    }
                    productTypeDl.addProductType(getProductInput());

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }
         public ProductsType getProductInput()
        {
            ProductsType t = new ProductsType(name.Text,
             description.Text,
             DateTime.Now,
             DateTime.Now,
             LookupDL.getId("no"));
            return t;

        }
        public Panel GetMainPanel()
        {
            return mainpanel;
        }
        public Label GetLabel()
        {
            return label1;
        }
        public Guna2TextBox GetTextBox()
        {
            return name;
        }
        public Guna2TextBox Getd()
        {
            return description;
        }
        public Guna2Button GetButton()
        {
            return guna2Button1;
        }




    }
}
