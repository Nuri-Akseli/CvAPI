using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvPart.Create
{
    public class CvPartCreateCommandValidator:AbstractValidator<CvPartCreateCommandRequest>
    {
        public CvPartCreateCommandValidator()
        {
            RuleFor(cvPart => cvPart.Order)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithName("Sıra");

            RuleFor(cvPart => cvPart.CvInformationId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Cv Bilgisi");

            RuleFor(cvPart => cvPart.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(200)
                .WithName("Cv Bölüm İsmi");

            RuleFor(cvPart => cvPart.IsContactInfo)
                .NotNull()
                .WithName("İletişim Kontrol");
        }
    }
}
