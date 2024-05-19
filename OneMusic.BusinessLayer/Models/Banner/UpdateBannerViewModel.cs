﻿using Microsoft.AspNetCore.Http;

namespace OneMusic.BusinessLayer.Models.Banner
{
    public class UpdateBannerViewModel
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }

        public IFormFile coverPhoto { get; set; }
    }
}
