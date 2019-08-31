using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public Branch Branch { get; set; }
        public DateTime Date { get; set; }
        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
        public int Bonus { get; set; }
    }
}
