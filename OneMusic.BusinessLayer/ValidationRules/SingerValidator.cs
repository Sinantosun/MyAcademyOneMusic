using FluentValidation;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.ValidationRules
{
    public class SingerValidator : AbstractValidator<Singer>
    {
        public SingerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("En fazla 50 karakter yazmalısınız");
            RuleFor(x => x.Name).MinimumLength(4).WithMessage("En az 4 karakter yazmalısınız");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Lütfen Görsel Seçiniz");
        }
    }
}
