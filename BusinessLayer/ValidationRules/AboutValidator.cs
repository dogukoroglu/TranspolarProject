using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AboutValidator : AbstractValidator<About>
	{
        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.SubDescription).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.SubIcon).NotEmpty().WithMessage("Bu alan boş geçilemez!");
        }
    }
}
