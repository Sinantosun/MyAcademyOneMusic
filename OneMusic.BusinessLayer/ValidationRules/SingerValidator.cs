using FluentValidation;
using OneMusic.BusinessLayer.Models.Album;
using OneMusic.BusinessLayer.Models.Singer;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.ValidationRules
{
    public class SingerValidator : AbstractValidator<CreateSingerModel>
    {
        public SingerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("En fazla 50 karakter yazmalısınız");
            RuleFor(x => x.Name).MinimumLength(4).WithMessage("En az 4 karakter yazmalısınız");
            RuleFor(x => x.Image.FileName).Must(CheckExtension).WithMessage("Seçtiğiniz dosya uzantısı desteklenmiyor lütfen görsel uzantılarından (.jpg - .png - .jpeg) birini seçin.");
        }
        private bool CheckExtension(string fileName)
        {
            var ex = Path.GetExtension(fileName);
            if (ex == ".png" || ex == "jpg" || ex == ".jpeg")
            {
                return true;
            }
            return false;
        }
    }
}
