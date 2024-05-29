﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.Areas.Default.Controllers
{
    [Area("Default")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class EventController : Controller
    {

        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            var value = _eventService.TGetList();
            return View(value);
        }
    }
}
