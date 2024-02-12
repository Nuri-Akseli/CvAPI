using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Skill.Delete
{
    public class SkillDeleteCommandValidator:AbstractValidator<SkillDeleteCommandRequest>
    {
        public SkillDeleteCommandValidator()
        {
            RuleFor(skill => skill.Id)
                .NotNull()
                .GreaterThan(0)
                .WithName("Beceri");
        }
    }
}
