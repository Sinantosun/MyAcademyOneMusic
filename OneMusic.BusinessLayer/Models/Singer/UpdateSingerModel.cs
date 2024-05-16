using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.Models.Singer
{
    public class UpdateSingerModel
    {
        public int SingerId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public IFormFile Image { get; set; }

    }
}
