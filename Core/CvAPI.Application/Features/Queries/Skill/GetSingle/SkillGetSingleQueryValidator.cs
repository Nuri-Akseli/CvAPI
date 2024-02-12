using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Skill.GetSingle
{
    public class SkillGetSingleQueryValidator:AbstractValidator<SkillGetSingleQueryRequest>
    {
        public SkillGetSingleQueryValidator()
        {
            RuleFor(skill => skill.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
