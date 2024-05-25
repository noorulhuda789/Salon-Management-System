using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalonManagmentSystem.BL;

namespace SalonManagmentSystem.DL
{
    public class LookupDL
    {
        public static List<Lookup> lookups = new List<Lookup>();

        public static void addLookup(Lookup lookup)
        {
            lookups.Add(lookup);
        }


        public static string getValue(int id)
        {
            return (lookups.Find(c => c.Id == id)).value;
        }

        public static int getId(string value)
        {
            return (lookups.Find(c => c.value == value)).Id;
        }

        public static List<Lookup> getLookups()
        {
            return lookups;
        }

        public static void loadLookupFromDB()
        {
            string query = "SELECT * From Lookup";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            if(con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            if (con.State != ConnectionState.Open) 
            {
                con.Open();
            }
            try
            {
                
                while (reader.Read())
                {
                    Lookup lookup = new Lookup();
                    lookup.Id = (int)reader["lookupId"];
                    lookup.value = reader["value"].ToString();
                    lookup.category = reader["category"].ToString();
                    lookups.Add(lookup);
                }
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
            }
        }



    }
}
