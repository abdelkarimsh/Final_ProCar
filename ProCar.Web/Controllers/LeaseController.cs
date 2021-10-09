using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProCar.Core.Conestants;
using ProCar.Core.Dtos;
using ProCar.Infrastructure.Services.car;
using ProCar.Infrastructure.Services.Lease;
using ProCar.Infrastructure.Services.Users;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCar.Web.Controllers
{
    public class LeaseController : Controller
    {

        private readonly IUserService _IUserService;
        private readonly ICarService ICarService;
        private readonly ILeaseService ILeaseService;

        public LeaseController(IUserService iUserService, ICarService iCarService, ILeaseService iLeaseService)
        {
            _IUserService = iUserService;
            ICarService = iCarService;
            ILeaseService = iLeaseService;
        }

        public async Task<JsonResult> GetLeasesData(Pagination pagination, Query query)
        {
            var result = await ILeaseService.GetAll(pagination, query);
            return Json(result);

        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //ViewData["Users"] = new SelectList(await _IUserService.GetUsersList(), "Id", "FullName");
            //ViewData["Cars"] = new SelectList(await ICarService.GetCarsList(), "Id", "MakerName");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateLeaseDto dto)
        {

            if (ModelState.IsValid)
            {
                await ILeaseService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
            //ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");
        }       
    }
}
