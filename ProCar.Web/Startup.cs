using Hangfire;
using Hangfire.SqlServer;
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
using ProCar.Infrastructure.Jobs;
using ProCar.Infrastructure.Middlewares;
using ProCar.Infrastructure.Services;
using ProCar.Infrastructure.Services.car;
using ProCar.Infrastructure.Services.Dashboard;
using ProCar.Infrastructure.Services.Lease;
using ProCar.Infrastructure.Services.Users;
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


            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 6;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ProCarDbContext>().
                AddDefaultUI()
               .AddDefaultTokenProviders();

            services.AddRazorPages();

            services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            }));

            services.AddHangfireServer();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddAutoMapper(typeof(MapperProfile).Assembly);


            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IFileService, FileService>();

            services.AddTransient<IUserService, UserService>();

            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ILeaseService, LeaseService>();
            services.AddTransient<IDashboardService, DashboardService>();

            services.AddScoped<IJobs, Jobs>();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IJobs jobs)
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

            app.UseHangfireDashboard();
            
            RecurringJob.AddOrUpdate("LeasesStatus", () => jobs.LeasesStatusJob(), Cron.Daily);
            app.UseExceptionHandler(opts => opts.UseMiddleware<ExceptionHandler>());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Car}/{action=GeAllCarsAsViewModel}/{id?}");
                endpoints.MapRazorPages();
            });   
        }

        

    }

}


    

