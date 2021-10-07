using ProCar.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Data.Models
{
    //عقد الايجار 
     public class Lease 
    {
        public int Id { get; set; }

        public DateTime StartRent { get; set; }

        public DateTime EndRent { get; set; }

        public leaseStatus leasestatus { get; set; }

        public double TotalPrice { get; set; }

        public ApprovalStatus Approval { get; set; }

        public string  UserId { get; set; }

        public User User { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public bool IsDelete { get; set; }

        public string LegaldocumentImegUrl { get; set; }




    }
}
