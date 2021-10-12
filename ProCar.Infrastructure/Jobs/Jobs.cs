using Hangfire;
using Microsoft.EntityFrameworkCore;
using ProCar.Core.Enums;
using ProCar.Data;
using ProCar.Infrastructure.Services;
using ProCar.Infrastructure.Services.Lease;
using ProCars.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Jobs
{
    public class Jobs: IJobs
    {
        private readonly ProCarDbContext _db;
        private readonly IEmailService _emailService;
        

        public Jobs(ProCarDbContext db, ILeaseService iLeaseService, IEmailService IEmailService)
        {
            _db = db;
            _emailService = IEmailService;
        }
       
        // مش متأكد منها 
     
        public async Task LeasesStatusJob()
        {
            var leasesList =await  _db.leases.Include(x=>x.User).Include(x=>x.Car).Where(x => x.EndRent == DateTime.Now.AddDays(1)||x.EndRent== DateTime.Now).ToListAsync();
            foreach(var leases in leasesList)
            {
                if(leases.EndRent.Date == DateTime.Now.Date.AddDays(1))
                {
                    await _emailService.Send(leases.User.Email, "The lease will expire !", $"Username is : {leases.User.Email} The rental contract will expire tomorrow " +
                   $"if you want to extend the rent or you have to hand the car over " +
                   $"to the nearest branch of our company");
                }
                if(leases.EndRent.Date == DateTime.Now.Date)
                {
                    leases.leasestatus = leaseStatus.Finished;
                    leases.Car.CarStatus = CarStatus.InService;
                    await _emailService.Send(leases.User.Email, "The lease expired !", "Thank you, you have to deliver the car to the nearest branch of our company");
                }
               
            }
            
        }

    }
}
