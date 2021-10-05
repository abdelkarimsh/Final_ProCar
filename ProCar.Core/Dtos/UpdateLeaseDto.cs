using ProCar.Core.Dtos.Helpers;
using ProCar.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Core.Dtos
{
    public class UpdateLeaseDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذاالحقل مطلوب")]
        [Display(Name = "تاريخ بداية عقد الايجار ")]
        public DateTime StartRent { get; set; }
        [Required(ErrorMessage = "هذاالحقل مطلوب")]
        [Display(Name = "تاريخ نهاية عقد الايجار ")]
        public DateTime EndRent { get; set; }
        //[Required(ErrorMessage = "هذاالحقل مطلوب")]
        //[Display(Name = "الزبون")]
        //public int CustomerId { get; set; }
        [Required(ErrorMessage = "هذاالحقل مطلوب")]
        [Display(Name = "السيارة")]
        public int CarId { get; set; }
        [Required(ErrorMessage = "هذاالحقل مطلوب")]
        [Display(Name = "الموظف")]
        public string EmployeeId { get; set; }

    }
}
