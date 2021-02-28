using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidatior : AbstractValidator<Car>
    {
        public CarValidatior()
        {
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.CarName).MinimumLength(2);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(0);
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.ModelYear).NotEmpty();
           // RuleFor(p => p.CarName).Must(StartA);
        }

        private bool StartA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
