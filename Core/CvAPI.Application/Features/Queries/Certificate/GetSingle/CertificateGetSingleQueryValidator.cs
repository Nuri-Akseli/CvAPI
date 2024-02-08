using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Certificate.GetSingle
{
    public class CertificateGetSingleQueryValidator:AbstractValidator<CertificateGetSingleQueryRequest>
    {
        public CertificateGetSingleQueryValidator()
        {
            RuleFor(certificate => certificate.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
