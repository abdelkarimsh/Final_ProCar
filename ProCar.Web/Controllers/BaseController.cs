using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProCar.Infrastructure.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCar.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly IUserService _UserService;
        protected string userType;
        protected string userId;

        public BaseController(IUserService UserService)
        {
            _UserService = UserService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                var user = _UserService.GetUserByUsername(userName);
                userId = user.Id;
                //userType = user;
                ViewBag.fullName = user.FullName;
                ViewBag.image = user.ImageUrl;
                //ViewBag.UserType = user.UserType.ToString();
            }
        }

    }
}
