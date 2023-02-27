using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.DTO;

namespace TaskAspNetCoreWebApi.Business.Validators
{
    public class ReviewValidator : AbstractValidator<AddReviewDTO>
    {
        public ReviewValidator() 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Message).NotEmpty().WithMessage("Message must not be empty");

            RuleFor(x => x.Reviewer).NotEmpty().WithMessage("Reviewer must not be empty");
        }
    }
}
