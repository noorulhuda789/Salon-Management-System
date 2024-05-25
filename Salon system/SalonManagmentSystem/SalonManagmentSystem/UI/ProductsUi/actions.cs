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
    public partial class actions : UserControl
    {
        public static string parameter1 = "";
        int ownerActive;
        public actions(int ownerActive)
        {
            InitializeComponent();
            this.ownerActive = ownerActive;
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public Panel GetMainPanel()
        {
            return mainpanel;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            orderProducts f1 = new orderProducts(ownerActive);
            popUpForm f = new popUpForm();
            Panel p = f1.GetMainPanel();
            f.Add(f1, p);
            f.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {

                // Create the returnProduct form and show it
                returnProducts f1 = new returnProducts(ownerActive);
                popUpForm f = new popUpForm();
                Panel p = f1.GetMainPanel();
                f.Add(f1, p);

                f.FormClosed += (s, args) => popUpForm_Closed(s, args, () => returnProducts.nameapproach());

                f.Show();
                parameter1 = returnProducts.nameapproach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void popUpForm_Closed(object sender, FormClosedEventArgs e, Func<string> name)
        {
            parameter1 =name();
            
            productDL.restockLevel(ownerActive, parameter1); // Call restockLevel function
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            discardProduct f1 = new discardProduct(ownerActive);
            popUpForm f = new popUpForm();
            Panel p = f1.GetMainPanel();
            f.Add(f1, p);
            f.FormClosed += (s, args) => popUpForm_Closed(s, args, () => discardProduct.nameapproach());
            f.Show();
            




        }

    }
}
