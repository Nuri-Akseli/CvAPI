using CvAPI.Application.Repositories.CertificateRepositories;
using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.EducationRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Application.Repositories.PartCategoryRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Education.GetListByLanguageCode
{
    public class EducationGetListByLanguageCodeQueryHandler:IRequestHandler<EducationGetListByLanguageCodeQueryRequest,EducationGetListByLanguageCodeQueryResponse>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IEducationReadRepository _educationReadRepository;
        private readonly IPartCategoryReadRepository _partCategoryReadRepository;

        public EducationGetListByLanguageCodeQueryHandler(ILanguageReadRepository languageReadRepository,
            ICvPartReadRepository cvPartReadRepository,
            IEducationReadRepository educationReadRepository,
            IPartCategoryReadRepository partCategoryReadRepository)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _languageReadRepository= languageReadRepository;
            _educationReadRepository= educationReadRepository;
            _partCategoryReadRepository= partCategoryReadRepository;

        }

        public async Task<EducationGetListByLanguageCodeQueryResponse> Handle(EducationGetListByLanguageCodeQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(lang => lang.IsActive == true && lang.Code == request.LanguageCode, false);

            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");
            Domain.Entities.PartCategory partCategory = await _partCategoryReadRepository.GetSingleAsync(part => part.Name == "Eğitim");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(part => part.IsActive == true && part.CvInformation.LanguageId == language.Id && part.PartCategoryId == partCategory.Id, false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            var data = _educationReadRepository.GetWhere(education => education.IsActive == true && education.CvPartId == cvPart.Id, false)
                .OrderBy(e => e.Order)
                .Select(e => new
                {
                    e.City,
                    e.University,
                    e.Department,
                    e.StartDate,
                    e.EndDate,
                    e.Title
                }).ToList();

            return new()
            {
                Educations = data,
                IconName=cvPart.IconName,
                IconPath=cvPart.IconPath,
                Name = cvPart.Name
            };
        }
    }
}
