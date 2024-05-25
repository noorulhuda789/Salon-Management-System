using Guna.UI2.Designer;
using SalonManagmentSystem.BL;
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
using System.Web;
using System.Windows.Forms;

namespace SalonManagmentSystem.UI.AppointmentUi
{
    public partial class addAppointment : UserControl
    {
        List<Tuple<string, string>> Services = new List<Tuple<string, string>>();
        List<Tuple<string, decimal>> Durations = new List<Tuple<string, decimal>>();
        List<Tuple<string, string>> intervals = new List<Tuple<string, string>>();
        int employeeActive = -1;
        string date;
        string time;

        public addAppointment(int employeeActive)
        {
            InitializeComponent();
            this.employeeActive = employeeActive;
            loadCustomers();
            loadServices();
            serviceCombobox.SelectedIndexChanged += new EventHandler(serviceCombobox_SelectedIndexChanged);

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (Services.Count == 0)
            {
                MessageBox.Show("Please add serviecs.");
                return;
            }
            if (customerCombobox.SelectedIndex == 0)
            {
                MessageBox.Show("Please select customer");
                return;
            }
            else
            {
                string customer = customerCombobox.SelectedItem.ToString();
                string employee = employeeCombobox.SelectedItem.ToString();
                string service = serviceCombobox.SelectedItem.ToString();
                string cName = customer.Split('-')[0].Trim();
                string cPhone = customer.Split('-')[1].Trim();
                Appointment appointment = new Appointment();
                appointment.CustomerId = CustomerDL.getCustomerByName(cName, cPhone).Id;
                appointment.Date = date;
                appointment.Time = time;
                appointment.ServiceandEmployee = Services;
                if (AppointmentDL.addAppointments(appointment, cPhone))
                {
                    MessageBox.Show("Appointment Added Successfully");
                    clear();
                }
                else
                {
                    MessageBox.Show("Failed to add appointment");
                }
                
            }

        }
        private void clear()
        {
            customerCombobox.SelectedIndex = 0;
            serviceCombobox.SelectedIndex = 0;
            employeeCombobox.SelectedIndex = 0;
            dataGridView1.Rows.Clear();

            
        }
        private void adddServiceBtn_Click(object sender, EventArgs e)
        {
            if (serviceCombobox.SelectedIndex == 0)
            {
                MessageBox.Show("Please select service");
                return;
            }
            else
            {
                if (setTime())
                {
                    timePicker.Enabled = false;
                    guna2DateTimePicker1.Enabled = false;
                    if (checkEmployeeIsFree())
                    {
                        if (employeeCombobox.SelectedIndex == 0 || serviceCombobox.SelectedIndex == 0)
                        {
                            MessageBox.Show("Please select employee and service");
                            return;
                        }
                        Tuple<string, string> service = new Tuple<string, string>(serviceCombobox.Text, employeeCombobox.Text);
                        if (CheckService(service.Item1))
                        {
                            MessageBox.Show("Serivce already exists!");
                            return;
                        }
                        Services.Add(service);
                        loadServicesAndEmployees();
                    }
                    else
                    {
                        MessageBox.Show("Employee is not free at this time");
                    }
                }
            }
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
        private void loadServices()
        {
            serviceCombobox.Items.Add("Select Service");
            List<string> strings = ServiceDL.allServices();
            foreach (string str in strings)
            {
                serviceCombobox.Items.Add(str);
            }
            serviceCombobox.SelectedIndex = 0;
        }

        private void loadEmployees(string type)
        {
            employeeCombobox.Items.Clear();
            employeeCombobox.Items.Add("Select Employee");
            List<string> employees = AppointmentDL.Employees(type);
            foreach (string employee in employees)
            {
                employeeCombobox.Items.Add(employee);
            }
            employeeCombobox.SelectedIndex = 0;
        }

        private void loadServicesAndEmployees()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            List<string> headers = new List<string> { "Service Name", "Employee Name" };
            for (int i = 0; i < headers.Count; i++)
            {
                dataGridView1.Columns.Add(headers[i], headers[i]);
            }
            foreach (Tuple<string, string> row in Services)
            {
                dataGridView1.Rows.Add(new List<string> { row.Item1, row.Item2 }.ToArray());
            }
            addButtons();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void addButtons()
        {

            dataGridView1.AutoGenerateColumns = false;
            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            buttonColumn2.HeaderText = "Delete";
            buttonColumn2.Text = "Delete";
            buttonColumn2.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn2);
        }


        private bool setTime()
        {
            // add validation that date and time should be tomorrow or later not today and before today
            DateTime time = DateTime.Now;
            DateTime date = guna2DateTimePicker1.Value;
            if (date < time)
            {
                MessageBox.Show("Please select a valid date");
                return false;
            }
            this.date = date.ToString("yyyy-MM-dd");
            this.time = timePicker.Value.ToString("hh:mm");
            string employee = employeeCombobox.SelectedItem.ToString();
            string query = $"SELECT A.startTime, sum(S.timeDuration) timeDuration \r\nFROM Appointment A\r\nJOIN AppointmentDetails AP\r\nON A.id = AP.appointmentId\r\nJOIN Service S\r\nON S.id = AP.serviceId Where A.date ='{date}' and AP.employeeId = (SELECT id From person Where name = '{employee}') \r\nGroup By A.id,A.startTime";
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
            makeintervals();
            return true;
        }

        private void makeintervals()
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
        }

        private bool checkEmployeeIsFree()
        {
            time = timePicker.Value.ToString("hh:mm");
            DateTime time1 = DateTime.ParseExact(time, "hh:mm", null);
            bool flag = true;
            string name = serviceCombobox.SelectedItem.ToString();
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


        private void serviceCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(serviceCombobox.SelectedIndex == 0)
            {
                return;
            }
            string name = serviceCombobox.SelectedItem.ToString();
            string query1 = $"SELECT (SELECT value FROM Lookup Where lookupid = serviceTypeid) FROM Service Where name = '{name}'";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand(query1, con);
            string type = cmd1.ExecuteScalar().ToString();
            loadEmployees(type);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // add event if delete button is clicked
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            if (e.ColumnIndex == 2)
            {
                //remove the selected one from datagridview and list also
                DeleteService(rowIndex);
            }

        }
        private void DeleteService(int index)
        {
            string serviceName = dataGridView1.Rows[index].Cells[0].Value.ToString();
            // remmove the service from list
            int j = -1;
            for (int i = 0; i < this.Services.Count; i++)
            {
                string name = Services[i].Item1;
                if (name == serviceName)
                {
                    j = i;
                    break;
                }
            }
            if (j != -1)
            {
                Services.Remove(Services[j]);
                loadServicesAndEmployees();
            }

        }
        private bool CheckService(string name)
        {
            foreach(var service in this.Services)
            {
                string s = service.Item1;
                if(s == name)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
