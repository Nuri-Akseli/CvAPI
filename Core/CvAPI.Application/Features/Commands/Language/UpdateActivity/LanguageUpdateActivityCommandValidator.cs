using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Language.UpdateActivity
{
    public class LanguageUpdateActivityCommandValidator:AbstractValidator<LanguageUpdateActivityCommandRequest>
    {
        public LanguageUpdateActivityCommandValidator()
        {
            RuleFor(language => language.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(language => language.Activity)
                .NotEmpty()
                .NotNull()
                .WithName("Aktiflik");
        }
    }
}
