using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HRPayrollApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRPayrollApp.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly PayrollDbContext dbContext;
        public readonly IHostingEnvironment hostingEnvironment;
        public EmployeeController(PayrollDbContext context, IHostingEnvironment hosting)
        {
            dbContext = context;
            hostingEnvironment = hosting;
        }

        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await dbContext.Employees.ToListAsync();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = dbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee,int id, IFormFile Photo)
        {
            if (ModelState.IsValid)
            {
                Employee cEmployee = dbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
                if (cEmployee != null)
                {
                    cEmployee.Birthday = employee.Birthday;
                    cEmployee.CurrentAddress = employee.CurrentAddress;
                    cEmployee.Education = employee.Education;
                    cEmployee.FamilyStatus = employee.FamilyStatus;
                    cEmployee.FatherName = employee.FatherName;
                    cEmployee.Gender = employee.Gender;
                    cEmployee.Name = employee.Name;
                    cEmployee.Surname = employee.Surname;
                    cEmployee.PassExpireDate = employee.PassExpireDate;
                    cEmployee.PassportNum = employee.PassportNum;
                    cEmployee.RegisterDistrict = employee.RegisterDistrict;
                    string pathh = Path.Combine(hostingEnvironment.WebRootPath, "images", Photo.FileName);
                    using (FileStream stream = new FileStream(pathh, FileMode.Create))
                    {
                        await Photo.CopyToAsync(stream);
                    }
                }
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Employee");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(Employee employee, IFormFile Photo)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = new Employee();

                newEmployee.Birthday = employee.Birthday;
                newEmployee.Name = employee.Name;
                newEmployee.Surname = employee.Surname;
                newEmployee.FatherName = employee.Surname;
                newEmployee.Birthday = employee.Birthday;
                newEmployee.CurrentAddress = employee.CurrentAddress;
                newEmployee.Education = employee.Education;
                newEmployee.FamilyStatus = employee.FamilyStatus;
                newEmployee.Gender = employee.Gender;
                newEmployee.PassExpireDate = employee.PassExpireDate;
                string pathh = Path.Combine(hostingEnvironment.WebRootPath, "images", Photo.FileName);
                using (FileStream stream = new FileStream(pathh, FileMode.Create))
                {
                    await Photo.CopyToAsync(stream);
                }
                newEmployee.Photo = Photo.FileName;
                newEmployee.RegisterDistrict = employee.RegisterDistrict;
                newEmployee.PassportNum = employee.PassportNum;

                dbContext.Employees.Add(newEmployee);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index","Employee");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Employee employees = await dbContext.Employees.Where(emp => emp.Id == id).FirstOrDefaultAsync();
                dbContext.Employees.Remove(employees);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}