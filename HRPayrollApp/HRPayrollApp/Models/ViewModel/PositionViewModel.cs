using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models.ViewModel
{
    public class PositionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        public Position Position { get; set; }
        public List<Position> Positions { get; set; }
        public List<Department> Departments { get; set; }
    }
}
