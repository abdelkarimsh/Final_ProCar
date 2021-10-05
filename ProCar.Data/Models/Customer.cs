using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Data.Models
{
    public class Customer 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int DrivingLicenseNumber { get; set; }
        [Required]
        public List<Lease> lease { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string LegaldocumentImegUrl { get; set; }//صورة ضمان بسعر السيارة

    }
}


        

