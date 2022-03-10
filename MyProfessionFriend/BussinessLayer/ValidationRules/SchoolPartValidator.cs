using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class SchoolPartValidator : AbstractValidator<SchoolPart>
    {
        public SchoolPartValidator()
        {
            RuleFor(x => x.ScpartName).NotEmpty().WithMessage("Bölüm adını boş geçemezsiniz");
            RuleFor(x => x.ScpartName).MinimumLength(3).WithMessage("En az 3 karakter girin");
            RuleFor(x => x.ScpartName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla giriş yapmayın");
        }
    }
}
