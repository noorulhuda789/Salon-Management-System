using Guna.UI2.WinForms;
using SalonManagmentSystem.DL;
using SalonManagmentSystem.UI.AppointmentUi;
using SalonManagmentSystem.UI.CustomersUi;
using SalonManagmentSystem.UI.EmployeeUi;
using SalonManagmentSystem.UI.Notifications;
using SalonManagmentSystem.UI.Receptionist;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonManagmentSystem.UI
{
    public partial class ReceptionistUi : Form
    {
        List<Guna2Button> buttons = new List<Guna2Button>();
        int ownerActive = -1;
        public ReceptionistUi(int ownerActive)
        {
            InitializeComponent();
            this.ownerActive = ownerActive;
            CustomerDL.loadCustomerDataFromDB();
            EmployeeDL.loadEmployeeDataFromDB();
            LookupDL.loadLookupFromDB();
            CustomerTypeDL.addCustomerTypeDatatoList();
            AppointmentDL.checkDateAndAppointmentStatus();
        }

        private void main_tablepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Appointments_btn_Click(object sender, EventArgs e)
        {
            center_uc center = addCentre_uc();
            AddButtonsToDropdownPanel(center, "View Appointments", "Add Appointment");
        }
        private void customers_btn_Click(object sender, EventArgs e)
        {
            center_uc center = addCentre_uc();
            AddButtonsToDropdownPanel(center, "View Customers", "Add Customer");
        }

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
                    if (button.Text == "Add Appointment")
                    {
                        addAppointment(center);
                    }
                    else if (button.Text == "View Appointments")
                    {
                        viewAppointments(center);
                    }
                    else if (button.Text == "Add Customer")
                    {
                        ShowAddCustomerPage(center);
                    }
                    else if (button.Text == "View Customers")
                    {
                        ShowViewCustomerPage(center);
                    }
                };

                center.DropdownPanel.Controls.Add(button);
            }
        }

        private void addAppointment(center_uc center)
        {

            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);
            addAppointment addAppointment = new addAppointment(ownerActive);
            addAppointment.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(addAppointment, 0, 1);
        }

        private void employees_btn_Click(object sender, EventArgs e)
        {
            RemoveAllControlsFromOuterPanel(main_tablepanel);
            ViewEmployees_uc ve = new ViewEmployees_uc();
            ve.Dock = DockStyle.Fill;
            main_tablepanel.Controls.Add(ve);
        }

        private void notifications_btn_Click(object sender, EventArgs e)
        {
            RemoveAllControlsFromOuterPanel(main_tablepanel);
            notifications_uc notify = new notifications_uc(ownerActive);
            notify.Dock = DockStyle.Fill;

            main_tablepanel.Controls.Add(notify);
        }

        private void viewAppointments(center_uc center)
        {
            RemoveAllControlsFromOuterPanel(center.OuterTablePanel);
            viewAppointments viewAppointments = new viewAppointments(ownerActive);
            viewAppointments.Dock = DockStyle.Fill;
            center.OuterTablePanel.Controls.Add(viewAppointments, 0, 1);
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Hide();

            loginScreen ls = new loginScreen();
            ls.Show();
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveAllControlsFromOuterPanel(main_tablepanel);

                // Load the image from resources
                System.Drawing.Image image = Properties.Resources.Pink_Luxury_Beauty_Salon_Logo__1_; // Replace "Pink_Luxury_Beauty_Salon_Logo_1" with the actual name of the image in your resources

                // Create a PictureBox control
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = image;
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

                // Set PictureBox properties
                pictureBox.Dock = DockStyle.Fill; // Fill the entire area of the Form1
                pictureBox.BackColor = Color.MistyRose; // Make the PictureBox background transparent

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
    }
}
