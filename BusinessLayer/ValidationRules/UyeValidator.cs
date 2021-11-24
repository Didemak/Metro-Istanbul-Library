using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UyeValidator:AbstractValidator<Uye>
    {
        public UyeValidator()
        {
            RuleFor(x => x.UyeAdi).NotEmpty().WithMessage("Üye Adı gereklidir");
            RuleFor(x => x.UyeSoyadi).NotEmpty().WithMessage("Üye Soyadı gereklidir");
            RuleFor(x => x.SicilNo).NotEmpty().WithMessage("Sicil Numarası gereklidir");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Posta gereklidir");
            RuleFor(x => x.Cinsiyet).NotEmpty().WithMessage("Cinsiyet gereklidir");
            RuleFor(x => x.TelefonNo).NotEmpty().WithMessage("Telefon Numarası gereklidir");
            
        }
    }
}
