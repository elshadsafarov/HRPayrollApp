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
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(model.UserEmail);

                if (user == null)
                {
                    ModelState.AddModelError("", "User not exists");
                    return RedirectToAction("Login", "Account");

                }

                if (user != null)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password,true,true);
                    if (signInResult.Succeeded)
                    {
                       await _signInManager.SignInAsync(user,true);
                       return RedirectToAction("Index", "Employee");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email or password is incorrect!");
                    }

                }
              
            }
            return View(model);
        }


    }
}