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
        [Required]
        public DateTime StartRent { get; set; }
        [Required]
        public DateTime EndRent { get; set; }
       
        [Required]
        public leaseStatus leasestatus { get; set; }
        public double TotalPrice { get; set; }
        public ApprovalStatus Approval { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public bool IsDelete { get; set; }



        //public Lease()
        //{
        //    var diffResult = (EndRent.Date - StartRent.Date).Days;
        //    this.TotalPrice = this.Car.PriceOnDay * diffResult;

        //    leasestatus = leaseStatus.Active;
        //    Approval = ApprovalStatus.Pending;

        //}
    }
}
