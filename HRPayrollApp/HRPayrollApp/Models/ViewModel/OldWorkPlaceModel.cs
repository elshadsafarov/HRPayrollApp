using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models
{
    public class OldWorkPlaceModel
    {
        public string WorkPlaceName { get; set; }
        public DateTime FireDate { get; set; }
        public DateTime HireDate { get; set; }
        public string FireReason { get; set; }
        public Employee Employee { get; set; }
        public int IdEmployee { get; set; }
    }
}
