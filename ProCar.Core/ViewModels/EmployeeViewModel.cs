using ProCar.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Core.ViewModels
{
     public class EmployeeViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public string ImageUrl { get; set; }
        public string UserType { get; set; }
        public DateTime JoinDate { get; set; }
        public string Gender { get; set; }
        public float Salary { get; set; }

      


    }
}
