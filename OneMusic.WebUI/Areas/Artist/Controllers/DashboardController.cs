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
    public class DashboardController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IAlbumService _albumService;
        private readonly ISongService _songService;
        private readonly ISongsListenDetailsService _songsListenDetailsService;

        public DashboardController(IAlbumService albumService, UserManager<AppUser> userManager, ISongService songService, ISongsListenDetailsService songsListenDetailsService)
        {
            _albumService = albumService;
            _userManager = userManager;
            _songService = songService;
            _songsListenDetailsService = songsListenDetailsService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            ViewBag.albumCount = _albumService.TAlbumCount(user.Id);
            ViewBag.WaitingAlbumCount = _albumService.TAlbumCountByWaiting(user.Id);
            ViewBag.ExpensiveAlbumName = _albumService.TExpensiveAlbumName(user.Id);
            ViewBag.SongCount = _songService.TSongCount(user.Id);
            ViewBag.Email = user.Email;
            ViewBag.PhoneNumber = user.PhoneNumber;
            ViewBag.IsTwoFactor = user.TwoFactorEnabled;
            ViewBag.ListenCount = _songsListenDetailsService.TcountByListenedArtist(user.Id);
            ViewBag.ArtistUserName = user.Name + " " + user.Surname;
            ViewBag.ArtistImageUrl = user.ImageURL;



            return View();
        }
    }
}
