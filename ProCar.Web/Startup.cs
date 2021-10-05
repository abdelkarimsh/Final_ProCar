using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProCar.Data;
using ProCar.Data.Models;
using ProCar.Infrastructure.AutoMapper;
using ProCar.Infrastructure.Services;
using ProCar.Infrastructure.Services.car;
using ProCar.Infrastructure.Services.Lease;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCar.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProCarDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false
              )
                  .AddEntityFrameworkStores<ProCarDbContext>()
                  .AddDefaultTokenProviders().
                  AddDefaultUI();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddTransient<IEmployeeService, EmployeeService>();

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IFileService, FileService>();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICarService, CarService>();
            // services.AddTransient<ILeaseService, LeaseService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
