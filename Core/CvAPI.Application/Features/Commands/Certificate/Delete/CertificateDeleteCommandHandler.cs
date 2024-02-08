using CvAPI.Application.Repositories.CertificateRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Certificate.Delete
{
    public class CertificateDeleteCommandHandler:IRequestHandler<CertificateDeleteCommandRequest, CertificateDeleteCommandResponse>
    {
        private readonly ICertificateReadRepository _certificateReadRepository;
        private readonly ICertificateWriteRepository _certificateWriteRepository;
        public CertificateDeleteCommandHandler(ICertificateReadRepository certificateReadRepository,ICertificateWriteRepository certificateWriteRepository)
        {
            _certificateReadRepository= certificateReadRepository;
            _certificateWriteRepository= certificateWriteRepository;

        }

        public async Task<CertificateDeleteCommandResponse> Handle(CertificateDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Certificate certificate = await _certificateReadRepository.GetByIdAsync(request.Id, false);

            if (certificate == null)
                throw new BadRequestException("Sertifika Bulunamadı");

            bool result = _certificateWriteRepository.Remove(certificate);
            await _certificateWriteRepository.SaveAsync();
            if (result)
                return new();
            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
