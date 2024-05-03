using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.Models.LoginModels;

namespace OneMusic.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "AdminAbout");
            }
            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            return View();
        }
    }
}
