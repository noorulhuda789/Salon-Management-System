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

namespace SalonManagmentSystem.UI.ServicesUi
{
    public partial class typeUpdate : Form
    {
        int typeId;
        public typeUpdate(int typeId)
        {
            InitializeComponent();
            this.typeId = typeId;
        }

        private void closeForm_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveUpdated_btn_Click(object sender, EventArgs e)
        {
            string newTypeName = name_tb.Text.Trim();

            if (!validateInput())
                return;
            // Check if the type name is not empty
            if (!string.IsNullOrEmpty(newTypeName))
            {
                // Call the update method
                if (ServiceDL.UpdateServiceType(typeId, newTypeName))
                {
                    // Close the form if the update was successful
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Service type name cannot be empty.");
            }
        }
        private bool validateInput()
        {
            if (validations.IsAlphaWithSpaces(name_tb.Text))
            {
                MessageBox.Show("ServiceType can be only aphabets.");
                return false;
            }
            return true;
        }
    }
}
