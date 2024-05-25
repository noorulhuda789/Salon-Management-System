using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagmentSystem.BL
{
    public class Customer : Person
    {
        public int customerType { get; set; }
        public int addedBy { get; set; }
        public string createdOn { get; set; }
        public string updatedOn { get; set; }
        public int? updatedBy { get; set; }

    }
}
