using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Language.GetSingleById
{
    public class LanguageGetSingleByIdQueryValidator:AbstractValidator<LanguageGetSingleByIdQueryRequest>
    {
        public LanguageGetSingleByIdQueryValidator()
        {
            RuleFor(language => language.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
