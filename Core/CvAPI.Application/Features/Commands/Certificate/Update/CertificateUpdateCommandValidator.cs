using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Certificate.Update
{
    public class CertificateUpdateCommandValidator:AbstractValidator<CertificateUpdateCommandRequest>
    {
        public CertificateUpdateCommandValidator()
        {
            RuleFor(certificate => certificate.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");
            RuleFor(certificate => certificate.CvPartId)
               .NotNull()
               .NotEmpty()
               .GreaterThan(0)
               .WithName("Cv Bölümü");

            RuleFor(certificate => certificate.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(200)
                .WithName("İsim");

            RuleFor(certificate => certificate.Order)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithName("Sıra");

            RuleFor(certificate => certificate.Organization)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(200)
                .WithName("Organizasyon");


        }
    }
}
