using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class PeopleValidator :AbstractValidator<People>
    {
        public PeopleValidator()
        {
            RuleFor(x => x.PeopleName).NotEmpty().WithMessage("Kişi adını boş geçemezsiniz");
            RuleFor(x => x.PeopleSurName).NotEmpty().WithMessage("Soyadını boş bırakamazsınız");
            RuleFor(x => x.PeopleMail).EmailAddress().WithMessage("Geçerli bir email adresi girin");
            RuleFor(x => x.PeoplePass).MinimumLength(8).WithMessage("Lütfen en az 8 karakter girin");
            RuleFor(x => x.PeoplePass).Equal(x=>x.PeopleRepass).WithMessage("Şİfreler eşleşmiyor");
            //RuleFor(x => x.PeopleTitle).NotEmpty().WithMessage("Ünvan kısmını bırakamazsınız");
            RuleFor(x => x.PeopleSurName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girin");
            RuleFor(x => x.PeopleSurName).MaximumLength(50).WithMessage("Lütfen 20 karakterden fazla giriş yapmayın");
        }

    }
}
