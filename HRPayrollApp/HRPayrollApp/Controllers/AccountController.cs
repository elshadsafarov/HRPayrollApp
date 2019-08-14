using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPayrollApp.Models.ViewModel;
using HRPayrollApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRPayrollApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly PayrollDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(PayrollDbContext dbContext,
                                    UserManager<User> userManager,
                                                SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(model.UsernameEmail);

                if (user == null)
                {
                    ModelState.AddModelError("", "User not exists");
                }

                if (user != null)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.IsPresistent, true);
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Employee");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Email is incorrect!");
                    return RedirectToAction("Index", "Employee");
                }
            }
            return View();
        }


    }
}