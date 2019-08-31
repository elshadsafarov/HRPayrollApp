using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models
{
    public class Payroll
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public int Bonus { get; set; }
        public int Penalty { get; set; }
        public int Salary { get; set; }
        public int TotalSalary { get; set; }
    }
}
