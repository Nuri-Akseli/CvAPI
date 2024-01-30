using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvInformation.Delete
{
    public class CvInformationDeleteCommandValidator:AbstractValidator<CvInformationDeleteCommandRequest>
    {
        public CvInformationDeleteCommandValidator()
        {
            RuleFor(cvInfo => cvInfo.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
