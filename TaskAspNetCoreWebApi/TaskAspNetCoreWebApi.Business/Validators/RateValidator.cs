using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.DTO;

namespace TaskAspNetCoreWebApi.Business.Validators
{
    public class RateValidator : AbstractValidator<RatingDTO>
    {
        public RateValidator() 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Score)
                .NotEmpty().WithMessage("Provide non empty field")
                .LessThan(6).WithMessage("Value must be less than 6")
                .GreaterThan(0).WithMessage("Value must be greater than 0");
        }
    }
}
