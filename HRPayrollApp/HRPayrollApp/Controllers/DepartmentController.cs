using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPayrollApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRPayrollApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly PayrollDbContext _dbContext;

        public DepartmentController(PayrollDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var departments = _dbContext.Departments.ToList();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Department department)
        {
            if (ModelState.IsValid)
            {
                if (department != null)
                {
                    Department newDepartment = new Department()
                    {
                        Name = department.Name
                    };
                    _dbContext.Departments.Add(newDepartment);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Add", "Department");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong");
                }
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var departments = await _dbContext.Departments.Where(d => d.Id == id).FirstOrDefaultAsync();
            return View(departments);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Department department, int id)
        {
            if (ModelState.IsValid)
            {
                var cDepartments = await _dbContext.Departments.Where(d => d.Id == id).FirstOrDefaultAsync();
                if (cDepartments != null)
                {
                    cDepartments.Name = department.Name;
                }
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Department");
            }
            return View();
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {

                var department = await _dbContext.Departments.Where(d => d.Id == id).FirstOrDefaultAsync();
                _dbContext.Departments.Remove(department);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Department");
        }
    }
}