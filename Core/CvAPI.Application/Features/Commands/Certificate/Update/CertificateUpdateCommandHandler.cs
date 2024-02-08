using CvAPI.Application.Repositories.CertificateRepositories;
using CvAPI.Application.Repositories.CvPartRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Certificate.Update
{
    public class CertificateUpdateCommandHandler:IRequestHandler<CertificateUpdateCommandRequest, CertificateUpdateCommandResponse>
    {
        private readonly ICertificateReadRepository _certificateReadRepository;
        private readonly ICertificateWriteRepository _certificateWriteRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        public CertificateUpdateCommandHandler(ICertificateReadRepository certificateReadRepository,ICertificateWriteRepository certificateWriteRepository,ICvPartReadRepository cvPartReadRepository)
        {
            _certificateReadRepository = certificateReadRepository;
            _certificateWriteRepository=certificateWriteRepository;
            _cvPartReadRepository= cvPartReadRepository;

        }

        public async Task<CertificateUpdateCommandResponse> Handle(CertificateUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            Domain.Entities.Certificate certificate = await _certificateReadRepository.GetByIdAsync(request.Id, false);
            if (certificate == null)
                throw new BadRequestException("Sertifika Bulunamadı");

            certificate.ShortDescription=request.ShortDescription;
            certificate.CvPartId = request.CvPartId;
            certificate.Order = request.Order;
            certificate.Organization = request.Organization;
            certificate.Link = request.Link;
            certificate.Name = request.Name;

            bool result = _certificateWriteRepository.Update(certificate);
            await _certificateWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
