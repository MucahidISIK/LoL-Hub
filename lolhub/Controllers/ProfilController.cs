using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using lolhub.Models;
using lolhub.Data;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace lolhub.Controllers
{
    public class ProfilController : Controller
    {
        private Context context = new Context();
        private UserManager<ApplicationUser> userManager;
        private YaptigimPaylasimlarListViewModel listModelim = new YaptigimPaylasimlarListViewModel();

        public ProfilController(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }

        [HttpGet]
        public IActionResult Profil(Profil model)
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            model.KullaniciAd = user.UserName;
            model.Email = user.Email;
            return View(model);
        }

        [HttpGet]
        public IActionResult YaptigimPaylasimlar(Profil model)
        {
            
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            
            var paylasimlar = context.Paylasimlar.ToList();
            List<Paylasim> benimPaylasimlarim = new List<Paylasim>();
            foreach (var item in  paylasimlar)
            {
                if(item.KullaniciAd==user.UserName)
                {
                    benimPaylasimlarim.Add(item);
                }
            }
            listModelim.benimPaylasimlarim = benimPaylasimlarim;
            return View(listModelim);
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
