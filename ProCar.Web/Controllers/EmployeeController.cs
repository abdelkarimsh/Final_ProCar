using Microsoft.AspNetCore.Mvc;
using ProCar.Core.Conestants;
using ProCar.Core.Dtos;
using ProCar.Infrastructure.Services;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCar.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _EmployeeService;
        public EmployeeController(IEmployeeService _EmployeeService)
        {
            this._EmployeeService = _EmployeeService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetEmployeesData(Pagination pagination, Query query)
        {
            var result = await _EmployeeService.GetAll(pagination, query);
            return Json(result);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create([FromForm] CreateEmployeeDto dto)
        {
            if (ModelState.IsValid)
            {
                await _EmployeeService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _EmployeeService.Get(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateEmployeeDto dto)
        {
            if (ModelState.IsValid)
            {
                await _EmployeeService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _EmployeeService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }


    }
}
