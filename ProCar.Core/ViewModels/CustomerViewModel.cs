using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Core.ViewModels
{
    public class CustomerViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int DrivingLicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string LegaldocumentImegUrl { get; set; }

    }
}
