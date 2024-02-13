using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.WorkExperience.UpdateActivity
{
    public class WorkExperienceUpdateActivityCommandValidator:AbstractValidator<WorkExperienceUpdateActivityCommandRequest>
    {
        public WorkExperienceUpdateActivityCommandValidator()
        {
            RuleFor(workExperience => workExperience.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(workExperience => workExperience.IsActive)
                .NotNull()
                .WithName("Aktiflik");
        }
    }
}
