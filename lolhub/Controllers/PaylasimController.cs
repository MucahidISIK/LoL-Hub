using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lolhub.Data;
using lolhub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace lolhub.Controllers
{
    public class PaylasimController : Controller
    {
        private Context context = new Context();
        private UserManager<ApplicationUser> userManager;

        public PaylasimController(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            var paylasimlar = context.Paylasimlar.ToList();
            
            return View(new PaylamsimListViewModel()
            {
                Paylasims = paylasimlar,
            });
        }

        [HttpPost]
        public IActionResult PaylasimYap(Paylasim model)
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var Paylasim = new Paylasim()
            {
                Baslik = model.Baslik,
                Icerik = model.Icerik,
                VLink = model.VLink,
                GLink = model.GLink,
                KullaniciAd = user.UserName
            };
            context.Paylasimlar.Add(Paylasim);
            context.SaveChanges();
            return RedirectToAction("Index");
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
