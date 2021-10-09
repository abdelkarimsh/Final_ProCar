using Microsoft.AspNetCore.Identity;
using ProCar.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Data.Models
{
    public class User : IdentityUser
    {

        public string FullName { get; set; }

        public string ImageUrl { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
        public string City { get; set; }
        public int DrivingLicenseNumber { get; set; }
        public List<Leases> lease { get; set; }
        public string LegaldocumentImegUrl { get; set; }



        public User()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
