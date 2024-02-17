using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.SocialMedia.GetListByLanguageCode
{
    public class SocialMediaGetListByLanguageCodeQueryValidator:AbstractValidator<SocialMediaGetListByLanguageCodeQueryRequest>
    {
        public SocialMediaGetListByLanguageCodeQueryValidator()
        {
            RuleFor(language => language.LanguageCode)
                .NotEmpty()
                .NotNull()
                .WithName("Dil Kodu");
        }
    }
}
