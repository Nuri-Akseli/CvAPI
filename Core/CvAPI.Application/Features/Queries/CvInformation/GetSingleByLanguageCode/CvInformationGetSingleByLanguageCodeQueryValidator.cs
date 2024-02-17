using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvInformation.GetSingleByLanguageCode
{
    public class CvInformationGetSingleByLanguageCodeQueryValidator:AbstractValidator<CvInformationGetSingleByLanguageCodeQueryRequest>
    {
        public CvInformationGetSingleByLanguageCodeQueryValidator()
        {
            RuleFor(language => language.LanguageCode)
                .NotEmpty()
                .NotNull()
                .WithName("Dil Kodu");
        }
    }
}
