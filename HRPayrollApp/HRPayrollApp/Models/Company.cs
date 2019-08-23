using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Holding Holding { get; set; }
        public int HoldingId { get; set; }

    }
}
