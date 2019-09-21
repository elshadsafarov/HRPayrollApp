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
    public class PositionController : Controller
    {
        private readonly PayrollDbContext _dbContext;
        public PositionController(PayrollDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var positions = await _dbContext.Positions.ToListAsync();
            var departments = await _dbContext.Departments.ToListAsync();

            PositionViewModel positionViewModel = new PositionViewModel()
            {
                Departments = departments,
                Positions = positions
            };
            return View(positionViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var positions = await _dbContext.Positions.Include(x => x.Department).ToListAsync();
            var departments = await _dbContext.Departments.ToListAsync();

            PositionViewModel positionViewModel = new PositionViewModel()
            {
                Departments = departments,
                Positions = positions
            };
            return View(positionViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(PositionViewModel positionViewModel)
        {
            if (ModelState.IsValid)
            {
                Position newPosition = new Position()
                {
                    Name = positionViewModel.Name,
                    DepartmentId = positionViewModel.DepartmentId
                };
                _dbContext.Positions.Add(newPosition);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Add", "Position");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(PositionViewModel viewModel, int id)
        {
            var position = await _dbContext.Positions.Include(x => x.Department).Where(p => p.Id == viewModel.Id).FirstOrDefaultAsync();
            var positions = await _dbContext.Positions.Include(x => x.Department).ToListAsync();
            var departments = await _dbContext.Departments.ToListAsync();

            PositionViewModel positionViewModel = new PositionViewModel()
            {
                Departments = departments,
                Positions = positions,
                Name = position.Name,
                Id = position.Id,
                DepartmentId = position.DepartmentId

            };
            return View(positionViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PositionViewModel position)
        {
            if (ModelState.IsValid)
            {
                Position cPosition = new Position();

                if (cPosition != null)
                {
                    cPosition.Name = position.Name;
                    cPosition.DepartmentId = position.DepartmentId;

                }
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Position");

        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (ModelState.IsValid)
            {
                if (id != null)
                {
                    var position = await _dbContext.Positions.Include(x => x.Department).Where(p => p.Id == id).FirstOrDefaultAsync();
                    _dbContext.Positions.Remove(position);
                    await _dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index", "Position");
        }
    }
}