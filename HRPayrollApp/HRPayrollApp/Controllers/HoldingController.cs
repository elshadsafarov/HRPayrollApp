using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPayrollApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRPayrollApp.Controllers
{
    public class HoldingController : Controller
    {
        private readonly PayrollDbContext _dbContext;
        public HoldingController(PayrollDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var holdings = _dbContext.Holdings.ToList();
            return View(holdings);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Holding holding)
        {
            if (ModelState.IsValid)
            {
                if (holding != null)
                {
                    Holding newHolding = new Holding()
                    {
                        Name = holding.Name
                    };
                    _dbContext.Holdings.Add(newHolding);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Add", "Holding");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong");
                }
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var holding = await _dbContext.Holdings.Where(h => h.Id == id).FirstOrDefaultAsync();
            return View(holding);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Holding holding, int? id)
        {
            if (ModelState.IsValid)
            {
                var currentHolding = await _dbContext.Holdings.Where(h => h.Id == id).FirstOrDefaultAsync();
                if (currentHolding != null)
                {
                    currentHolding.Name = holding.Name;
                }
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Holding");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var holding = await _dbContext.Holdings.Where(h => h.Id == id).FirstOrDefaultAsync();
                _dbContext.Holdings.Remove(holding);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Holding");
        }

    }
}