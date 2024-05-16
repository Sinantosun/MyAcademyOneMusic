using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.BusinessLayer.Models.Singer;
using OneMusic.BusinessLayer.ValidationRules;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.ImageSettings;

namespace OneMusic.WebUI.Controllers
{
    public class AdminSingerController : Controller
    {
        private readonly ISingerService _singerService;

        public AdminSingerController(ISingerService singerService)
        {
            _singerService = singerService;
        }

        public IActionResult Index()
        {
            var values = _singerService.TGetList();
            return View(values);
        }
        public IActionResult DeleteSinger(int id)
        {
            var value = _singerService.TGetById(id);
            _singerService.TDelete(id);
            TempData["Result"] = "Silme işlemi başarılı";
            TempData["icon"] = "success";
            ImageSetting.DeleteImage(value.ImageUrl);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateSinger()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSinger(CreateSingerModel singer)
        {
            ModelState.Clear();
            if (singer.Image != null)
            {
                var validator = new SingerValidator();
                var result = validator.Validate(singer);
                if (result.IsValid)
                {
                    string imageName = ImageSetting.CreateImage(singer.Image, "Singers");
                    var newSinger = new Singer()
                    {
                        Name = singer.Name,
                        ImageUrl = imageName,
                    };

                    _singerService.TCreate(newSinger);
                    TempData["Result"] = "Yeni kayıt eklendi";
                    TempData["icon"] = "success";
                    return RedirectToAction("Index");
                }
                result.Errors.ForEach(x =>
                {

                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
            }
            else
            {
                ModelState.AddModelError("Image", "Görsel Seçiniz");
            }

            TempData["Result"] = "Hata! kayıt eklenemedi";
            TempData["icon"] = "warning";
            return View();
        }

        [HttpGet]
        public IActionResult UpdateSinger(int id)
        {
            var values = _singerService.TGetById(id);
            UpdateSingerModel updateSingerModel = new UpdateSingerModel()
            {
                
                Name = values.Name,
                SingerId = values.SingerId,
            };
            return View(updateSingerModel);
        }
        [HttpPost]
        public IActionResult UpdateSinger(UpdateSingerModel singer)
        {
            ModelState.Clear();

            var value = _singerService.TGetById(singer.SingerId);
            value.Name = singer.Name;
            if (singer.Image != null)
            {
                string imageName = ImageSetting.CreateImage(singer.Image, "Singers");
                ImageSetting.DeleteImage(value.ImageUrl);
                value.ImageUrl = imageName;
            }

            _singerService.TUpdate(value);
            TempData["Result"] = "Kayıt güncellendi.";
            TempData["icon"] = "success";
            return RedirectToAction("Index");

        }
    }
}
