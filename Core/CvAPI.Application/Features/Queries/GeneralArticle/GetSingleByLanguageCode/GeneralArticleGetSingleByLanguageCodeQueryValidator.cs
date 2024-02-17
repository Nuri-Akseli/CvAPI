using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.GeneralArticle.GetSingleByLanguageCode
{
    public class GeneralArticleGetSingleByLanguageCodeQueryValidator:AbstractValidator<GeneralArticleGetSingleByLanguageCodeQueryRequest>
    {
        public GeneralArticleGetSingleByLanguageCodeQueryValidator()
        {
            RuleFor(language => language.LanguageCode)
                .NotEmpty()
                .NotNull()
                .WithName("Dil Kodu");
        }
    }
}
