using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Areas.Artist.Controllers
{
    [Area("Artist")]
    [Authorize(Roles = "Artist")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class MyAlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly UserManager<AppUser> _userManager;

        public MyAlbumController(IAlbumService albumService, UserManager<AppUser> userManager)
        {
            _albumService = albumService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _albumService.TgetAlbumByArtist(user.Id);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAlbum()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAlbum(Album album)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            album.AppUserId = user.Id;
            album.IsVerify = false;
            album.VerifyDescription = "Onay Aşamasında";
            _albumService.TCreate(album);

            TempData["Result"] = "Tebrikler, albümünüz kaydedildi onay işlemleri bittiğinde aktif hesabınıza bildirim alacaksınız";
            TempData["icon"] = "success";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAlbum(int id)
        {
            var values = _albumService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAlbum(Album album)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            album.AppUserId = user.Id;
            _albumService.TUpdate(album);
            TempData["Result"] = "Albümünüz Güncellendi.";
            TempData["icon"] = "success";
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAlbum(int id)
        {
            _albumService.TDelete(id);
            TempData["Result"] = "Albümünüz Silindi.";
            TempData["icon"] = "success";
            return RedirectToAction("Index");
        }
    }
}
