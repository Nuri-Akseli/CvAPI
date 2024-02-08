using CvAPI.Application.Repositories.CertificateRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Certificate.GetSingle
{
    public class CertificateGetSingleQueryHandler:IRequestHandler<CertificateGetSingleQueryRequest,CertificateGetSingleQueryResponse>
    {
        private readonly ICertificateReadRepository _certificateReadRepository;
        public CertificateGetSingleQueryHandler(ICertificateReadRepository certificateReadRepository)
        {
            _certificateReadRepository = certificateReadRepository;
        }

        public async Task<CertificateGetSingleQueryResponse> Handle(CertificateGetSingleQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Certificate certificate = await _certificateReadRepository.GetByIdAsync(request.Id, false);

            if (certificate == null)
                throw new BadRequestException("Sertifika Bulunamadı");

            return new()
            {
                Id = certificate.Id,
                CvPartId = certificate.CvPartId,
                IsActive = certificate.IsActive,
                Link = certificate.Link,
                Name = certificate.Name,
                Order = certificate.Order,
                Organization = certificate.Organization,
                ShortDescription = certificate.ShortDescription
            };
        }
    }
}
