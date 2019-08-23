using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HRPayrollApp.Models;
using HRPayrollApp.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRPayrollApp.Controllers
{
    public class EmployeeController : Controller
    {
        private const int _ItemsPerPage = 2;
        private readonly PayrollDbContext dbContext;
        public readonly IHostingEnvironment hostingEnvironment;
        private readonly SignInManager<User> _signInManager;
        public EmployeeController(PayrollDbContext context,
                                        IHostingEnvironment hosting,
                                                SignInManager<User> signInManager)
        {
            dbContext = context;
            hostingEnvironment = hosting;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.UserName = _signInManager.Context.User.Identity.Name;
            var pagination = new Pagination
            {
                CurrentPage = page,
                ItemsPerPage = _ItemsPerPage,
                TotalItems = dbContext.Employees.Count()
            };

            List<Employee> employees = await dbContext.Employees.Skip((pagination.CurrentPage - 1) * pagination
                                                                        .ItemsPerPage).Take(pagination.ItemsPerPage)
                                                                                          .ToListAsync();

            EmployeeModel employeeModel = new EmployeeModel()
            {
                Employees = employees,
                Paginations = pagination
            };
            return View(employeeModel);
        }
        [HttpPost]
        public async Task<JsonResult> Filter(string value)
        {
            if (value == null)
            {
                List<Employee> employees = await dbContext.Employees.ToListAsync();
                return Json(new { data = employees });
            }
            else
            {
                List<Employee> employees = await dbContext.Employees.
                                                       Where(x => x.Name.Contains(value) || x.Name.StartsWith(value))
                                                            .ToListAsync();
                return Json(new { data = employees, count = dbContext.Employees.Count() });
            }   
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.UserName = _signInManager.Context.User.Identity.Name;
            Employee employee = dbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee, int id, IFormFile Photo)
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
                    if (Photo != null && Photo.FileName != cEmployee.Photo)
                    {
                        string pathh = Path.Combine(hostingEnvironment.WebRootPath, "images", Photo.FileName);
                        using (FileStream stream = new FileStream(pathh, FileMode.Create))
                        {
                            await Photo.CopyToAsync(stream);
                        }
                        cEmployee.Photo = Photo.FileName;

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
                return RedirectToAction("Index", "Employee");
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
            return RedirectToAction("Index", "Employee");
        }


        [HttpGet]
        public  async Task<IActionResult> Details(int id)
        {
          var workPlace =  await dbContext.OldWorkPlace.Where(owp => owp.EmployeeId == id)
                                                        .Include(x=>x.Employee)
                                                                .FirstOrDefaultAsync();
            return View(workPlace);
        }


        [HttpGet]
        public async Task<IActionResult> AddOldWorkPlaces(int id)
        {
            var employees = await dbContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            OldWorkPlaceModel model  = new OldWorkPlaceModel
            {
                Employee = employees
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddOldWorkPlaces(OldWorkPlaceModel oldWorkPlace)
        {
            if (ModelState.IsValid)
            {
                if (oldWorkPlace == null)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return RedirectToAction("AddOldWorkPlaces", "Employee");
                }
                else
                {
                    OldWorkPlace owp = new OldWorkPlace
                    {
                        WorkPlaceName = oldWorkPlace.WorkPlaceName,
                        EmployeeId = oldWorkPlace.IdEmployee,
                        FireDate = oldWorkPlace.FireDate,
                        FireReason = oldWorkPlace.FireReason,
                        HireDate = oldWorkPlace.HireDate
                    };
                    dbContext.OldWorkPlace.Add(owp);
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction("Details", "Employee", new { id = oldWorkPlace.IdEmployee });
                }
            }
            return View();
        
        }
    }
}