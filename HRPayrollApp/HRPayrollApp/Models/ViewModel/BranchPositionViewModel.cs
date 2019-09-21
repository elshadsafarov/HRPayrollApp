using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models.ViewModel
{
    public class BranchPositionViewModel
    {
        
        public List<Branch> Branches { get; set; }
        public List<Position> Positions { get; set; }

        public int Id { get; set; }
        public Branch Branch { get; set; }
        public int BranchId { get; set; }

        public Position Position { get; set; }
        public int PositionId { get; set; }
    }
}
