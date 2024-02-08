using CvAPI.Application.Repositories.CertificateRepositories;
using CvAPI.Application.Repositories.CvPartRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Certificate.Create
{
    public class CertificateCreateCommandHandler:IRequestHandler<CertificateCreateCommandRequest, CertificateCreateCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly ICertificateWriteRepository _certificateWriteRepository;
        public CertificateCreateCommandHandler(ICvPartReadRepository cvPartReadRepository,ICertificateWriteRepository certificateWriteRepository)
        {
            _certificateWriteRepository= certificateWriteRepository;
            _cvPartReadRepository= cvPartReadRepository;

        }

        public async Task<CertificateCreateCommandResponse> Handle(CertificateCreateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            bool result = await _certificateWriteRepository.AddAsync(new()
            {
                CvPartId = request.CvPartId,
                Link = request.Link,
                Name = request.Name,
                Order = request.Order,
                Organization = request.Organization,
                ShortDescription = request.ShortDescription
            });
            await _certificateWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");

        }
    }
}
