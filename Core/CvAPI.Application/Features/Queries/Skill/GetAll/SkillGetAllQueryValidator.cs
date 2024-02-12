using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Skill.GetAll
{
    public class SkillGetAllQueryValidator:AbstractValidator<SkillGetAllQueryRequest>
    {
        public SkillGetAllQueryValidator()
        {
            
        }
    }
}
