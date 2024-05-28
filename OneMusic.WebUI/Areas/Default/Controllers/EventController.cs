using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OneMusic.WebUI.Areas.Default.Controllers
{
    [Area("Default")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class EventController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
