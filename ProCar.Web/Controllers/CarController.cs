using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProCar.Core.Conestants;
using ProCar.Core.Dtos;
using ProCar.Core.ViewModels;
using ProCar.Infrastructure.Services.car;
using ProCar.Infrastructure.Services.Users;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCar.Web.Controllers
{ 
    public class Car : BaseController
    {
        private readonly ICarService ICarService;
        public Car(ICarService _IUserService, IUserService UserService) : base(UserService)
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
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await ICarService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }
        [AllowAnonymous]
        public async Task<IActionResult> GeAllCarsAsViewModel()
        {
            var Cars =await ICarService.GeAllCarsCarsAsViewModel();
            return View(Cars);

        }
        public IActionResult ViewCar()
        {
            return RedirectToAction("GeAllCarsAsViewModel");
        }
    }
}
