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
    public class BranchController : Controller
    {
        private readonly PayrollDbContext _dbContext;
        public BranchController(PayrollDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<Branch> branches = await _dbContext.Branches.Include(x => x.Company).ToListAsync();
            List<Company> companies = await _dbContext.Companies.ToListAsync();
            BranchViewModel branchView = new BranchViewModel
            {
                Branches = branches,
                Companies = companies
            };
            return View(branchView);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            List<Branch> branches = await _dbContext.Branches.Include(x => x.Company).ToListAsync();
            List<Company> companies = await _dbContext.Companies.ToListAsync();
            BranchViewModel viewModel = new BranchViewModel
            {
                Branches = branches,
                Companies = companies
            };
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Add(BranchViewModel branchViewModel)
        {
            if (ModelState.IsValid)
            {
                Branch newBranch = new Branch()
                {
                    Name = branchViewModel.Name,
                    IsHead = branchViewModel.IsHead,
                    CompanyId = branchViewModel.CompanyId,
                    Address = branchViewModel.Address
                    
                };
                _dbContext.Branches.Add(newBranch);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Add", "Branch");
            }
            return View();
        }
    }
}