using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models
{
    public class OldWorkPlace
    {
        [Required]
        public int Id { get; set; }
        public string WorkPlaceName { get; set; }
        [Required]
        public DateTime FireDate { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public string FireReason { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
