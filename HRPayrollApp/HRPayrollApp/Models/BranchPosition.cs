using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models
{
    public class BranchPosition
    {
        public int Id { get; set; }
        public Branch Branch { get; set; }
        public int BranchId { get; set; }

        public Position Position { get; set; }  
        public int PositionId { get; set; }
    }
}
