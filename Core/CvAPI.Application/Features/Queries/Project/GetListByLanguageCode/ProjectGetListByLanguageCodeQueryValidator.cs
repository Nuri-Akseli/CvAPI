using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Project.GetListByLanguageCode
{
    public class ProjectGetListByLanguageCodeQueryValidator:AbstractValidator<ProjectGetListByLanguageCodeQueryRequest>
    {
        public ProjectGetListByLanguageCodeQueryValidator()
        {
            RuleFor(language => language.LanguageCode)
                .NotEmpty()
                .NotNull()
                .WithName("Dil Kodu");
        }
    }
}
