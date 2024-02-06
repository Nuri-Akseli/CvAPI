using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Education.Delete
{
    public class EducationDeleteCommandValidator:AbstractValidator<EducationDeleteCommandRequest>
    {
        public EducationDeleteCommandValidator()
        {
            RuleFor(education => education.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
