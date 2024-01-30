using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvInformation.UpdateActivity
{
    public class CvInformationUpdateActivityCommandValidator:AbstractValidator<CvInformationUpdateActivityCommandRequest>
    {
        public CvInformationUpdateActivityCommandValidator()
        {
            RuleFor(cvInfo => cvInfo.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(cvInfo => cvInfo.Activity)
                .NotNull()
                .NotEmpty()
                .WithName("Aktiflik");
        }
    }
}
