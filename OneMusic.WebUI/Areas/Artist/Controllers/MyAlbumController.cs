using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.ImageSettings;
using OneMusic.WebUI.Models.AlbumModels;

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

        async Task<List<SelectListItem>> loadDropdown()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _albumService.TgetAlbumByArtist(user.Id);
            List<SelectListItem> selectListItems = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.AlbumName,
                                                        Value = x.AlbumId.ToString(),
                                                    }).ToList();
            ViewBag.AlbumList = selectListItems;
            return selectListItems;
        }

        [HttpGet]
        public async Task<IActionResult> CreateAlbum()
        {
            await loadDropdown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAlbum(CreateAlbumViewModel album)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (album.Image != null)
            {
                var result = ImageSetting.CreateImage(album.Image, "Albums");
                _albumService.TCreate(new Album
                {
                    AlbumName = album.AlbumName,
                    AppUserId = user.Id,
                    IsVerify = false,
                    VerifyDescription = "Onay Aşamasında",
                    Price = album.Price,
                    CoverImage = result,
                   
                });

                TempData["Result"] = "Tebrikler, albümünüz kaydedildi onay işlemleri bittiğinde aktif hesabınıza bildirim alacaksınız";
                TempData["icon"] = "success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Result"] = "Görsel Seçiniz";
                TempData["icon"] = "info";

            }
            await loadDropdown();
            return View();


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
