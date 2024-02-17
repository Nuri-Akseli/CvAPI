using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Education.GetListByLanguageCode
{
    public class EducationGetListByLanguageCodeQueryValidator:AbstractValidator<EducationGetListByLanguageCodeQueryRequest>
    {
        public EducationGetListByLanguageCodeQueryValidator()
        {
            RuleFor(language => language.LanguageCode)
                .NotEmpty()
                .NotNull()
                .WithName("Dil Kodu");
        }
    }
}
