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

namespace SalonManagmentSystem.UI.Receptionist
{
    public partial class ViewEmployees_uc : UserControl
    {
        public ViewEmployees_uc()
        {
            InitializeComponent();
            RefreshGridView();
        }
        public void RefreshGridView()
        {
            
            // Call the view to get all data of employees
            string query = "SELECT P.id, P.name, P.email, P.address, P.city, P.country, P.phone, L1.value AS gender, L2.value AS role  " +
                           "FROM   dbo.Person AS P  INNER JOIN  dbo.Lookup AS L1 " +
                           "ON P.gender = L1.lookupId AND L1.category = 'gender' " +
                           "INNER JOIN    dbo.Lookup AS L2" +
                           " ON P.role = L2.lookupId AND L2.category = 'role' " +
                           "WHERE L2.value <> 'owner' AND L2.value <> 'receptionist' AND L2.value <> 'customer' " +
                           "AND (P.status =  (SELECT lookupId  FROM  dbo.Lookup  WHERE  (category = 'status') AND (value = 'active')))";
            DataTable result = DataHandler.ExecuteQuery(query);

            // Bind the result to DataGridView
            employee_gv.DataSource = result;
            if (employee_gv.Columns.Contains("id"))
                employee_gv.Columns["id"].Visible = false;
            foreach (DataGridViewColumn column in employee_gv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void enter_btn_Click(object sender, EventArgs e)
        {
            string filter = filter_cb.SelectedItem?.ToString(); // Get the selected filter
            string searchText = search_tb.Text.Trim(); // Get the search text

            if (!string.IsNullOrEmpty(filter) && !string.IsNullOrEmpty(searchText))
            {
                string query = "";
                Dictionary<string, object> parameters = new Dictionary<string, object>();


                // For other columns, use LIKE operator
                query = $"SELECT P.id, P.name, P.email, P.address, P.city, P.country, P.phone, L1.value AS gender, L2.value AS role  " +
                         $"FROM  dbo.Person AS P" +
                         $" INNER JOIN  dbo.Lookup AS L1 ON P.gender = L1.lookupId AND L1.category = 'gender'  " +
                         $"INNER JOIN  dbo.Lookup AS L2 ON P.role = L2.lookupId AND L2.category = 'role' " +
                         $"WHERE  L2.value <> 'owner' AND L2.value <> 'receptionist' AND L2.value <> 'customer' " +
                         $"AND (P.status =  (SELECT lookupId FROM dbo.Lookup  WHERE  (category = 'status') AND (value = 'active'))) " +
                         $"AND {filter} LIKE @searchText";

                parameters.Add("@searchText", "%" + searchText + "%");

                DataTable result = DataHandler.ExecuteQuery(query, parameters);

                //Display result it in a DataGridView
                employee_gv.DataSource = result;
                if (employee_gv.Columns.Contains("id"))
                    employee_gv.Columns["id"].Visible = false;
            }
            else
            {
                utils.ShowMessage("Please select a filter and enter search text.", "Incomplete Input");
            }
        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(search_tb.Text))
                RefreshGridView();
        }
    }
}
