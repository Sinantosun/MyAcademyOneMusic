using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.Areas.Default.Controllers
{
    [Area("Default")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class AlbumDetailController : Controller
    {
        private readonly ISongService _songService;
        private readonly IAlbumService _albumService;

        public AlbumDetailController(ISongService songService, IAlbumService albumService)
        {
            _songService = songService;
            _albumService = albumService;
        }

        public IActionResult Index(int id)
        {
            var value = _songService.TgetSongsByAlbumID(id);
            var valu2 = _albumService.TgetAlbumByIDWithAppUser(id);
            ViewBag.CoverPhotoImageURL = valu2.CoverImage;
            ViewBag.UserNameSurname = valu2.AppUser.Name + " "+ valu2.AppUser.Surname;
            ViewBag.AlbumName = valu2.AlbumName;
            return View(value);
        }
    }
}
