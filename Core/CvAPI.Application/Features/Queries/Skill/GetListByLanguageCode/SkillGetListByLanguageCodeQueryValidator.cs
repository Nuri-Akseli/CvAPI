﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Skill.GetListByLanguageCode
{
    public class SkillGetListByLanguageCodeQueryValidator:AbstractValidator<SkillGetListByLanguageCodeQueryRequest>
    {
        public SkillGetListByLanguageCodeQueryValidator()
        {
            RuleFor(language => language.LanguageCode)
                .NotEmpty()
                .NotNull()
                .WithName("Dil Kodu");
        }
    }
}
