using SalonManagmentSystem.UI.ProductsUi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SalonManagmentSystem.BL;
using System.Windows.Forms;
using SalonManagmentSystem.DL;
using System.Web.Configuration;

namespace SalonManagmentSystem.UI.CustomersUi
{
    public partial class viewCustomer_uc : UserControl
    {
        private int ownerActive;
        string role = "";
        public viewCustomer_uc(int ownerActive)
        {
            this.ownerActive = ownerActive;
            InitializeComponent();
            role = LookupDL.getValue(EmployeeDL.getrole(ownerActive));
            bindTableView();

        }

        private void bindTableView()
        {
            viewCustomers.Rows.Clear();

            List<List<string>> data = CustomerDL.getCustomersToView();
            List<string> headers = new List<string>();
            if (role == "owner")
            {
                headers = new List<string> { "Name", "Email", "Phone", "Address", "City", "Country", "Gender", "Customer Type", "Added By", "Joining Date", "Updated By", "Updated On" };
                for (int i = 0; i < headers.Count; i++)
                {
                    viewCustomers.Columns.Add(headers[i], headers[i]);
                }
                for (int i = 0; i < data.Count; i++)
                {
                    viewCustomers.Rows.Add(data[i].ToArray());
                }
            }
            else if (role == "receptionist")
            {
                headers = new List<string> { "Name", "Email", "Phone", "Address", "City", "Country", "Gender", "Customer Type" };
                for (int i = 0; i < headers.Count; i++)
                {
                    viewCustomers.Columns.Add(headers[i], headers[i]);
                }
                for (int i = 0; i < data.Count; i++)
                {
                    viewCustomers.Rows.Add(data[i].ToArray());
                }
            }

            addButtons();


        }
        private void refresh(List<List<string>> data)
        {
            viewCustomers.Rows.Clear();
            viewCustomers.Columns.Clear();
            List<string> headers = new List<string> { "Name", "Email", "Phone", "Address", "City", "Country", "Gender", "Customer Type", "Added By", "Joining Date", "Updated By", "Updated On" };
            for (int i = 0; i < headers.Count; i++)
            {
                viewCustomers.Columns.Add(headers[i], headers[i]);
            }
            foreach (List<string> row in data)
            {
                viewCustomers.Rows.Add(row.ToArray());
            }
            addButtons();
            foreach (DataGridViewColumn column in viewCustomers.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void addButtons()
        {
            // Create a DataGridViewButtonColumn
            viewCustomers.AutoGenerateColumns = false;
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.HeaderText = "Update";
            buttonColumn1.Text = "Update";
            buttonColumn1.UseColumnTextForButtonValue = true;
            viewCustomers.Columns.Add(buttonColumn1);

            viewCustomers.AutoGenerateColumns = false;
            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            buttonColumn2.HeaderText = "Delete";
            buttonColumn2.Text = "Delete";
            buttonColumn2.UseColumnTextForButtonValue = true;
            viewCustomers.Columns.Add(buttonColumn2);
        }

        private void viewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = viewCustomers.SelectedCells[0].RowIndex;
            string name = viewCustomers.Rows[index].Cells[0].Value.ToString();
            string email = viewCustomers.Rows[index].Cells[1].Value.ToString();
            string phone = viewCustomers.Rows[index].Cells[2].Value.ToString();
            string address = viewCustomers.Rows[index].Cells[3].Value.ToString();
            string city = viewCustomers.Rows[index].Cells[4].Value.ToString();
            string country = viewCustomers.Rows[index].Cells[5].Value.ToString();
            string gender = viewCustomers.Rows[index].Cells[6].Value.ToString();
            string customerType = viewCustomers.Rows[index].Cells[7].Value.ToString();
            Customer c = new Customer();
            c.Name = name;
            c.Email = email;
            c.Phone = phone;
            c.Address = address;
            c.City = city;
            c.Country = country;
            c.gender = LookupDL.getId(gender);
            c.customerType = CustomerTypeDL.getCustomerTypeID(customerType);
            int id = CustomerDL.getCustomerByName(name, phone).Id;
            if (role == "owner")
            {
                if (e.ColumnIndex == 12)
                {

                    updateCustomer(c);
                }
                else if (e.ColumnIndex == 13)
                {
                    deleteCustomer(id);
                }
            }
            else if (role == "receptionist")
            {
                if (e.ColumnIndex == 8)
                {
                    updateCustomer(c);
                }
                else if (e.ColumnIndex == 9)
                {
                    deleteCustomer(id);
                }
            }
        }

        private void updateCustomer(Customer c)
        {
            updateCustomer updateCustomer = new updateCustomer(c, ownerActive);
            updateCustomer.CustomerUpdated += UpdateCustomerEventHandler;
            updateCustomer.ShowDialog();
        }

        private void deleteCustomer(int id)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (CustomerDL.deleteCustomerFromDB(id, ownerActive))
                {
                    MessageBox.Show("Customer Deleted Successfully");
                    CustomerDL.loadCustomerDataFromDB();
                    AppointmentDL.cancelAppointmentByCustomerId(id, ownerActive);
                }
                else
                {
                    MessageBox.Show("Customer Deletion Failed");
                }
            }
        }

        private void UpdateCustomerEventHandler(object sender, EventArgs e)
        {
            bindTableView();
        }

        private void enter_btn_Click(object sender, EventArgs e)
        {
            string f = filter.SelectedItem?.ToString(); // Get the selected filter
            string searchText = searchTxt.Text.Trim(); // Get the search text

            if (!string.IsNullOrEmpty(f) && !string.IsNullOrEmpty(searchText))
            {
                refresh(CustomerDL.GetListBySearch(f, searchText));

            }
            else
            {
                utils.ShowMessage("Please select a filter and enter search text.", "Incomplete Input");
            }
        }
    }
}
