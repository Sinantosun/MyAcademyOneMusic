using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.DataAccessLayer.Context;
using OneMusic.EntityLayer.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;
using X.PagedList;

namespace OneMusic.WebUI.Areas.Default.Controllers
{
    [Area("Default")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _usermanager;
        private readonly OneMusicContext _oneMusicContext;
        public AlbumController(IAlbumService albumService, ICategoryService categoryService, UserManager<AppUser> usermanager, OneMusicContext oneMusicContext)
        {
            _albumService = albumService;
            _categoryService = categoryService;
            _usermanager = usermanager;
            _oneMusicContext = oneMusicContext;
        }

        async Task loadDropdopwn()
        {
            var categoryList = _categoryService.TGetList();
            var artistList = await _usermanager.GetUsersInRoleAsync("Artist");


            List<SelectListItem> Artists = (from x in artistList
                                            select new SelectListItem
                                            {
                                                Text = x.Name + " " + x.Surname,
                                                Value = x.Id.ToString(),
                                            }).ToList();
            ViewBag.Artitst = Artists;


            List<SelectListItem> Categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString(),
                                               }).ToList();
            ViewBag.Categorys = Categories;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var values = _albumService.TGetList().ToPagedList(pageNumber, 12);
            await loadDropdopwn();

            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int category, int artist)
        {

            var values = _oneMusicContext.Albums.Include(t => t.AppUser).Include(t => t.Category).Where(x => x.Category.CategoryID == category && x.AppUserId == artist).ToList().ToPagedList(1, 12);
            await loadDropdopwn();
            return View("Index", values);
        }
    }
}
