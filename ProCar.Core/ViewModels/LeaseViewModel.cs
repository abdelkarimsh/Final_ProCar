using ProCar.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Core.ViewModels
{
    public class LeaseViewModel
    {





        public int Id { get; set; }

        public string StartRent { get; set; }

        public string EndRent { get; set; }

        public string leasestatus { get; set; }

        public double TotalPrice { get; set; }

        public string Approval { get; set; }

        public UserViewModel User { get; set; }

        public CarViewModel Car { get; set; }

        public string LegaldocumentImegUrl { get; set; }

    }
}
