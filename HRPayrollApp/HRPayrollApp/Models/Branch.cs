using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
