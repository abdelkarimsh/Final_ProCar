using ProCar.Core.Enums;
using ProCars.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Core.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string MakerName { get; set; }
        public string ColorId { get; set; }
        public string ChassiNumber { get; set; }
        public string ImegUrl { get; set; }
        public float PriceOnDay { get; set; }
     

    }
}
