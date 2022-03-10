using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("gönderilen mailini boş geçemezsiniz");
            RuleFor(x => x.SenderMail).NotEmpty().WithMessage("gönderen mailini boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriğini boş bırakamazsınız");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girin");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girin");

        }
    }
}

