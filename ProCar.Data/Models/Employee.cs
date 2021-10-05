using ProCar.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Data.Models
{
    public class Employee 
    {
        //اليوسر عو نفسه الموظف 

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public UserType UserType { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public float Salary { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public List<Lease> lease { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }



     
    }
}
