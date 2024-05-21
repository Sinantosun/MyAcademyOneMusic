using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.Areas.Artist.Models;
using OneMusic.WebUI.ImageSettings;

namespace OneMusic.WebUI.Areas.Artist.Controllers
{
    [Area("Artist")]
    [Authorize(Roles = "Artist")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        async Task<EditArtistViewModel> loadUserModel()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new EditArtistViewModel()
            {
                ArtistId = user.Id,
                IsEmailConfirmed = user.EmailConfirmed,
                IsPhoneConfirmed = user.PhoneNumberConfirmed,
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Surname = user.Surname,
                UserName = user.UserName,
                ImageURL = user.ImageURL,

            };
            return model;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await loadUserModel());
        }
        [HttpPost]
        public async Task<IActionResult> Index(EditArtistViewModel model)
        {
            ModelState.Clear();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (model.ImageFile != null)
            {
                var imageName = ImageSetting.CreateImage(model.ImageFile, "Artists");
                user.ImageURL = imageName;
            }
            string oldUserName = user.UserName;
            user.Surname = model.Surname;
            user.PhoneNumber = model.PhoneNumber;
            user.Name = model.Name;
            user.Email = model.Email;
            user.UserName = model.UserName;

            var result = await _userManager.CheckPasswordAsync(user, model.OldPassword);

            if (result)
            {
                if (model.Password != null)
                {
                    if (model.Password == model.PasswordConfirm)
                    {
                        var PasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);
                        if (!PasswordResult.Succeeded)
                        {
                            foreach (var item in PasswordResult.Errors)
                            {
                                ViewBag.ResultPassword += item.Description + "<br/>";
                            }
                            return View(await loadUserModel());
                        }
                    }
                    else
                    {
                        TempData["Result"] = "Şifreler uyuşmuyor";
                        TempData["icon"] = "info";
                        ModelState.AddModelError("Password", "Şifreler eşleşmiyor.");
                        return View(await loadUserModel());
                    }


                }
                var updateResult = await _userManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {
                    TempData["Result"] = "Profil bilgileriniz güncellendi";
                    TempData["icon"] = "success";
                    if (oldUserName != user.UserName)
                    {
                        return RedirectToAction("Index","Login");
                    }


                }
            }
            else
            {
                TempData["Result"] = "Mevcut Şifreniz Hatalı";
                TempData["icon"] = "info";
                ModelState.AddModelError("OldPassword", "Mevcut şifreniz hatalı");
            }
            return View(await loadUserModel());


        }
    }
}
