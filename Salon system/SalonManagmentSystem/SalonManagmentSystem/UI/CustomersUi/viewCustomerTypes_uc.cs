using SalonManagmentSystem.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalonManagmentSystem.BL;

namespace SalonManagmentSystem.UI.CustomersUi
{
    public partial class viewCustomerTypes_uc : UserControl
    {
        int ownerActive;
        public viewCustomerTypes_uc(int ownerActive)
        {
            InitializeComponent();
            this.ownerActive = ownerActive;
            CustomerDL.loadCustomerDataFromDB();
            LookupDL.loadLookupFromDB();
            EmployeeDL.loadEmployeeDataFromDB();
            CustomerTypeDL.addCustomerTypeDatatoList();
            bindTableView();
        }

        private void bindTableView()
        {
            viewCustomerTypes.Rows.Clear();
            viewCustomerTypes.Columns.Clear();
            List<List<string>> data = CustomerTypeDL.getCustomerTypesToView();
            List<string> headers = new List<string> { "Name", "Discount Percentage", "Minimum Appointments", "Added By", "Joining Date", "Updated By", "Updated On" };
            for (int i = 0; i < headers.Count; i++)
            {
                viewCustomerTypes.Columns.Add(headers[i], headers[i]);
            }
            foreach (List<string> row in data)
            {
                viewCustomerTypes.Rows.Add(row.ToArray());
            }
            addButtons();
            foreach (DataGridViewColumn column in viewCustomerTypes.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void addButtons()
        {
            // Create a DataGridViewButtonColumn
            viewCustomerTypes.AutoGenerateColumns = false;
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.HeaderText = "Update";
            buttonColumn1.Text = "Update";
            buttonColumn1.UseColumnTextForButtonValue = true;
            viewCustomerTypes.Columns.Add(buttonColumn1);

            viewCustomerTypes.AutoGenerateColumns = false;
            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            buttonColumn2.HeaderText = "Delete";
            buttonColumn2.Text = "Delete";
            buttonColumn2.UseColumnTextForButtonValue = true;
            viewCustomerTypes.Columns.Add(buttonColumn2);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewCustomerTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = viewCustomerTypes.SelectedCells[0].RowIndex;
            if(e.ColumnIndex == 7)
            {
                CustomerType customerType = new CustomerType();
                customerType.Name = viewCustomerTypes.Rows[index].Cells[0].Value.ToString();
                customerType.discountPercentage = Convert.ToDecimal(viewCustomerTypes.Rows[index].Cells[1].Value);
                customerType.noOfAppointments = Convert.ToInt32(viewCustomerTypes.Rows[index].Cells[2].Value);
                updateCustomerType updateCustomerType = new updateCustomerType(customerType, ownerActive);
                updateCustomerType.CustomerTypeUpdated += UpdateCustomerTypeEventHandler;
                updateCustomerType.ShowDialog();
            }
            else if(e.ColumnIndex == 8)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this customer type?", "Delete Customer Type", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id= CustomerTypeDL.getCustomerTypeID(viewCustomerTypes.Rows[index].Cells[0].Value.ToString());
                    CustomerTypeDL.deleteCustomerTypeFromDB(id);
                    bindTableView();
                }
            }
        }

        private void UpdateCustomerTypeEventHandler(object sender, EventArgs e)
        {
            bindTableView();
        }
    }
}
