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

namespace SalonManagmentSystem.UI.ServicesUi
{
    public partial class updateServiceDetails : Form
    {
        int serviceId;
        private updateServiceProducts_uc updtServiceProductsForm; // Declare the form variable
        public updateServiceDetails(int serviceId)
        {

            InitializeComponent();
            this.serviceId = serviceId;
            PopulateServiceTypes();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveUpdated_btn_Click(object sender, EventArgs e)
        {
            // Check if the updtServiceProductsForm instance is null
            if (updtServiceProductsForm == null || updtServiceProductsForm.ProductIds == null)
            {
                MessageBox.Show("Select products before saving the service.");
                return;
            }

            List<int> productIds =  updtServiceProductsForm.ProductIds;
            if (productIds.Count == 0)
            {
                // Add service products
                MessageBox.Show("Select atleast one prodcut");
                return;
            }
            if (!validateInput())
                return;
            Service service = GetServiceInput();
            service.id = this.serviceId;

            if (service != null)
            {
                if (!ServiceDL.UpdateService(service))
                {
                    MessageBox.Show("Failed to add service to the database.");
                }
                else
                {
                    if (productIds.Count > 0)
                    {
                        // Add service products
                        ServiceDL.UpdateServiceProducts(serviceId, productIds);
                    }

                    // Clear form inputs after adding service
                    ClearFormInputs();
                }
            }
        }

        private void serviceProd_btn_Click(object sender, EventArgs e)
        {
            updtServiceProductsForm = new updateServiceProducts_uc(serviceId); // Initialize the form
            updtServiceProductsForm.Show(); // Show the form
        }
        private Service GetServiceInput()
        {
            // Get input from the form controls
            string name = name_tb.Text;
            string description = description_tb.Text;
            decimal serviceCharges = Convert.ToDecimal(price_tb.Text);
            decimal timeDuration = Convert.ToDecimal(duration_tb.Text);
            int serviceTypeId = GetSelectedServiceTypeId(); // Get the selected service type ID
            int isdel = GetDeleteStatus();

            // Create a new Service object with the input data
            Service service = new Service(name, serviceCharges, timeDuration, serviceTypeId, DateTime.Now, isdel, DateTime.Now, description);

            return service;
        }

        private void PopulateServiceTypes()
        {
            List<ServiceType> serviceTypes = ServiceDL.GetServiceTypes();

            serviceType_cb.Items.Clear();
            // Add service types to the combo box
            foreach (ServiceType serviceType in serviceTypes)
            {
                serviceType_cb.Items.Add(serviceType.Name);
            }

            // Select the first item by default
            if (serviceTypes.Count > 0)
            {
                serviceType_cb.SelectedIndex = 0;
            }
        }

        private int GetSelectedServiceTypeId()
        {
            string selectedServiceTypeName = serviceType_cb.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedServiceTypeName))
            {
                return ServiceDL.GetServiceTypeId(selectedServiceTypeName);
            }
            else
            {
                return -1;
            }
        }

        private int GetDeleteStatus()
        {
            string query = "SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no'";
            DataTable result = DataHandler.ExecuteQuery(query);

            // Check if the query returned any results
            if (result.Rows.Count > 0)
            {
                // Assuming the 'lookupid' column is of type int, you can convert the result to an int
                return Convert.ToInt32(result.Rows[0]["lookupId"]);
            }
            else
                return -1;
        }

        private void ClearFormInputs()
        {
            // Clear all form inputs\
           
            name_tb.Clear();
            description_tb.Clear();
            price_tb.Clear();
            duration_tb.Clear();
            serviceType_cb.SelectedIndex = -1; // Clear the selected service type
        }
        private bool validateInput()
        {
            if (!validations.IsAlphaWithSpaces(name_tb.Text))
            {
                utils.ShowNameError();
                return false;
            }
            if (!validations.IsValidDecimal(price_tb.Text, 0))
            {
                utils.ShowDecimalError("Service Charges");
                return false;
            }
            if (!validations.IsValidDecimal(duration_tb.Text, 1))
            {
                utils.ShowDecimalError("Time Duration");
                return false;
            }
            return true;
        }
    }
}
