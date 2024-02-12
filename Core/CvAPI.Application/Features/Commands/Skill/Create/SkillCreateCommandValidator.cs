using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Skill.Create
{
    public class SkillCreateCommandValidator:AbstractValidator<SkillCreateCommandRequest>
    {
        public SkillCreateCommandValidator()
        {
            RuleFor(skill => skill.Order)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithName("Sıra");

            RuleFor(skill => skill.CvPartId)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithName("Cv Bölümü");

            RuleFor(skill => skill.Name)
               .NotNull()
               .NotEmpty()
               .MaximumLength(255)
               .WithName("İsim");

            RuleFor(skill => skill.Ratio)
              .NotNull()
              .LessThanOrEqualTo(100)
              .GreaterThanOrEqualTo(0)
              .WithName("Sıra");
        }
    }
}
