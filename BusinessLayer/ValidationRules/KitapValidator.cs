using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class KitapValidator : AbstractValidator<Kitap>
    {
        public KitapValidator()
        {
            RuleFor(x => x.KitapAdi).NotEmpty().WithMessage("Kitap Adı gereklidir");
            RuleFor(x => x.KitapYazari).NotEmpty().WithMessage("Kitap Yazarı gereklidir");
            RuleFor(x => x.Aciklama).NotEmpty().WithMessage("Açıklama gereklidir");
            RuleFor(x => x.YayinEvi).NotEmpty().WithMessage("YayınEvi gereklidir");
            RuleFor(x => x.StokDurumu).NotEmpty().WithMessage("Stok Durumu gereklidir");
            //RuleFor(x => x.Tur).NotEmpty().WithMessage("Tür seçiniz");
            RuleFor(x => x.BaskiYil).NotEmpty().WithMessage("Baskı Yılı gereklidir");
        }
    }
}
