using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagmentSystem.BL
{
    public class CustomerType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal discountPercentage { get; set; }
        public int noOfAppointments { get; set; }
        public int addedBy { get; set; }
        public string createdOn { get; set; }
        public int? updatedBy { get; set; }
        public string updatedOn { get; set; }

    }
}
