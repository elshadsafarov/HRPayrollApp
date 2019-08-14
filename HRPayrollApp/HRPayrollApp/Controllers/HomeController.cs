using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPayrollApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPayrollApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PayrollDbContext dbContext;
        public HomeController(PayrollDbContext context)
        {
            dbContext = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employee> employees = dbContext.Employees.ToList();
            return View(employees);
        }
    }
}
