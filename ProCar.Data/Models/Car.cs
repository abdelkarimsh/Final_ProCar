using ProCar.Core.Enums;
using ProCars.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Data.Models
{
    public class Car 
    {
        public int Id { get; set; }
        public MakerName MakerName { get; set; }
        public ColorId ColorId { get; set; }
        [Required]
        public string ChassiNumber { get; set; }
        [Required]
        public string ImegUrl { get; set; }
        public float PriceOnDay { get; set; }
        public List<Lease> lease { get; set; }
        public CarStatus CarStatus { get; set; }
        public bool IsDelete { get; set; }

    }
}
