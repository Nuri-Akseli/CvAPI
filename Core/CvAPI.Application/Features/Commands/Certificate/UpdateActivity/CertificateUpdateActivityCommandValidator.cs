using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Certificate.UpdateActivity
{
    public class CertificateUpdateActivityCommandValidator:AbstractValidator<CertificateUpdateActivityCommandRequest>
    {
        public CertificateUpdateActivityCommandValidator()
        {
            RuleFor(certificate => certificate.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(certificate => certificate.IsActive)
                .NotNull()
                .WithName("Aktiflik");
        }
    }
}
