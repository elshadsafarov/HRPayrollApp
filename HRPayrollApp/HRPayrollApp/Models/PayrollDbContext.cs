using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models
{
    public class PayrollDbContext : IdentityDbContext<User>
    {
        public PayrollDbContext(DbContextOptions<PayrollDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
