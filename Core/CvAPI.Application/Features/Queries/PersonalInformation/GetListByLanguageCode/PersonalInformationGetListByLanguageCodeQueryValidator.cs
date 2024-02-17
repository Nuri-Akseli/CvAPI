using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.PersonalInformation.GetListByLanguageCode
{
    public class PersonalInformationGetListByLanguageCodeQueryValidator:AbstractValidator<PersonalInformationGetListByLanguageCodeQueryRequest>
    {
        public PersonalInformationGetListByLanguageCodeQueryValidator()
        {
            RuleFor(language => language.LanguageCode)
                .NotEmpty()
                .NotNull()
                .WithName("Dil Kodu");
        }
    }
}
