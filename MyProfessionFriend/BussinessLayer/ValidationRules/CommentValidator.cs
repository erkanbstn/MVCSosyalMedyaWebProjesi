using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.CommentContent).NotEmpty().WithMessage("Yorumu boş geçemezsiniz");
            RuleFor(x => x.CommentContent).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla giriş yapmayın");
        }
    }
}
