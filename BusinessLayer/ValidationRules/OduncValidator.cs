using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class OduncValidator: AbstractValidator<Odunc>
    {
        public OduncValidator()
        {
            RuleFor(x => x.Uye.SicilNo).NotEmpty().WithMessage("Sicil Numarası gereklidir");
        }
    }
}
