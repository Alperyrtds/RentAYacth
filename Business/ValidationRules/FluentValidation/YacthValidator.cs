using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class YacthValidator : AbstractValidator<Yacth>
    {
        public YacthValidator()
        {
            RuleFor(c => c.ModelName).NotEmpty();
            RuleFor(c => c.ModelName).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.Description).MinimumLength(5);
            RuleFor(c => c.ModelYear).Must(x => x.ToString().Length == 4);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.MinFindex);

        }

    }
}
