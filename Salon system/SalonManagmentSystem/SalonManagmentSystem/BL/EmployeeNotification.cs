using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagmentSystem.BL
{
    public class EmployeeNotification 
    {
        public EmployeeNotification(int nId, int eId, int s) 
        { 
            this.employeeId = eId;
            this.status = s;
            this.notificationId = nId;

        }
        public int notificationId { get; set; }
        public int employeeId { get; set; }
        public int status  { get; set; }
    }
}
