using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using lolhub.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace lolhub.Controllers
{
    public class KullaniciController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public KullaniciController(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }

        [HttpGet]  
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KayitOl(SignModel model)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.KullaniciAd;
                user.Email = model.Email;


                var result = await userManager.CreateAsync(user, model.KullaniciSifre);

                if (result.Succeeded)
                {
                    return Redirect("/AnaSayfa/AnaSayfa");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(model);
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
