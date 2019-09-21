using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPayrollApp.Models;
using HRPayrollApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRPayrollApp.Controllers
{
    public class WorkPlaceController : Controller
    {
        private readonly PayrollDbContext _dbContext;
        public WorkPlaceController(PayrollDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index(int empId)
        {
            List<WorkPlace> workPlaces = await _dbContext.WorkPlaces.Where(wp => wp.EmployeeId == empId)
                                                            .Include(wp => wp.Employee)
                                                                 .Include(wp => wp.Branch)
                                                                        .Include(wp => wp.Position)
                                                                                  .ToListAsync();
            return View(workPlaces);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int empId)
        {
            var departments = await _dbContext.Departments.ToListAsync();
            var holdings = await _dbContext.Holdings.ToListAsync();
            var employee = await _dbContext.Employees.Where(wp => wp.Id == empId).FirstOrDefaultAsync();
            var branches = await _dbContext.Branches.ToListAsync();
            WorkPlace workPlace = await  _dbContext.WorkPlaces
                                                .Where(wp => wp.EmployeeId == empId)
                                                    .Include(wp => wp.Position)
                                                        .ThenInclude(p=>p.Department)
                                                            .Include(wp => wp.Branch)
                                                                .ThenInclude(b=>b.Company)
                                                                    .ThenInclude(c=>c.Holding)
                                                                        .FirstOrDefaultAsync();
            WorkPlaceModel model = new WorkPlaceModel
            {
                Departments = departments,
                Employee = employee,
                Holdings = holdings,
                Branches = branches
            };
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> FillCompanies(string id)
        {

            if (id == null)
            {
                return Json(new { status = 400, message = "We couldn't find department" });
            }

            List<Company> companies = await _dbContext.Companies.Where(c => c.HoldingId == Convert.ToInt32(id)).ToListAsync();


            return Json(new { data = companies, status = 200 });


        }


        [HttpPost]
        public async Task<JsonResult> FillBranches(string id)
        {

            if (id == null)
            {
                return Json(new { status = 400, message = "We couldn't find department" });
            }

            List<Branch> branches = await _dbContext.Branches.Where(b => b.CompanyId == Convert.ToInt32(id)).ToListAsync();


            return Json(new { data = branches, status = 200 });

        }

        [HttpPost]
        public async Task<JsonResult> FillPositions(string id)
        {

            if (id == null)
            {
                return Json(new { status = 400, message = "We couldn't find department" });
            }

            List<Position> positions = await _dbContext.Positions.Where(d => d.DepartmentId== Convert.ToInt32(id)).ToListAsync();


            return Json(new { data = positions, status = 200 });

        }
    }
}