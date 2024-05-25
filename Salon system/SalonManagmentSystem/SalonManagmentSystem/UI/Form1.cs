using Guna.UI2.WinForms;
using SalonManagmentSystem.UI.CustomersUi;
using SalonManagmentSystem.UI.EmployeeUi;
using SalonManagmentSystem.UI.Notifications;
using SalonManagmentSystem.UI.ProductsUi;
using SalonManagmentSystem.UI.ServicesUi;
using SalonManagmentSystem.UI;
using SalonManagmentSystem.DL;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SalonManagmentSystem.UI.Reports;
using System.Web.UI.WebControls;

namespace SalonManagmentSystem
{
    public partial class Form1 : Form
    {
        List<Guna2Button> buttons = new List<Guna2Button>();
        int ownerActive, role;
        public Form1(int ownerActive)
        {
            InitializeComponent();
            this.ownerActive = ownerActive;
            
            CustomerDL.loadCustomerDataFromDB();
            LookupDL.loadLookupFromDB();
            EmployeeDL.loadEmployeeDataFromDB();
            CustomerTypeDL.addCustomerTypeDatatoList();
        }

        //Button Click Function

        private void employees_btn_Click(object sender, EventArgs e)
        {
            center_uc center = addCentre_uc();
            AddButtonsToDropdownPanel(center, "Update Employee Attendance", "Mark Employee Attendance", "Generate Employee Salaries", "View Employee Salaries","Manage User Roles", "Employee Personal Details", "Add Employees");
        }

        private void customers_btn_Click(object sender, EventArgs e)
        {
            center_uc center = addCentre_uc();
            AddButtonsToDropdownPanel(center, "View Customer Types", "Add Customer Type", "View Customers", "Add Customer");
        }

        private void notifications_btn_Click(object sender, EventArgs e)
        {
            RemoveAllControlsFromOuterPanel(main_tablepanel);
            notifications_uc notify = new notifications_uc(ownerActive);
            notify.Dock = DockStyle.Fill;

            main_tablepanel.Controls.Add(notify);
        }

        private void products_btn_Click(object sender, EventArgs e)
        {
            RemoveAllControlsFromOuterPanel(main_tablepanel);

            center_uc center = new center_uc();
            center.Dock = DockStyle.Fill;

            main_tablepanel.Controls.Add(center);

            AddButtonsToDropdownPanel(center, "Product Type Details", "Company Details", "Supplier Details", "Order Details", "Product Details", "Add Product Type", "Add Company", "Add Supplier", "Add Product");

        }

        private void services_btn_Click(object sender, EventArgs e)
        {
            RemoveAllControlsFromOuterPanel(main_tablepanel);

            center_uc center = new center_uc();
            center.Dock = DockStyle.Fill;

            main_tablepanel.Controls.Add(center);

             AddButtonsToDropdownPanel(center,"Service Types" , "Add Service", "View Service Details");
        }


        /////////////////////////////// center uc customizations ///////////////////////////////
        private center_uc addCentre_uc()
        {
            RemoveAllControlsFromOuterPanel(main_tablepanel);

            center_uc center = new center_uc();
            center.Dock = DockStyle.Fill;

            main_tablepanel.Controls.Add(center);
            return center;
        }
        public void RemoveAllControlsFromOuterPanel(TableLayoutPanel panel)
        {

            Control control = panel.GetControlFromPosition(0, 1);
            if (control != null)
            {
                panel.Controls.Remove(control);
                control.Dispose();
            }
        }

        private void AddButtonsToDropdownPanel(center_uc center, params string[] buttonLabels)
        {
            foreach (string label in buttonLabels)
            {
                Guna2Button button = new Guna2Button();
                button.Text = label;
                button.Dock = DockStyle.Left;
                button.TextAlign = HorizontalAlignment.Center;
                button.Margin = new Padding(0, 1, 0, 0);
                button.ForeColor = Color.FromArgb(1, 112, 117);
                button.Font = new Font("Tw Cen MT", 14, FontStyle.Regular);
                button.BackColor = Color.Transparent;
                button.FillColor = Color.FromArgb(255, 215, 185);
                button.AutoSize = true;
                button.CustomBorderThickness = new Padding(0, 0, 0, 3);
                button.CustomBorderColor = Color.Transparent;

                //hower state ui design
                button.HoverState.CustomBorderColor = Color.FromArgb(1, 112, 117);
                button.HoverState.FillColor = Color.FromArgb(255, 215, 185);
                //checked state ui design
                button.CheckedState.CustomBorderColor = Color.FromArgb(1, 112, 117);
                button.CheckedState.FillColor = Color.FromArgb(255, 215, 185);

                buttons.Add(button);

                // Event handler for button click
                button.Click += (sender, e) =>
                {
                    foreach (var otherButton in buttons)
                    {
                        if (otherButton != button)
                        {
                            otherButton.Checked = false;
                        }
                    }
                    // Check which button was clicked
                    if (button.Text == "View Employee Salaries")
                    {
                        button.Checked = true;
                        ShowViewSalariesPage(center);
                    }
                    else if (button.Text == "Generate Employee Salaries")
                    {
                        button.Checked = true;
                        ShowGenerateSalriesPage(center);
                    }
                    else if (button.Text == "Employee Personal Details")
                    {
                        button.Checked = true;
                        ShowEmployeeDetailsPage(center);
                    }
                    else if (button.Text == "Add Employees")
                    {   
                        button.Checked = true;
                        ShowAddEmployeePage(center);
                    }
                    else if (button.Text == "Add Customer")
                    {
                        button.Checked = true;
                        ShowAddCustomerPage(center);
                    }
                    else if (button.Text == "View Customers")
                    {
                        button.Checked = true;
                        ShowViewCustomerPage(center);
                    }
                    else if (button.Text == "Add Customer Type")
                    {
                        button.Checked = true;
                        ShowAddCustomerTypePage(center);
                    }
                    else if (button.Text == "View Customer Types")
                    {
                        button.Checked = true;
                        ShowViewCustomerTypePage(center);
                    }
                    else if (button.Text == "Manage User Roles")
                    { 
                        button.Checked = true;
                        ShowUserRoles(center);
                    }
                    else if (button.Text == "Mark Employee Attendance")
                    {
                        button.Checked = true;
                        ShowMarkAttendancePage(center);
                    }
                    else if (button.Text == "Update Employee Attendance")
                    {
                        button.Checked = true;
                        ShowUpdateAttendancePage(center);
                    }
                    else if (button.Text == "View Service Details")
                    {
                        button.Checked = true;
                        ShowServicesPage(center);
                    }
                    else if (button.Text == "Add Service")
                    {
                        button.Checked = true;
                        ShowAddServicePage(center);
                    }
                    else if (button.Text == "Service Types")
                    {
                        button.Checked = true;
                        ShowServiceTypesPage(center);
                    }
                    else if (button.Text == "Add Company")
                    {
                        button.Checked = true;
                        showAddCompany(center);
                    }
                    else if (button.Text == "Add Product")
                    {
                            button.Checked = true;
                        showAddProduct(center);
                    }
                    else if (button.Text == "Add Product Type")
                    {
                        button.Checked = true;
                        showAddProductType(center);
                    }
                    else if (button.Text == "Add Supplier")
                    {
                        button.Checked = true;
                        showAddSupplier(center);
                    }
                    else if (button.Text == "Product Details")
                    {
                        button.Checked = true;
                        showProductDetails(center);
                    }
                    else if (button.Text == "Order Details")
                    {
                        button.Checked = true;
                        showOrderDetails(center);
                    }
                    else if (button.Text == "Supplier Details")
                    {
                        showSupplierDetails(center);
                    }
                    else if (button.Text == "Company Details")
                    {
                        showCompanyDetails(center);
                    }
                    else if (button.Text == "Product Type Details")
                    {
                        showtypeDetails(center);
                    };

                };
                center.DropdownPanel.Controls.Add(button);
            }
        }

        


        ////////////////////////////// Functions  to add the ui of inner buttons //////////////////////////////
        private void ShowEmployeeDetailsPage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);
            // Create and add employees_uc to the first row of outer_panel
            employees_uc employeesUC = new employees_uc(ownerActive);
            employeesUC.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(employeesUC, 0, 1);
        }
        private void ShowAddEmployeePage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add employees_uc to the first row of outer_panel
            addEmp_uc addUC = new addEmp_uc();
            addUC.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(addUC, 0, 1);
        }

        private void ShowAddCustomerPage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add addCustomer_uc to the first row of outer_panel
            addCustomer_uc addCustomerUC = new addCustomer_uc(ownerActive);
            addCustomerUC.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(addCustomerUC, 0, 1);
        }
        private void ShowViewCustomerPage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add addCustomer_uc to the first row of outer_panel
            viewCustomer_uc vc = new viewCustomer_uc(ownerActive);
            vc.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(vc, 0, 1);
        }
        private void ShowAddCustomerTypePage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add addCustomer_uc to the first row of outer_panel
            addCustomerTypes_uc addcustomerType_Uc = new addCustomerTypes_uc(ownerActive);
            addcustomerType_Uc.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(addcustomerType_Uc, 0, 1);
        }
        private void ShowViewCustomerTypePage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add addCustomer_uc to the first row of outer_panel
            viewCustomerTypes_uc vc = new viewCustomerTypes_uc(ownerActive);
            vc.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(vc, 0, 1);
        }
        private void ShowUserRoles(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add addCustomer_uc to the first row of outer_panel
            userRoles_uc ur = new userRoles_uc();
            ur.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(ur, 0, 1);
        }
        

        private void showAddProduct(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add employees_uc to the first row of outer_panel
            addProducts employeesUC = new addProducts(ownerActive);
            employeesUC.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(employeesUC, 0, 1);
        }

        private void showAddSupplier(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add employees_uc to the first row of outer_panel
            addSupplier employeesUC = new addSupplier(ownerActive);
            employeesUC.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(employeesUC, 0, 1);
        }

        private void showOrderDetails(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add employees_uc to the first row of outer_panel
            orderDetails employeesUC = new orderDetails(ownerActive);
            employeesUC.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(employeesUC, 0, 1);
        }
        private void showSupplierDetails(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add employees_uc to the first row of outer_panel
            editSupplier employeesUC = new editSupplier(ownerActive);
            employeesUC.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(employeesUC, 0, 1);
        }
        private void showCompanyDetails(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add employees_uc to the first row of outer_panel
            editCompany employeesUC = new editCompany();
            employeesUC.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(employeesUC, 0, 1);
        }
        private void showtypeDetails(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add employees_uc to the first row of outer_panel
            editprodoductType employeesUC = new editprodoductType();
            employeesUC.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(employeesUC, 0, 1);
        }

        private void showAddCompany(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add employees_uc to the first row of outer_panel
            addCompany employeesUC = new addCompany();
            employeesUC.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(employeesUC, 0, 1);

        }
        private void showAddProductType(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add employees_uc to the first row of outer_panel
            addProductType employeesUC = new addProductType();
            employeesUC.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(employeesUC, 0, 1);

        }
        private void showProductDetails(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);

            // Create and add employees_uc to the first row of outer_panel
            productDetails employeesUC = new productDetails(ownerActive);
            employeesUC.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(employeesUC, 0, 1);
        }
        private void ShowMarkAttendancePage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);
            // Create and add employees_uc to the first row of outer_panel
            markAttendance_uc ma = new markAttendance_uc();
            ma.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(ma, 0, 1);
        }
        private void ShowUpdateAttendancePage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);
            // Create and add employees_uc to the first row of outer_panel
            updateAttendance_uc ua = new updateAttendance_uc();
            ua.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(ua, 0, 1);
        }

        private void ShowServicesPage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);
            // Create and add employees_uc to the first row of outer_panel
            serviceDetails_uc sd = new serviceDetails_uc();
            sd.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(sd, 0, 1);
        }
        private void ShowAddServicePage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);
            // Create and add employees_uc to the first row of outer_panel
            addService aS = new addService(this.ownerActive);
            aS.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(aS, 0, 1);
        }
        private void ShowServiceTypesPage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);
            // Create and add employees_uc to the first row of outer_panel
            serviceType_uc st = new serviceType_uc();
            st.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(st, 0, 1);
        }
        private void ShowViewSalariesPage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);
            // Create and add employees_uc to the first row of outer_panel
            viewSalaries_uc vs = new viewSalaries_uc();
            vs.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(vs, 0, 1);
        }

        private void ShowGenerateSalriesPage(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);
            // Create and add employees_uc to the first row of outer_panel
            generateSalaries gs = new generateSalaries();
            gs.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(gs, 0, 1);
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Hide();

            loginScreen ls = new loginScreen();
            ls.Show();
        }

        private void reports_btn_Click(object sender, EventArgs e)
        {
            RemoveAllControlsFromOuterPanel(main_tablepanel);

            MainReportPage center = new MainReportPage();
            center.Dock = DockStyle.Fill;

            main_tablepanel.Controls.Add(center);
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveAllControlsFromOuterPanel(main_tablepanel);

                // Load the image from resources
                System.Drawing.Image image = Properties.Resources.Pink_Luxury_Beauty_Salon_Logo1; // Replace "Pink_Luxury_Beauty_Salon_Logo_1" with the actual name of the image in your resources

                // Create a PictureBox control
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = image;
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

                // Set PictureBox properties
                pictureBox.Dock = DockStyle.Fill; // Fill the entire area of the Form1
                pictureBox.BackColor = Color.Transparent; // Make the PictureBox background transparent

                Control control = main_tablepanel.GetControlFromPosition(0, 1);
                main_tablepanel.Controls.Add(pictureBox);

                // Bring the PictureBox to the front so it's visible
                pictureBox.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
