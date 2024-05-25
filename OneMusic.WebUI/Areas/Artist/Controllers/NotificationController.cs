using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.Areas.Artist.Controllers
{
    [Area("Artist")]
    [Authorize(Roles = "Artist")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class NotificationController : Controller
    {
        private readonly IUserNotificationsService _userNotificationsService;

        public NotificationController(IUserNotificationsService userNotificationsService)
        {
            _userNotificationsService = userNotificationsService;
        }

        public IActionResult Index()
        {
            var values = _userNotificationsService.TGetList();
            return View(values);
        }
    }
}
