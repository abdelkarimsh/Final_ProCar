using Microsoft.AspNetCore.Http;
using ProCar.Core.Enums;
using ProCars.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Core.Dtos
{
    public class CreateCarDto
    {

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "نوع السيارة")]
        public MakerName MakerName { get; set; }
        public ColorId ColorId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "رقم السيارة")]
        public string ChassiNumber { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الصورة")]
        public IFormFile Imeg { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "سعر الايجار خلال اليوم الواحد")]
        public float PriceOnDay { get; set; }
       
       
    }
}
