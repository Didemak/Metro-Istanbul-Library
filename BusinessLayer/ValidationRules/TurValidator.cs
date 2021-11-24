using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TurValidator: AbstractValidator<Tur>
    {
        public TurValidator()
        {
            RuleFor(x => x.TurAdi).NotEmpty().WithMessage("Tür Adı gereklidir");
        }
    }
}
