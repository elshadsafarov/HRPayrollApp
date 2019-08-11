using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models
{
    public class Employees
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20,MinimumLength =3,ErrorMessage = "Minimum 3, Maximum 20 characters")]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public DateTime Birthday { get; set;}
        [Required]
        public string CurrentAddress { get; set; }
        [Required]
        public string RegisterDistrict { get; set; }
        [Required]
        public string PassportNum { get; set; }
        [Required]
        public DateTime PassExpireDate { get; set; }
        [Required]
        public Education Education { get; set; }
        [Required]
        public FamilyStatus FamilyStatus { get; set; }
        [Required]
        public Gender Gender { get; set; }

    }
    //work
   // ICOLLECTION<Employees> employees

}
