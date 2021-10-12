using Microsoft.AspNetCore.Http;
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
        [DataType(DataType.Date)]
        public DateTime StartRent { get; set; }

        [Required(ErrorMessage = "هذاالحقل مطلوب")]
        [Display(Name = "تاريخ نهاية عقد الايجار ")]
        [DataType(DataType.Date)]
        public DateTime EndRent { get; set; }

        [Required(ErrorMessage = "هذاالحقل مطلوب")]
        [Display(Name = "السيارة")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "هذاالحقل مطلوب")]
        [Display(Name = "الزبون")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "صورة الضمان")]
        public IFormFile LegaldocumentImeg { get; set; }




    }
}
