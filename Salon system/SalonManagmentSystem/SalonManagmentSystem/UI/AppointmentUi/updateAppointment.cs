using Guna.UI2.WinForms;
using SalonManagmentSystem.BL;
using SalonManagmentSystem.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace SalonManagmentSystem.UI.AppointmentUi
{
    public partial class updateAppointment : Form
    {
        List<Tuple<string, string>> intervals = new List<Tuple<string, string>>();
        Appointment a = new Appointment();
        int employeeActive = -1;
        List<Tuple<string, string>> serviceEmp = new List<Tuple<string, string>>();
        public updateAppointment(Appointment a, int employeeActive)
        {
            InitializeComponent();
            this.a = a;
            this.employeeActive = employeeActive;
            loadDataGridView();
            loadCustomers();
            loadValues();
            savebtn.Enabled = false;
            datePiicker.ValueChanged += new EventHandler(datePiicker_ValueChanged);
            timePicker.ValueChanged += new EventHandler(timepiicker_ValueChanged);
        }

        private void loadDataGridView()
        {
            serviceEmp = AppointmentDL.getAppointmentServices(a.AppointmentId);
            List<string> headers = new List<string> { "Service Name", "Employee Name" };
            for (int i = 0; i < headers.Count; i++)
            {
                dataGridView1.Columns.Add(headers[i], headers[i]);
            }
            foreach (Tuple<string, string> row in serviceEmp)
            {
                dataGridView1.Rows.Add(new List<string> { row.Item1, row.Item2 }.ToArray());
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


        private void loadValues()
        {
            customerCombobox.SelectedItem = CustomerDL.getCustomerById(a.CustomerId).Name + " - "  + CustomerDL.getCustomerById(a.CustomerId).Phone;
            timePicker.Value = DateTime.ParseExact(a.Time, "hh:mm", null);
            DateTime date = DateTime.Parse(a.Date);
            datePiicker.Value = date;

        }

        private void loadCustomers()
        {
            customerCombobox.Items.Add("Select Customer");
            List<string> customers = AppointmentDL.Customers();
            foreach (string customer in customers)
            {
                customerCombobox.Items.Add(customer);
            }
            customerCombobox.SelectedIndex = 0;
        }

        private bool setTime()
        {
            bool flag = true;
            string date = datePiicker.Value.ToString("yyyy-MM-dd");
            foreach (Tuple<string, string> service in serviceEmp)
            {
                List<Tuple<string, decimal>> Durations = new List<Tuple<string, decimal>>();
                string query = $"SELECT A.startTime, sum(S.timeDuration) timeDuration \r\nFROM Appointment A\r\nJOIN AppointmentDetails AP\r\nON A.id = AP.appointmentId\r\nJOIN Service S\r\nON S.id = AP.serviceId Where A.date ='{date}' and AP.employeeId = (SELECT id From person Where name = '{service.Item1}') \r\nGroup By A.id,A.startTime";
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Durations.Add(new Tuple<string, decimal>(reader["startTime"].ToString(), Convert.ToDecimal(reader["timeDuration"])));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    reader.Close();
                }
                flag = makeintervals(Durations, service.Item2);
                if (!flag) { return false; }
            }
            return flag;
        }


        private bool makeintervals(List<Tuple<string, decimal>> Durations, string name)
        {
            for (int i = 0; i < Durations.Count; i++)
            {
                string timeString = Durations[i].Item1;
                decimal duration = Durations[i].Item2;
                DateTime time = DateTime.ParseExact(timeString, "hh:mm", null);
                decimal minutes = duration * 60;
                time = time.AddMinutes(Convert.ToDouble(minutes));
                intervals.Add(new Tuple<string, string>(timeString, time.ToString("hh:mm")));
            }
            return checkEmployeeIsFree(name);
        }

        private bool checkEmployeeIsFree(string name)
        {
            string time = timePicker.Value.ToString("hh:mm");
            DateTime time1 = DateTime.ParseExact(time, "hh:mm", null);
            bool flag = true;
            string query = $"SELECT timeduration from Service Where name = '{name}'";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            decimal duration = (decimal)cmd.ExecuteScalar();
            for (int i = 0; i < intervals.Count; i++)
            {
                DateTime startTime = DateTime.ParseExact(intervals[i].Item1, "hh:mm", null);
                DateTime addedTime = time1.AddMinutes(Convert.ToDouble(duration * 60));
                DateTime endTime = DateTime.ParseExact(intervals[i].Item2, "hh:mm", null);
                if ((time1 >= startTime && time1 < endTime) || (addedTime > startTime && addedTime < endTime))
                {
                    flag = false;
                    break;
                }
            }
            return flag;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            if (setTime())
            {
                MessageBox.Show("Congratulations!! Emoloyeea are free.");
                savebtn.Enabled = true;
            }
            else
            {
                MessageBox.Show("The employees for your existing services are not free at this time.");
            }
        }

        private void timepiicker_ValueChanged(object sender, EventArgs e)
        {
            savebtn.Enabled = false;
        }
        private void datePiicker_ValueChanged(object sender, EventArgs e)
        {
            savebtn.Enabled = false;
        }


        private void savebtn_Click(object sender, EventArgs e)
        {
            string customer = customerCombobox.SelectedItem.ToString();
            Appointment appointment = new Appointment();
            appointment.AppointmentId = a.AppointmentId;
            appointment.CustomerId = CustomerDL.getCustomerByName(customer.Split('-')[0].Trim(), customer.Split('-')[1].Trim()).Id;
            appointment.Date = datePiicker.Value.ToString("yyyy-MM-dd");
            appointment.Time = timePicker.Value.ToString("hh:mm");
            appointment.updatedBY = employeeActive;
            if (AppointmentDL.updateAppointment(appointment))
            {
                MessageBox.Show("Appointment Updated Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Appointment Not Updated");
            }
            
        }
    }
}
