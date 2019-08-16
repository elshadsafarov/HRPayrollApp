using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models.ViewModel
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
