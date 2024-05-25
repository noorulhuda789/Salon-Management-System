using SalonManagmentSystem.BL;
using SalonManagmentSystem.DL;
using SalonManagmentSystem.UI.EmployeeUi;
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
    public partial class serviceDetails_uc : UserControl
    {
        public serviceDetails_uc()
        {
            InitializeComponent();
            RefreshGridView();
        }

        private void enter_btn_Click(object sender, EventArgs e)
        {
            string filter = filter_cb.SelectedItem?.ToString(); // Get the selected filter
            string searchText = name_tb.Text.Trim(); // Get the search text

            if (!string.IsNullOrEmpty(filter) && !string.IsNullOrEmpty(searchText))
            {
                string query = "";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                // For other columns, use LIKE operator
                query = $"SELECT id, name, description, timeDuration, serviceCharges, L2.value as serviceType, createdOn, updatedOn, L1.value AS isDeleted  " +
                        $"FROM   dbo.Service AS S  " +
                        $"INNER JOIN dbo.Lookup AS L2 ON s.serviceTypeId = L2.lookupId " +
                        $"INNER JOIN  dbo.Lookup AS L1 ON S.isDeleted = L1.lookupId " +
                        $"WHERE  L2.category = 'servicetype'  AND L1.category = 'isdeleted' " +
                        $"AND {filter} LIKE @searchText " +
                        $"and isDeleted = (SELECT lookupId from Lookup where category = 'isdeleted' and value = 'no')";
                parameters.Add("@searchText", "%" + searchText + "%");

                DataTable result = DataHandler.ExecuteQuery(query, parameters);

                //Display result it in a DataGridView
                emp_gv.DataSource = result;
                if (emp_gv.Columns.Contains("id"))
                    emp_gv.Columns["id"].Visible = false;
                if (emp_gv.Columns.Contains("isDeleted"))
                    emp_gv.Columns["isDeleted"].Visible = false;
            }
            else
            {
                utils.ShowMessage("Please select a filter and enter search text.", "Incomplete Input");
            }
        }
        private void name_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name_tb.Text))
            {
                RefreshGridView();
            }
        }
        public void RefreshGridView()
        {
            // Call the view to get all data of employees
            string query = "SELECT id, name, description, timeDuration, serviceCharges, L2.value as serviceType, createdOn, updatedOn,L1.value AS isDeleted  FROM   dbo.Service AS S  INNER JOIN dbo.Lookup AS L2 ON s.serviceTypeId = L2.lookupId INNER JOIN  dbo.Lookup AS L1 ON S.isDeleted = L1.lookupId WHERE  L2.category = 'servicetype'  AND L1.category = 'isdeleted' AND isDeleted = (Select lookupId from Lookup where category = 'isdeleted' AND value = 'no')";
            DataTable result = DataHandler.ExecuteQuery(query);

            // Bind the result to DataGridView
            emp_gv.DataSource = result;
            if (emp_gv.Columns.Contains("id"))
                emp_gv.Columns["id"].Visible = false;
            if (emp_gv.Columns.Contains("isDeleted"))
                emp_gv.Columns["isDeleted"].Visible = false;
            foreach (DataGridViewColumn column in emp_gv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void emp_gv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == emp_gv.Columns["Update"].Index)
                {
                    // Handle update button click
                    DataGridViewRow selectedRow = emp_gv.Rows[e.RowIndex];
                    // Extract data from the selected row and pass it to the update form
                    int serviceId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    // Call method to open update form with employee data
                    updateServiceDetails updateForm = new updateServiceDetails(serviceId);
                    updateForm.ShowDialog();
                    RefreshGridView();
                }
                if (e.ColumnIndex == emp_gv.Columns["Delete"].Index)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this service?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DataGridViewRow selectedRow = emp_gv.Rows[e.RowIndex];
                        int serviceId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                        List<int> appIds = ServiceDL.GetServiceAppointments(serviceId);

                        if (appIds.Count > 0)
                        {
                            MessageBox.Show($"This service cannot be removed! It has been scheduled in appointments with Ids:  {string.Join(", ", appIds)}");
                             return;
                        }
                        if(ServiceDL.DeleteService(serviceId))
                            MessageBox.Show("Service deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshGridView();
                    }
                }
            }
        }
    }
}
