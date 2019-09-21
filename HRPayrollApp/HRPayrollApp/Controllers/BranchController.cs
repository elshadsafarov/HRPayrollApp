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
        [ValidateAntiForgeryToken]
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


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
             var branch = await _dbContext.Branches.Include(x=>x.Company).Where(b => b.Id == id).FirstOrDefaultAsync();

            List<Branch> branches = await _dbContext.Branches.Include(x => x.Company).ToListAsync();
            List<Company> companies = await _dbContext.Companies.ToListAsync();
            BranchViewModel viewModel = new BranchViewModel()
            {
                Branches = branches,
                Companies = companies,
                Name = branch.Name,
                Address = branch.Address,
                IsHead = branch.IsHead,
                CompanyId = branch.CompanyId,
                Id = branch.Id
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BranchViewModel branchViewModel)
        {
            if (ModelState.IsValid)
            {
                var cBranch = await _dbContext.Branches.Include(x => x.Company)
                                                      .Where(b => b.Id == branchViewModel.Id).FirstOrDefaultAsync();
                if (cBranch != null)
                {
                    cBranch.Name = branchViewModel.Name;
                    cBranch.IsHead = branchViewModel.IsHead;
                    cBranch.CompanyId = branchViewModel.CompanyId;
                    cBranch.Address = branchViewModel.Address;
                    await _dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index", "Branch");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var branch = await _dbContext.Branches.Include(x => x.Company).Where(b => b.Id == id)
                                                                                        .FirstOrDefaultAsync();

                _dbContext.Branches.Remove(branch);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Branch");
        }
    }
}