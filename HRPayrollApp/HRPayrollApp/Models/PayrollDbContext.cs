using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPayrollApp.Models;

namespace HRPayrollApp.Models
{
    public class PayrollDbContext : IdentityDbContext<User>
    {
        public PayrollDbContext(DbContextOptions<PayrollDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OldWorkPlace> OldWorkPlace { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Company> Companies { get; set; }
        
    }
}
