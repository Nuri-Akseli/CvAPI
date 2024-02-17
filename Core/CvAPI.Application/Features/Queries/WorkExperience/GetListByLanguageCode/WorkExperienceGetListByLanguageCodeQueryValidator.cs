using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.WorkExperience.GetListByLanguageCode
{
    public class WorkExperienceGetListByLanguageCodeQueryValidator:AbstractValidator<WorkExperienceGetListByLanguageCodeQueryRequest>
    {
        public WorkExperienceGetListByLanguageCodeQueryValidator()
        {
            RuleFor(language => language.LanguageCode)
                .NotEmpty()
                .NotNull()
                .WithName("Dil Kodu");
        }
    }
}
