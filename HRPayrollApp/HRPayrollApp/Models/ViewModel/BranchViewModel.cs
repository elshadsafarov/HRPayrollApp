using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models.ViewModel
{
    public class BranchViewModel
    {
        public List<Branch> Branches { get; set; }
        public List<Company> Companies { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsHead { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
    }
}
