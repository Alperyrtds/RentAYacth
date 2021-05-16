using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class YacthImageValidator : AbstractValidator<YacthImage>
    {
        public YacthImageValidator()
        {
            RuleFor(p => p.YacthId).NotEmpty();

        }
    }
}
