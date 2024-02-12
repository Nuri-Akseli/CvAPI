using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Skill.UpdateActivity
{
    public class SkillUpdateActivityCommandValidator:AbstractValidator<SkillUpdateActivityCommandRequest>
    {
        public SkillUpdateActivityCommandValidator()
        {
            RuleFor(skill => skill.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(skill => skill.IsActive)
                .NotNull()
                .WithName("Aktiflik");
        }
    }
}
