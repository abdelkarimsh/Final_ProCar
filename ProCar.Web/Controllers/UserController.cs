using Microsoft.AspNetCore.Mvc;
using ProCar.Core.Conestants;
using ProCar.Core.Dtos;
using ProCar.Infrastructure.Services;
using ProCar.Infrastructure.Services.Users;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCar.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _IUserService;
        public UserController(IUserService _IUserService) : base(_IUserService)
        {
            this._IUserService = _IUserService;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserDto dto)
        {
            if (ModelState.IsValid)
            {
                await _IUserService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetUserData(Pagination pagination, Query query)
        {
            var result = await _IUserService.GetAll(pagination, query);
            return Json(result);

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user = await _IUserService.Get(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateUserDto dto)
        {
            if (ModelState.IsValid)
            {
                await _IUserService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await _IUserService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }




    }
}
