using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Education.UpdateActivity
{
    public class EducationUpdateActivityCommandValidator:AbstractValidator<EducationUpdateActivityCommandRequest>
    {
        public EducationUpdateActivityCommandValidator()
        {
            RuleFor(education => education.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(education => education.IsActive)
                .NotNull()
                .WithName("Aktiflik");
        }
    }
}
