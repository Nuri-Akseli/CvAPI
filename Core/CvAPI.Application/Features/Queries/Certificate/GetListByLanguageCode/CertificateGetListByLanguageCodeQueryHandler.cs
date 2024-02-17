using CvAPI.Application.Repositories.CertificateRepositories;
using CvAPI.Application.Repositories.CvInformationRepositories;
using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Application.Repositories.PartCategoryRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Certificate.GetListByLanguageCode
{
    public class CertificateGetListByLanguageCodeQueryHandler:IRequestHandler<CertificateGetListByLanguageCodeQueryRequest,CertificateGetListByLanguageCodeQueryResponse>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ICertificateReadRepository _certificateReadRepository;
        private readonly IPartCategoryReadRepository _partCategoryReadRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        public CertificateGetListByLanguageCodeQueryHandler(ILanguageReadRepository languageReadRepository,
            ICertificateReadRepository certificateReadRepository, 
            IPartCategoryReadRepository partCategoryReadRepository,
            ICvPartReadRepository cvPartReadRepository)
        {
            _certificateReadRepository = certificateReadRepository;
            _languageReadRepository = languageReadRepository;
            _partCategoryReadRepository = partCategoryReadRepository;
            _cvPartReadRepository = cvPartReadRepository;
        }

        public async Task<CertificateGetListByLanguageCodeQueryResponse> Handle(CertificateGetListByLanguageCodeQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(lang=>lang.Code==request.LanguageCode && lang.IsActive==true,false);

            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");

            Domain.Entities.PartCategory partCategory = await _partCategoryReadRepository.GetSingleAsync(part => part.Name == "Sertifika");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(part=>part.IsActive==true && part.CvInformation.LanguageId==language.Id && part.PartCategoryId==partCategory.Id,false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");


            var data= _certificateReadRepository.GetWhere(certificate=>certificate.IsActive==true && certificate.CvPartId==cvPart.Id,false)
                .OrderBy(c=>c.Order)
                .Select(c => new
                {
                    c.Name,
                    c.Organization,
                    c.Link,
                    c.ShortDescription
                }).ToList();

            return new() { 
                Certificates = data,
                IconName=cvPart.IconName,
                IconPath=cvPart.IconPath,
                Name=cvPart.Name,
            };

        }
    }
}
