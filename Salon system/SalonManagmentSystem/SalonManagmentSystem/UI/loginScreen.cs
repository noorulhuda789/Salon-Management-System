using SalonManagmentSystem;
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

namespace SalonManagmentSystem.UI
{
    public partial class loginScreen : Form
    {
        public loginScreen()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            verifyUser();
           
        }

        private void verifyUser()
        {
            int matchingRecords = 0;
            string w_username = usernameTxt.Text;
            string w_password = passwordTxt.Text;
            int id = -1;
            string password = "";
            int role = -1;
            string query = $"Select e.personid, e.password, p.role From Person p Join Employee e On p.id = e.personid Where e.username = '{w_username}'";

            var con = Configuration.getInstance().getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader["personId"];
                    password = reader["password"].ToString();
                    role = (int)reader["role"];
                    matchingRecords++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


            if (matchingRecords == 0)
            {
                MessageBox.Show("User name does not exist.");
            }
            else if (!String.Equals(password, w_password, StringComparison.Ordinal))
            {
                MessageBox.Show("Incorrect username/password. Try again with correct credentials.");
            }
            else
            {
                switch (role)
                {
                    case 5:
                        this.Hide();
                        Form1 form1 = new Form1(id);
                        form1.Show();
                        break;
                    case 6:
                        this.Hide();
                        ReceptionistUi r = new ReceptionistUi(id);
                        r.Show();
                        break;
                    default:
                        MessageBox.Show("You do not have permission to access this application.");
                        break;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}





