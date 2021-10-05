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
        [Required]
        public string FullName { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        //public string UserId { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
      


        public User()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
