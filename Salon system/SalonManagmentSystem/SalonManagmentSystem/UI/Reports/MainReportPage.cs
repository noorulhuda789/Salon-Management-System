using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using SalonManagmentSystem.CrystalReports;
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

namespace SalonManagmentSystem.UI.Reports
{
    public partial class MainReportPage : UserControl
    {
        public MainReportPage()
        {
            InitializeComponent();
            populateYearCombo();
        }

        private void populateYearCombo()
        {
            yearCombo.Items.Add("2024");
            int year = DateTime.Now.Year;
            for(int i = 0; i < yearCombo.Items.Count; i++)
            {
                if (yearCombo.Items[i].ToString() == year.ToString())
                {
                    yearCombo.SelectedIndex = i;
                    break;
                }
                else
                {
                    yearCombo.Items.Add(year);
                }
            }
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            ReportClass report= EmployeeAttendance(dateTimePicker1.Value.Date);
            ReportForm reportForm = new ReportForm(report);
            reportForm.Show();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ReportClass report = CurrentStock();
            ReportForm reportForm = new ReportForm(report);
            reportForm.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ReportClass report = EmployeeSalary(dateTimePicker2.Value.Date);
            ReportForm reportForm = new ReportForm(report);
            reportForm.Show();
        }

        private void showProfitLoss_Click(object sender, EventArgs e)
        {
            ReportClass report = Profit_Loss(yearCombo.SelectedItem.ToString());
            ReportForm reportForm = new ReportForm(report);
            reportForm.Show();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ReportClass report = ExpiredProducts();
            ReportForm reportForm = new ReportForm(report);
            reportForm.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ReportClass report = OutOfStockProd();
            ReportForm reportForm = new ReportForm(report);
            reportForm.Show();
        }

        private ReportClass EmployeeAttendance(DateTime selectedDate)
        {
            var con = Configuration.getInstance().getConnection();
                // Open the connection
            if(con.State != ConnectionState.Open)
                con.Open();

            // Create a SqlCommand object to call the stored procedure
            SqlCommand command = new SqlCommand("GetEmployeeAttendanceReport", con);
         
            // Specify that it's a stored procedure
            command.CommandType = CommandType.StoredProcedure;
         
            // Add parameters to the stored procedure
            command.Parameters.AddWithValue("@SelectedMonth", selectedDate);

            // Create a SqlDataAdapter to fetch the data
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
         
             // Fill the DataTable with the result of the stored procedure
             adapter.Fill(dataTable);
         
             // Create a Crystal Report document
             CrystalReport1 report = new CrystalReport1();
             report.Load("CrystalReport1.rpt"); 
         
             // Set the data source for the report
             report.SetDataSource(dataTable);

         
            return report;
        }
        private ReportClass EmployeeSalary(DateTime selectedDate)
        {
            var con = Configuration.getInstance().getConnection();
            // Open the connection
            if (con.State != ConnectionState.Open)
                con.Open();

            // Create a SqlCommand object to call the stored procedure
            SqlCommand command = new SqlCommand("GetEmployeeSalaryReport", con);

            // Specify that it's a stored procedure
            command.CommandType = CommandType.StoredProcedure;

            // Add parameters to the stored procedure
            command.Parameters.AddWithValue("@SelectedMonth", selectedDate);

            // Create a SqlDataAdapter to fetch the data
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            // Fill the DataTable with the result of the stored procedure
            adapter.Fill(dataTable);

            // Create a Crystal Report document
            CrystalReport3 report = new CrystalReport3();
            report.Load("CrystalReport3.rpt");

            // Set the data source for the report
            report.SetDataSource(dataTable);


            return report;
        }
        private ReportClass CurrentStock()
        {
            var con = Configuration.getInstance().getConnection();
            // Open the connection
            if (con.State != ConnectionState.Open)
                con.Open();

            // Create a SqlCommand object to call the stored procedure
            SqlCommand command = new SqlCommand("GetProductStock", con);
            // Specify that it's a stored procedure
            command.CommandType = CommandType.StoredProcedure;


            // Create a SqlDataAdapter to fetch the data
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            // Fill the DataTable with the result of the stored procedure
            adapter.Fill(dataTable);

            // Create a Crystal Report document
            CrystalReport2 report = new CrystalReport2();
            report.Load("CrystalReport2.rpt");

            // Set the data source for the report
            report.SetDataSource(dataTable);


            return report;
        }


        private ReportClass Profit_Loss(string year)
        {
            var con = Configuration.getInstance().getConnection();
            // Open the connection
            if (con.State != ConnectionState.Open)
                con.Open();

            // Create a SqlCommand object to call the stored procedure
            SqlCommand command = new SqlCommand("stpGetProfitLossReport", con);

            // Specify that it's a stored procedure
            command.CommandType = CommandType.StoredProcedure;

            // Add parameters to the stored procedure
            command.Parameters.AddWithValue("@Year", year);

            // Create a SqlDataAdapter to fetch the data
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            // Fill the DataTable with the result of the stored procedure
            adapter.Fill(dataTable);

            // Create a Crystal Report document
            Profit_Loss report = new Profit_Loss();
            report.Load("Profit_Loss.rpt"); // Provide the path to your Crystal Report file

            // Set the data source for the report
            report.SetDataSource(dataTable);


            return report;
        }
        private ReportClass ExpiredProducts()
        {
            var con = Configuration.getInstance().getConnection();
            // Open the connection
            if (con.State != ConnectionState.Open)
                con.Open();

            // Create a SqlCommand object to call the stored procedure
            SqlCommand command = new SqlCommand("expiryProduct", con);
            // Specify that it's a stored procedure
            command.CommandType = CommandType.StoredProcedure;


            // Create a SqlDataAdapter to fetch the data
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            // Fill the DataTable with the result of the stored procedure
            adapter.Fill(dataTable);

            // Create a Crystal Report document
            CrystalReport4 report = new CrystalReport4();
            report.Load("CrystalReport4.rpt");

            // Set the data source for the report
            report.SetDataSource(dataTable);


            return report;
        }
        private ReportClass OutOfStockProd()
        {
            var con = Configuration.getInstance().getConnection();
            // Open the connection
            if (con.State != ConnectionState.Open)
                con.Open();

            // Create a SqlCommand object to call the stored procedure
            SqlCommand command = new SqlCommand("outOfStock", con);
            // Specify that it's a stored procedure
            command.CommandType = CommandType.StoredProcedure;


            // Create a SqlDataAdapter to fetch the data
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            // Fill the DataTable with the result of the stored procedure
            adapter.Fill(dataTable);

            // Create a Crystal Report document
            CrystalReport5 report = new CrystalReport5();
            report.Load("CrystalReport5.rpt");

            // Set the data source for the report
            report.SetDataSource(dataTable);


            return report;
        }
    }
}
