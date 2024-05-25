using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagmentSystem.BL
{
    public  class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int? updatedBY { get; set; }
        public string updatedOn{ get; set; }
        public List<Tuple<string, string>> ServiceandEmployee { get; set; }
        public int Status { get; set; }
        public int? isDeleted { get; set; }
    }
}
