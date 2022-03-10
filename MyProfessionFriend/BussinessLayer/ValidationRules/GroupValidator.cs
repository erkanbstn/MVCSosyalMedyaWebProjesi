using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    class GroupValidator : AbstractValidator<Group>
    {
        public GroupValidator()
        {
            RuleFor(x => x.GroupName).NotEmpty().WithMessage("Etkinlik adını boş geçemezsiniz");
            RuleFor(x => x.GroupNote).NotEmpty().WithMessage("Açıkamayı boş bırakamazsınız");
            RuleFor(x => x.GroupName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girin");
            RuleFor(x => x.GroupName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla giriş yapmayın");
        }
    }
}
