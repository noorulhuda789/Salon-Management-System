using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagmentSystem.BL
{
    public class Employee: Person
    {
        public int PersonId { get; set; }
        public int Salary { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string JoiningDate { get; set; }
        public string updatedOn {get; set;}
    }
}
