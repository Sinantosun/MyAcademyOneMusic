using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Models.AlbumModels
{
    public class CreateAlbumViewModel
    {
        public string AlbumName { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }

        public int SingerId { get; set; }

        public IFormFile Image { get; set; }
    }
}
