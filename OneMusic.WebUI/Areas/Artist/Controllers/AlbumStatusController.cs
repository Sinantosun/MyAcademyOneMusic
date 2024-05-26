using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.Areas.Artist.Controllers
{
    [Area("Artist")]
    [Authorize(Roles = "Artist")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AlbumStatusController : Controller
    {
        private readonly IAlbumService albumService;

        public AlbumStatusController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        public IActionResult Index()
        {
            var list = albumService.TgetListAwatingApprovalAlbums();
            return View(list);
        }
    }
}
