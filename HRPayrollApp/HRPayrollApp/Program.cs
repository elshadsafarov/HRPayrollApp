using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HRPayrollApp.Core;
using HRPayrollApp.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HRPayrollApp
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            using (IServiceScope scope = webHost.Services.CreateScope())
            {
                using (PayrollDbContext context = scope.ServiceProvider.GetRequiredService<PayrollDbContext>())
                {
                    Seed.InvokeAsync(scope, context).Wait();
                }
            }
                webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }   }  
