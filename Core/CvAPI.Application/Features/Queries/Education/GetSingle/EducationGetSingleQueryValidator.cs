using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Education.GetSingle
{
    public class EducationGetSingleQueryValidator:AbstractValidator<EducationGetSingleQueryRequest>
    {
        public EducationGetSingleQueryValidator()
        {
            RuleFor(education => education.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
