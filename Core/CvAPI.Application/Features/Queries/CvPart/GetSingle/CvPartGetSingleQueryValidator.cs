using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvPart.GetSingle
{
    public class CvPartGetSingleQueryValidator:AbstractValidator<CvPartGetSingleQueryRequest>
    {
        public CvPartGetSingleQueryValidator()
        {
            RuleFor(cvPart => cvPart.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Cv Bölüm Id");
        }
    }
}
