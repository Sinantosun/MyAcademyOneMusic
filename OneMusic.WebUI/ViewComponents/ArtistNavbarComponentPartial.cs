using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.ViewComponents
{
    public class ArtistNavbarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public ArtistNavbarComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.ArtistUserName = user.Name + " " + user.Surname;
            ViewBag.ArtistImageUrl = user.ImageURL;
            return View();
        }
    }
}
