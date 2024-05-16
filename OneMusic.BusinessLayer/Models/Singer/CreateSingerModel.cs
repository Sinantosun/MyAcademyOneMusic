using Microsoft.AspNetCore.Http;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.BusinessLayer.Models.Singer
{
    public class CreateSingerModel
    {
        public int SingerId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public IFormFile Image { get; set; }
    }
}
