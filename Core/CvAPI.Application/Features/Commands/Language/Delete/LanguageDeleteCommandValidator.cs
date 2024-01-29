using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Language.Delete
{
    public class LanguageDeleteCommandValidator:AbstractValidator<LanguageDeleteCommandRequest>
    {
        public LanguageDeleteCommandValidator()
        {
            RuleFor(language => language.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
