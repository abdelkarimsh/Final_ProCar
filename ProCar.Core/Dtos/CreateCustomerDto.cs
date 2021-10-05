using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Core.Dtos
{
    public class CreateCustomerDto
    {

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الاسم")]
        public string Name { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "المدينة")]
        public string City { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "رقم رخصة القيادة")]
        public int DrivingLicenseNumber { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "رقم الجوال ")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "البريد الالكتروني")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "صورة الضمان")]
        public IFormFile LegaldocumentImeg { get; set; }

    }
}
