using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProCar.Core.Conestants;
using ProCar.Core.Dtos;
using ProCar.Core.ViewModels;
using ProCar.Infrastructure.Services.car;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCar.Web.Controllers
{
    public class Car : Controller
    {
        private readonly ICarService ICarService;
        public Car(ICarService _IUserService)
        {
            this.ICarService = _IUserService;
        }

        public async Task<JsonResult> GetCarData(Pagination pagination, Query query)
        {
            var result = await ICarService.GetAllCars(pagination, query);
            return Json(result);
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
           
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCarDto dto)
        {

            if (ModelState.IsValid)
            {
                await ICarService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }

            //ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");
            //ViewData["authores"] = new SelectList(await _userService.GetAuthorList(), "Id", "FullName");
            return View(dto);
        }

        //public async Task<List<CarViewModel>> CarInSer()
        //{
        //    var result =  ICarService.GetInServiceCars();
        //    return View(result);
        //}
    }
}
