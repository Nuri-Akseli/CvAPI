using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvInformation.GetSingle
{
    public class CvInformationGetSingleQueryValidator:AbstractValidator<CvInformationGetSingleQueryRequest>
    {
        public CvInformationGetSingleQueryValidator()
        {
            RuleFor(cvInfo => cvInfo.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
