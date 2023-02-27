using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.DTO;

namespace TaskAspNetCoreWebApi.Business.Validators
{
    public class BookValidator : AbstractValidator<AddBookDTO>
    {
        public BookValidator() 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Title).NotEmpty().WithMessage("Title must not be empty");
            RuleFor(x => x.Genre).NotEmpty().WithMessage("Genre must not be empty");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author must not be empty");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content must not be empty");
        }
    }
}
