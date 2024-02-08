using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Certificate.Delete
{
    public class CertificateDeleteCommandValidator:AbstractValidator<CertificateDeleteCommandRequest>
    {
        public CertificateDeleteCommandValidator()
        {
            RuleFor(certificate => certificate.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
