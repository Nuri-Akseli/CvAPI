using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.WorkExperience.GetSingle
{
    public class WorkExperienceGetSingleQueryValidator:AbstractValidator<WorkExperienceGetSingleQueryRequest>
    {
        public WorkExperienceGetSingleQueryValidator()
        {
            RuleFor(workExperience => workExperience.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
