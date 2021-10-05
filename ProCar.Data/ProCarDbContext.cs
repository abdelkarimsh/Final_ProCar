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
        public DbSet<Lease> leases { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
