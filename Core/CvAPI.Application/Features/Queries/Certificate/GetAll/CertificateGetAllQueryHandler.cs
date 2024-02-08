using CvAPI.Application.Repositories.CertificateRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Certificate.GetAll
{
    public class CertificateGetAllQueryHandler:IRequestHandler<CertificateGetAllQueryRequest,CertificateGetAllQueryResponse>
    {
        private readonly ICertificateReadRepository _certificateReadRepository;
        public CertificateGetAllQueryHandler(ICertificateReadRepository certificateReadRepository)
        {
            _certificateReadRepository=certificateReadRepository;
        }

        public async Task<CertificateGetAllQueryResponse> Handle(CertificateGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Certificate> certificates = _certificateReadRepository.GetAll(false).ToList();
            return new()
            {
                Certificates = certificates
            };
        }
    }
}
