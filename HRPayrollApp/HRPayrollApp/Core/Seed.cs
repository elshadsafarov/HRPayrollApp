using HRPayrollApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Core
{
    public static class Seed
    {

        public static async Task InvokeAsync(IServiceScope scope, PayrollDbContext context)
        {
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            if (!context.Roles.Any())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();            

                var AdminRoleCreate = await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });

                var HRRoleCreate = await roleManager.CreateAsync(new IdentityRole { Name = "HR" });
            }

            if (!context.Users.Any())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                User admin = new User()
                {
                    Email = "elshad@gmail.com",
                    Name = "Elshad",
                    Surname = "Safarov",
                    UserName = "ElshadSafarov"
                };

                User HR = new User()
                {
                    Email = "nurlan@gmail.com",
                    Name = "Nurlan",
                    Surname = "Badirli",
                    UserName = "NurlanBadirli"
                };

                User user = new User()
                {
                    Name = "Ali",
                    Surname = "Aliyev",
                    Email = "ali@gmail.com",
                    UserName = "Ali123"
                };

                var adminResult = await userManager.CreateAsync(admin, configuration["Admin:Password"]);
                var HRResult = await userManager.CreateAsync(HR, configuration["HR:Password"]);

                var userResult = await userManager.CreateAsync(user, "Ali@123");

                if (adminResult.Succeeded)
                {
                    var AdminRoleAdd = await userManager.AddToRoleAsync(admin, "Admin");
                }


                if (HRResult.Succeeded)
                {
                    var HRRoleAdd = await userManager.AddToRoleAsync(HR, "HR");
                }
            }
        }
    }
}
