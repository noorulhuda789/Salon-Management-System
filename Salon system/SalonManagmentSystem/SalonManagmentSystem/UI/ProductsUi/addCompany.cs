using Guna.UI2.WinForms.Suite;
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
    public partial class addCompany : UserControl
    {
        public addCompany()
        {
            InitializeComponent();
            LookupDL.loadLookupFromDB();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string errorMessage = "An error occurred:";
            try
            {
                if (string.IsNullOrEmpty(name.Text))
                {
                    errorMessage += "\nPlease fill in all the required fields.";
                    throw new Exception(errorMessage);

                }
                if (!validations.IsAlphaWithSpaces(name.Text))
                {
                    utils.ShowNameError();
                    return;
                }
                

                if (companyDL.alreadyExists(getProductInput()))
                {
                    errorMessage += "\nThe data already exists in the database. Please enter unique data.";
                    throw new Exception(errorMessage);
                }
                else
                {
                    if (GetButton().Text == "update")
                    {
                        companyDL.updateCompany(editCompany.nameApproach(),getProductInput());
                    }
                    else
                    {
                        if (companyDL.nameAlreadyExists(getProductInput()))
                        {
                            companyDL.updateCompanyStatus();

                        }
                        else
                        {
                            companyDL.addCompany(getProductInput());

                        }
                    }

                }

            }
            catch (Exception ex)
            {


                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public company getProductInput()
        {
            company t = new company(name.Text,
                DateTime.Now,
                DateTime.Now,
                LookupDL.getId("no"));
            return t;

        }
        public Panel GetMainPanel()
        {
            return mainpanel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public Label GetLabel()
        {
            return label1;
        }
        public Guna.UI2.WinForms.Guna2Button GetButton()
        {
            return guna2Button1;
        }
        public Guna.UI2.WinForms.Guna2TextBox GetTextBox()
        {
            return name;
        }
    }
}
