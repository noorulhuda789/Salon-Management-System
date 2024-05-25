using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagmentSystem.BL
{
    public  class EmployeeSalary
    {
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime TransferredOn { get; set; }
        public decimal Amount { get; set; }
        public decimal Fine { get; set; }
        public decimal AttendancePercentage { get; set; }

        // Constructor
        public EmployeeSalary(int salaryId,int employeeId, DateTime transferredOn, decimal amount, decimal fine, decimal attendancePercentage)
        {
            SalaryId = salaryId;
            EmployeeId = employeeId;
            TransferredOn = transferredOn;
            Amount = amount;
            Fine = fine;
            AttendancePercentage = attendancePercentage;
        }
    }
}
