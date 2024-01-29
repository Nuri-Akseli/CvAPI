using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Language.GetSingleByCode
{
    public class LanguageGetSingleByCodeQueryValidator:AbstractValidator<LanguageGetSingleByCodeQueryRequest>
    {
        public LanguageGetSingleByCodeQueryValidator()
        {
            RuleFor(language => language.Code)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Kod");
        }
    }
}
