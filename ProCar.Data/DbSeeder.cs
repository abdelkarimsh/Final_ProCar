using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProCar.Core.Enums;
using ProCar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Data
{
    public static    class DbSeeder
    {
        public static IHost SeedDb( this IHost webHost)
        {
            using var scope = webHost.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<ProCarDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                 context.SeedCar().Wait();
                 userManager.SeedUser().Wait();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return webHost;
        }
        public static async Task SeedCar(this ProCarDbContext _db)
        {
            if (await _db.Cars.AnyAsync())
            {
                return;
            }
            var car = new Car();
            car.ChassiNumber = "123456";
            car.ColorId = ColorId.Silver;
            car.MakerName = MakerName.Toyota;
            car.ImegUrl = "~/Images/235db6d2e3ac4fcc955f6bb81d23a841.jpg";

            await _db.Cars.AddAsync(car);
            await _db.SaveChangesAsync();

        }
        public static async Task SeedUser(this UserManager<User> userManger)
        {
            if (await userManger.Users.AnyAsync())
            {
                return;
            }
            var user = new User();
            user.FullName = " Developer";
            user.UserName = "abdelkarimshar99@gmail.com";
            user.Email = "abdelkarimshar99@gmail.com";
            user.CreatedAt = DateTime.Now;

            await userManger.CreateAsync(user, "Admin1596357##");
        }



    }
}
