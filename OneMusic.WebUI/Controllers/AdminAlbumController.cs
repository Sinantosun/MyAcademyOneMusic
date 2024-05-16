using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.BusinessLayer.Models.Album;
using OneMusic.BusinessLayer.ValidationRules;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.ImageSettings;

namespace OneMusic.WebUI.Controllers
{
    public class AdminAlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly ISingerService _singerService;
        public AdminAlbumController(IAlbumService albumService, ISingerService singerService)
        {
            _albumService = albumService;
            _singerService = singerService;
        }

        public IActionResult Index()
        {
            var values = _albumService.TgetAlbumListWithSinger();
            return View(values);
        }
        public IActionResult DeleteAlbum(int id)
        {
            var value = _albumService.TGetById(id);
            _albumService.TDelete(id);
            TempData["Result"] = "Silme işlemi başarılı";
            TempData["icon"] = "success";
            ImageSetting.DeleteImage(value.CoverImage);
            return RedirectToAction("Index");
        }
        void loadSingerList()
        {
            var _singerList = _singerService.TGetList();
            List<SelectListItem> list = (from x in _singerList
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.SingerId.ToString(),
                                         }).ToList();
            ViewBag.SingerList = list;
        }


        [HttpGet]
        public IActionResult CreateAlbum()
        {
            loadSingerList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateAlbum(CreateAlbumViewModel album)
        {
            ModelState.Clear();
            if (album.Image != null)
            {
                var validator = new AlbumValidator();
                var result = validator.Validate(album);
                if (result.IsValid)
                {
                    string imageName = ImageSetting.CreateImage(album.Image, "Albums");
                    var newAlbum = new Album
                    {
                        AlbumName = album.AlbumName,
                        CoverImage = imageName,
                        Price = album.Price,
                        SingerId = album.SingerId,
                    };
                    _albumService.TCreate(newAlbum);
                    TempData["Result"] = "Ekleme işlemi başarılı";
                    TempData["icon"] = "success";

                    return RedirectToAction("Index");
                }

                result.Errors.ForEach(x =>
                {
                    if (x.PropertyName == "Image.FileName")
                    {
                        ModelState.AddModelError("Image", x.ErrorMessage);
                    }
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });

            }
            else
            {
                ModelState.AddModelError("Image", "Görsel Seçiniz");
            }


            TempData["Result"] = "Hata! kayıt eklenemedi";
            TempData["icon"] = "warning";
            loadSingerList();
            return View();



        }

        [HttpGet]
        public IActionResult UpdateAlbum(int id)
        {
            var values = _albumService.TGetById(id);
            UpdateAlbumViewModel updateAlbumViewModel = new UpdateAlbumViewModel()
            {
                AlbumName=values.AlbumName,
                Price=values.Price,
                SingerId=values.SingerId,
                AlbumId=values.AlbumId,
                
            };
            loadSingerList();
            return View(updateAlbumViewModel);
        }
        [HttpPost]
        public IActionResult UpdateAlbum(UpdateAlbumViewModel album)
        {

            var value = _albumService.TGetById(album.AlbumId);
            value.AlbumName = album.AlbumName;
            value.SingerId = album.SingerId;
            value.Price = album.Price;
            if (album.Image != null)
            {
                string imageName = ImageSetting.CreateImage(album.Image, "Albums");
                ImageSetting.DeleteImage(value.CoverImage);
                value.CoverImage = imageName;
           

            }

            _albumService.TUpdate(value);
            TempData["Result"] = "Güncelleme işlemi başarılı";
            TempData["icon"] = "success";
            return RedirectToAction("Index");
        }
    }
}
