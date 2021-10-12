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
    public class LeaseController : BaseController
    {

        private readonly IUserService _IUserService;
        private readonly ICarService ICarService;
        private readonly ILeaseService ILeaseService;

        public LeaseController(IUserService iUserService, ICarService iCarService, ILeaseService iLeaseService) : base(iUserService)
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
            ViewData["Users"] = new SelectList(await _IUserService.GetUsersList(), "Id", "FullName");
            ViewData["Cars"] = new SelectList(await ICarService.GetCarsList(), "Id", "MakerName");
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
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var lease = await ILeaseService.Get(id);
            ViewData["Users"] = new SelectList(await _IUserService.GetUsersList(), "Id", "FullName");
            ViewData["Cars"] = new SelectList(await ICarService.GetCarsList(), "Id", "MakerName");
            return View(lease);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateLeaseDto dto)
        {
            if (ModelState.IsValid)
            {
                await ILeaseService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }

          
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await  ILeaseService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }








        [HttpGet]
        public IActionResult ViewUserLeases()
        {
            return View();
        }


        public async Task<JsonResult> GetUserLeases(string Id,Pagination pagination)
        {
            var result = await ILeaseService.GetUserLeases(Id , pagination);
            return Json(result);

        }

   

        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            return File(await ILeaseService.ExportToExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report.xlsx");
        }
    }
}
