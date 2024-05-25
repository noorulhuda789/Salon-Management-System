using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalonManagmentSystem.DL;
using SalonManagmentSystem.BL;
using System.Windows.Forms;

namespace SalonManagmentSystem.UI.AppointmentUi
{
    public partial class viewAppointments : UserControl
    {
        int ownerActive = -1;
        public viewAppointments(int ownerActive)
        {
            InitializeComponent();
            this.ownerActive = ownerActive;
            loadAppointments();
        }

        public void loadAppointments()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            List<Appointment> appointments = AppointmentDL.getAppointments();
            List<string> headers = new List<string> { "Appointment Id", "Customer Name", "Date", "Time", "Status" };
            for (int i = 0; i < headers.Count; i++)
            {
                dataGridView1.Columns.Add(headers[i], headers[i]);
            }
            foreach (Appointment row in appointments)
            {
                dataGridView1.Rows.Add(new List<string> { row.AppointmentId.ToString(), CustomerDL.getCustomerById(row.CustomerId).Name, row.Date, row.Time, LookupDL.getValue(row.Status) }.ToArray());
            }
            addButtons();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void refresh(List<List<string>> appointments)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            List<string> headers = new List<string> { "Appointment Id", "Customer Name", "Date", "Time", "Status" };
            for (int i = 0; i < headers.Count; i++)
            {
                dataGridView1.Columns.Add(headers[i], headers[i]);
            }
            foreach (List<string> row in appointments)
            {
                dataGridView1.Rows.Add(row.ToArray());
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
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.HeaderText = "Update";
            buttonColumn1.Text = "Update";
            buttonColumn1.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn1);

            dataGridView1.AutoGenerateColumns = false;
            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            buttonColumn2.HeaderText = "Cancel Appointment";
            buttonColumn2.Text = "Concel Appointment";
            buttonColumn2.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn2);

            dataGridView1.AutoGenerateColumns = false;
            DataGridViewButtonColumn buttonColumn3 = new DataGridViewButtonColumn();
            buttonColumn3.HeaderText = "Completed";
            buttonColumn3.Text = "Completed";
            buttonColumn3.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn3);

            dataGridView1.AutoGenerateColumns = false;
            DataGridViewButtonColumn buttonColumn4 = new DataGridViewButtonColumn();
            buttonColumn4.HeaderText = "Generate Invoice";
            buttonColumn4.Text = "Generate Invoice";
            buttonColumn4.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn4);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = dataGridView1.SelectedCells[0].RowIndex;
            int Id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
            Appointment a = new Appointment();
            a.AppointmentId = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
            a.CustomerId = CustomerDL.getCustomer(dataGridView1.Rows[index].Cells[1].Value.ToString()).Id;
            a.Date = dataGridView1.Rows[index].Cells[2].Value.ToString();
            a.Time = dataGridView1.Rows[index].Cells[3].Value.ToString();
            if (e.ColumnIndex == 5)
            {
                updateAppointment updateAppointment = new updateAppointment(a, ownerActive);
                updateAppointment.ShowDialog();

            }
            else if (e.ColumnIndex == 6)
            {
                
                string status = dataGridView1.Rows[index].Cells[4].Value.ToString();
                if (status == "completed")
                {
                    MessageBox.Show("This appointment is completed");
                    return;
                }
                else if (status == "cancelled")
                {
                    MessageBox.Show("This appointment is already cancelled.");
                }
                else if (status == "pending")
                {
                    DialogResult result = MessageBox.Show("Are yyou sure you want to cancel the appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (AppointmentDL.cancelAppointmentByAppId(Id, ownerActive))
                        {
                            MessageBox.Show("Appointment Cancelled Successfully!!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to cancel appointment ☹️.");
                        }
                    }
                }

            }
            else if (e.ColumnIndex == 7)
            {
                string status = dataGridView1.Rows[index].Cells[4].Value.ToString();
                if (status == "completed")
                {
                    MessageBox.Show("This appointment is already completed");
                    return;
                }
                else if (status == "cancelled")
                {
                    MessageBox.Show("This appointment is already cancelled.");
                }
                else if (status == "pending")
                {
                    DateTime t = DateTime.Parse(a.Date.ToString());
                    if (t== DateTime.Now)
                    {
                        AppointmentDL.setAppCompleted(Id, ownerActive);
                        loadAppointments();
                    }
                    else
                    {
                        MessageBox.Show("Appointment cannot be completed before its date.");
                    }
                }
            }
            else if (e.ColumnIndex == 8)
            {
                int id = Id;
                string customerName = dataGridView1.Rows[index].Cells[1].Value.ToString();
                InvoicePrinter invoicePrinter = new InvoicePrinter(Id, customerName, AppointmentDL.getAppointmentServicesWithPrice(Id), CustomerTypeDL.getcustomerTypeDiscountPercentage(CustomerDL.getCustomerType(AppointmentDL.getCustomerID(id))));
                invoicePrinter.SaveInvoiceAsPdf();
                invoicePrinter.PreviewInvoice();

            }
        }

        private void enter_btn_Click(object sender, EventArgs e)
        {
            string search = search_tb.Text;
            string filter = filters.SelectedItem.ToString();
            string date = datePicker.Value.ToString("yyyy-MM-dd");
            List<List<string>> list = AppointmentDL.getAppointmentstoSearch(filter, search, date);
            refresh(list);
        }
    }
}
