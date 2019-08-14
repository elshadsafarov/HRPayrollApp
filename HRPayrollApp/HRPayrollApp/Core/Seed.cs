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
            if (!context.Roles.Any())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var configurtaion = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                User admin = new User()
                {
                    Email = "elshad@gmail.com",
                    Name = "Elsad",
                    Surname = "Safarov",
                    UserName = "Admin"
                };

                User user = new User()
                {
                    Name = "Ali",
                    Surname = "Aliyev",
                    Email = "Ali@gmail.com",
                    UserName = "Ali123"
                };

               var adminResult = await userManager.CreateAsync(admin, configurtaion["Admin:Password"]);
               var userResult =  await userManager.CreateAsync(user, "Ali@123");

                if (adminResult.Succeeded)
                {
                    var roleCreate = await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                    if (roleCreate.Succeeded)
                    {
                    var roleAdd= await userManager.AddToRoleAsync(admin, "Admin");
                    }
                }


            }
        }
    }
}
