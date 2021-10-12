using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProCar.Infrastructure.Services.Dashboard;
using ProCar.Infrastructure.Services.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProCar.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDashboardService _dashboardService;

        public HomeController(IDashboardService dashboardService,IUserService UserService) : base(UserService)
        {
            _dashboardService = dashboardService;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _dashboardService.GetData();
            return View(data);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetContentByMonthChartData()
        {
            var data = await _dashboardService.GetContentByMonthChart();
            return Ok(data);
        }
    }
}
