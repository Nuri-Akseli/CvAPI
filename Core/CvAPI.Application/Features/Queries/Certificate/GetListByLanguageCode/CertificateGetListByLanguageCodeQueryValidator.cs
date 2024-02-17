using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Certificate.GetListByLanguageCode
{
    public class CertificateGetListByLanguageCodeQueryValidator:AbstractValidator<CertificateGetListByLanguageCodeQueryRequest>
    {
        public CertificateGetListByLanguageCodeQueryValidator()
        {
            RuleFor(language => language.LanguageCode)
                .NotEmpty()
                .NotNull()
                .WithName("Dil Kodu");
        }
    }
}
