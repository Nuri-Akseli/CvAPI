using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvInformation.Update
{
    public class CvInformationUpdateCommandValidator:AbstractValidator<CvInformationUpdateCommandRequest>
    {
        public CvInformationUpdateCommandValidator()
        {
            RuleFor(cvInfo => cvInfo.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(cvInfo => cvInfo.CvName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(100)
                .WithName("Cv İsmi");

            RuleFor(cvInfo => cvInfo.NameSurname)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(100)
                .WithName("İsim");

            RuleFor(cvInfo => cvInfo.LanguageId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Dil");

        }
    }
}
