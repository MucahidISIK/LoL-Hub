using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lolhub.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace lolhub.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public AdminController(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View(userManager.Users);
        }
        [HttpPost]
        public IActionResult DilDestegi(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return LocalRedirect(returnUrl);
        }
    }
}
