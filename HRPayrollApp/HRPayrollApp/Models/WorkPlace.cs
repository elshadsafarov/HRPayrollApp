using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models
{
    public class WorkPlace
    {
        public int Id { get; set; }

        public Position Position { get; set; }
        public int PositionId { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        public Branch Branch { get; set; }
        public int BranchId { get; set; }

        public DateTime EntryDate { get; set; }
        public DateTime? LeftDate { get; set; }
    }
}
