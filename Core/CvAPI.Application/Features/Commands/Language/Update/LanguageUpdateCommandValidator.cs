using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Language.Update
{
    public class LanguageUpdateCommandValidator:AbstractValidator<LanguageUpdateCommandRequest>
    {
        public LanguageUpdateCommandValidator()
        {
            RuleFor(language=>language.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .WithName("İsim");

            RuleFor(language => language.Code)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Kod");

            RuleFor(language => language.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Id");

        }
    }
}
