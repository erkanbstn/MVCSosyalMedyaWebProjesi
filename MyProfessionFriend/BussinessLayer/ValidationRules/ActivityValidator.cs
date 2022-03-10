using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(x => x.ActivityName).NotEmpty().WithMessage("Etkinlik adını boş geçemezsiniz");
            RuleFor(x => x.ActivityContent).NotEmpty().WithMessage("Açıkamayı boş bırakamazsınız");
            RuleFor(x => x.ActivityName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girin");
            RuleFor(x => x.ActivityName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla giriş yapmayın");
        }
    }
}
