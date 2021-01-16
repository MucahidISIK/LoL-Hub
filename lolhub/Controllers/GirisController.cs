using lolhub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lolhub.Controllers
{
    public class GirisController : Controller
    {
        private SignInManager<ApplicationUser> signInManager;
        private UserManager<ApplicationUser> userManager;

        public GirisController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            signInManager = _signInManager;
            userManager = _userManager;
        }

        public IActionResult Index(string _url = null)
        {
            return View(new Giris()
            {
                Url = _url
            });

        }
        [HttpPost]
        public IActionResult DilDestegi(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return LocalRedirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Giris model)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.KullaniciAd);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Adı Bulunamadı..!");
                }
                else
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.KullaniciSifre, false, false);
                    if(result.Succeeded)
                    {
                        model.KullaniciID = user.Id;
                        model.Email = user.Email;
                        model.KullaniciAd = user.UserName;
                        model.KullaniciSifre = user.PasswordHash;
                        return Redirect(model.Url ?? "~/");
                    }
                    ModelState.AddModelError("", "Şifre Yanlış.!!");
                }
            }
            return View(model);
        }
    }
}
