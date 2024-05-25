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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SalonManagmentSystem.UI.EmployeeUi
{
    public partial class updateEmp : Form
    {
        private string employeeId;

        private Dictionary<string, List<string>> provincesCitiesMapping = new Dictionary<string, List<string>>
        {
            { "Punjab", new List<string> { "Lahore", "Faisalabad", "Rawalpindi", "Multan","Bahwalpur", "Faisalabad", "Chiniot", "Gujranwala", "DG Khan" } },
            { "Sindh", new List<string> { "Karachi", "Hyderabad", "Sukkur", "Larkana", "Dadu", "Nawabshah" } },
            { "Khyber Pakhtunkhwa", new List<string> { "Peshawar", "Abbottabad", "Swat", "Mardan", "Bannu", "Kohat", "Swabi"} },
            { "Balochistan", new List<string> { "Quetta", "Gawadar", "Loralait", "Kalat", "Chaman", "Sibi" } },
        };

        public updateEmp(string employeeId)
        {
            InitializeComponent();
            // Store the passed employee ID in a private variable for later use
            this.employeeId = employeeId;
            InitializeProvinceComboBox();
            EmployeeDL.PopulateRoleDropdown(role_cb);
            EmployeeDL.PopulateGenderDropdown(gender_cb);
            PopulateEmployeeData(employeeId); // Populate employee data when the form is initialized
        }

        private void PopulateEmployeeData(string employeeId)
        {
            DataTable employeeData = EmployeeDL.GetEmployeeById(employeeId);
            if (employeeData != null && employeeData.Rows.Count > 0)
            {
                DataRow row = employeeData.Rows[0];
                name_tb.Text = row["name"].ToString();
                email_tb.Text = row["email"].ToString();
                address_tb.Text = row["address"].ToString();
                phone_tb.Text = row["phone"].ToString();
                gender_cb.SelectedItem = row["gender"].ToString();
                role_cb.SelectedItem = row["role"].ToString();
                salary_tb.Text = row["Salary"].ToString();
                username_tb.Text = row["username"].ToString();
                password_tb.Text = row["password"].ToString();
                jd_dtp.Value = Convert.ToDateTime(row["joiningDate"]);
            }
        }
        private void InitializeProvinceComboBox()
        {
            foreach (var province in provincesCitiesMapping.Keys)
            {
                province_cb.Items.Add(province);
            }
        }

        private void province_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProvince = province_cb.SelectedItem.ToString();
            PopulateCityComboBox(selectedProvince);
        }
        private void PopulateCityComboBox(string province)
        {
            city_cb.Items.Clear();
            if (provincesCitiesMapping.ContainsKey(province))
            {
                foreach (var city in provincesCitiesMapping[province])
                {
                    city_cb.Items.Add(city);
                }
            }
        }
        private bool CheckComboBoxInputs()
        {
            return utils.CheckComboBoxInput(gender_cb) && utils.CheckComboBoxInput(role_cb) &&
               utils.CheckComboBoxInput(province_cb) && utils.CheckComboBoxInput(city_cb);
        }



        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (!CheckComboBoxInputs())
            {
                utils.ShowMessage("Fill all combo boxes", "Incomplete Input");
                return;
            }
            if (!ValidateInput())
                return;

            // Get employee ID from the private variable
            int employeeId = Convert.ToInt32(this.employeeId);
            Person person = GetPersonInput();
            Employee employee = GetEmployeeInput();


            if (person != null && employee != null)
            {
                 if (EmployeeDL.UpdateEmployeeInDb(employeeId, person, employee))
                 { 
                     MessageBox.Show("Employee information updated successfully.");
                     ClearInputs();
                     this.Close();
                 }
                 else
                 {
                     MessageBox.Show("Failed to update employee information.");
                 }

            }
            else
                return;
        }

        public Employee GetEmployeeInput()
        {
            Employee employee = new Employee
            {
                Username = username_tb.Text,
                Password = password_tb.Text,
                JoiningDate = jd_dtp.Value.ToString()
            };
            if (decimal.TryParse(salary_tb.Text, out decimal salary))
            {
                employee.Salary = Convert.ToInt32(salary); // Assign the parsed salary value
            return employee;    
            }
            else
            {
                // Handle the case where the salary value cannot be parsed
                MessageBox.Show("Invalid salary value. Please enter a valid number.");
                return null; // Return null to indicate failure
            }
        }
        public Person GetPersonInput()
        {
            int g1, r1;
            g1 = EmployeeDL.GetGenderFromLookup(gender_cb.SelectedItem.ToString());
            r1 = EmployeeDL.GetRoleFromLookup(role_cb.SelectedItem.ToString());
            if (g1 == -1)
            {
                utils.ShowMessage("Invalid gender");
                return null;
            }
            if (r1 == -1)
            {
                utils.ShowMessage("Invalid role");
                return null;
            }
            Person person = new Person
            {
                Name = name_tb.Text,
                Email = email_tb.Text,
                Phone = phone_tb.Text,
                Address = address_tb.Text,
                City = city_cb.SelectedItem.ToString(),
                gender =g1,
                role = r1
            };
            return person;
        }
        public void ClearInputs()
        {
            salary_tb.Clear();
            username_tb.Clear();
            password_tb.Clear();
            jd_dtp.Value = DateTime.Now; // Set the joining date to current date or any default value

            name_tb.Clear();
            email_tb.Clear();
            phone_tb.Clear();
            address_tb.Clear();
            city_cb.SelectedIndex = -1; // Clear the selected city
            gender_cb.SelectedIndex = -1; // Clear the selected gender
            role_cb.SelectedIndex = -1; // Clear the selected role
        }
        public bool ValidateInput()
        {
            if (!validations.IsAlphaWithSpaces(name_tb.Text))
            {
                utils.ShowNameError();
                return false;
            }
            if (!validations.IsValidGmailAddress(email_tb.Text))
            {
                utils.ShowEmailError();
                return false;
            }
            if (!validations.IsValidPhoneNumber(phone_tb.Text))
            {
                utils.ShowPhoneNumberError();
                return false;
            }
            if (!validations.IsValidAddress(address_tb.Text))
            {
                utils.ShowAddressError();
                return false;
            }
            if (!validations.IsValidInteger(salary_tb.Text, 0))
            {
                utils.ShowIntegerError("salary");
                return false;
            }
            if (!validations.IsValidUsername(username_tb.Text))
            {
                utils.ShowUsernameError();
                return false;
            }
            if (!validations.IsValidPassword(password_tb.Text))
            {
                utils.ShowPasswordError();
                return false;
            }

            return true;
        }
    }
}
