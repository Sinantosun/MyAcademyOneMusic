using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OneMusic.WebUI.Areas.Artist.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Artist")]
        [Authorize(Roles = "Artist")]
        [Route("[area]/[controller]/[action]/{id?}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
