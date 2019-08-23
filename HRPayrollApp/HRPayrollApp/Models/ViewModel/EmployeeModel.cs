using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models.ViewModel
{
    public class EmployeeModel
    {
        public List<Employee> Employees { get; set; }
        public OldWorkPlace OldWorkPlace { get; set; }
        public Pagination Paginations { get; set; }
    }
}
