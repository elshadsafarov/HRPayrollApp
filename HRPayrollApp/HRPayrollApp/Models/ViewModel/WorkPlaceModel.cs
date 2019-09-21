using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models.ViewModel
{
    public class WorkPlaceModel
    {
        public List<Holding> Holdings { get; set; }

        public List<Department> Departments { get; set; }

        public Employee Employee { get; set; }

        public List<Branch> Branches { get; set; }

        public List<Company> Companies { get; set; }

        public BranchPosition BranchPosition { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? LeftDate { get; set; }

    }
}
