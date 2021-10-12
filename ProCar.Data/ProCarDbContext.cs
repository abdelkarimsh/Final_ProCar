using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProCar.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProCar.Data
{
    public class ProCarDbContext : IdentityDbContext<User>
    {
        public ProCarDbContext(DbContextOptions<ProCarDbContext> options)
            : base(options)
        {
        }
        public DbSet<Leases> leases { get; set; }
        public DbSet<Car> Cars { get; set; }

        
    }
}
