using Microsoft.AspNetCore.Http;
using ProCar.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Core.Dtos
{
    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "اسم المستخدم")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "نوع المستخدم")]
        public UserType UserType { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الراتب")]
        public float Salary { get; set; }
        [Display(Name = "الصورة")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Phone]
        [Display(Name = "رقم الجوال ")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [EmailAddress]
        [Display(Name = "البريد الالكتروني ")]
        public string Email { get; set; }


    }
}
