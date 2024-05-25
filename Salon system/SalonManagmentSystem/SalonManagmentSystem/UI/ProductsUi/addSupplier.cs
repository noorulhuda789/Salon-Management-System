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

    public partial class addSupplier : UserControl
    {

        private List<string> PakistanCities = new List<string>
        {
            "Lahore", "Faisalabad", "Rawalpindi", "Multan", "Karachi", "Hyderabad", "Sukkur", "Larkana", "Peshawar", "Abbottabad", "Swat", "Mardan", "Quetta", "Gwadar", "Khuzdar", "Turbat", "Gilgit", "Skardu", "Hunza", "Ghizer", "Muzaffarabad", "Mirpur", "Kotli", "Rawalakot"
        };
        private int ownerActive;
        public addSupplier(int ownerActive)
        {
            InitializeComponent();
            LookupDL.loadLookupFromDB();
            this.ownerActive = ownerActive;
            populateComboBoxes();
        }
       
        public void populateComboBoxes()
        {
            citiecb.DataSource = PakistanCities;
            countrycb.Items.Add("Pakistan");
            countrycb.SelectedIndex = 0;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string errorMessage = "An error occurred:";
            try {
                if (!CheckInputs())
                {
                    errorMessage += "\nPlease fill in all the required fields.";
                    throw new Exception(errorMessage);
                }
                if (!validations.IsAlphaWithSpaces(name.Text))
                {
                    utils.ShowNameError();
                    return;
                }
                if (!validations.IsValidPhoneNumber(contact.Text))
                {
                    utils.ShowPhoneNumberError();
                    return ;
                }
                if (!validations.IsValidAddress(address.Text))
                {
                    utils.ShowAddressError();
                    return ;
                }
                if (GetAddButton().Text == "update")
                {
                    editSupplier a = new editSupplier(ownerActive);
                    
                   
                    supplierDL.updateSupplier(editSupplier.nameapproach(), getSupplierData());


                }
                else {
                    if (supplierDL.nameAlreadyExists(getSupplierData()))
                    {
                        errorMessage += "\nThe data already exists in the database. Please enter unique data.";
                        throw new Exception(errorMessage);
                    }
                    supplierDL.addSupplier(getSupplierData());
                }

                
            }
            catch (Exception ex){
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private supplier getSupplierData()
        {
            supplier s = new supplier(
                name.Text,
                (address.Text + ',' + citiecb.SelectedItem.ToString() + countrycb.SelectedItem.ToString())
                , contact.Text,
                LookupDL.getId("no"),DateTime.Now,
                DateTime.Now,ownerActive);
            return s;
        }
        private bool CheckInputs()
        {
            return !string.IsNullOrWhiteSpace(name.Text)
                   && !string.IsNullOrWhiteSpace(address.Text)
                   && !string.IsNullOrWhiteSpace(contact.Text)
                   && countrycb.SelectedIndex != 1
                   && citiecb.SelectedIndex != -1;
        }
        public Panel GetMainPanel()
        {
            return mainpanel;
        }
        public Guna.UI2.WinForms.Guna2Button GetAddButton()
        {
            return guna2Button1;
        }

        public Label getlabel()
        {
            return label1;
        }
        public Guna.UI2.WinForms.Guna2TextBox getName()
        {
            return name;
        }
        public Guna.UI2.WinForms.Guna2TextBox Contact(){

            return contact;
        }
        public System.Windows.Forms.RichTextBox Address()
        {
            return address;
        }
    }
}
