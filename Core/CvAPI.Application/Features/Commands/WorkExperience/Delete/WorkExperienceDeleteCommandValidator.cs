using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.WorkExperience.Delete
{
    public class WorkExperienceDeleteCommandValidator:AbstractValidator<WorkExperienceDeleteCommandRequest>
    {
        public WorkExperienceDeleteCommandValidator()
        {
            RuleFor(workExperience => workExperience.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
