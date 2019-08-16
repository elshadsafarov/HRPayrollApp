using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models.ViewModel
{
    public class PaginationModel
    {
        public List<Employee> Employees { get; set; }
        public Pagination Paginations { get; set; }
    }
}
