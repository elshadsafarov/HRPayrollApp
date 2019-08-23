using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPayrollApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRPayrollApp
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddDbContext<PayrollDbContext>(x =>
            {
                x.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            });
            services.AddSession();
            services.AddIdentity<User, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<PayrollDbContext>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});


            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(route =>
            {
                route.MapRoute(name: "", template: "{controller=Account}/{action=Login}");
                route.MapRoute(name: "", template: "{area=exists}/{controller=Home}/{action=Index}/{id?}");
                route.MapRoute(name: "", template: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
