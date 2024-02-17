using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.HobbyRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Application.Repositories.PartCategoryRepositories;
using CvAPI.Application.Repositories.PersonalnformationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.PersonalInformation.GetListByLanguageCode
{
    public class PersonalInformationGetListByLanguageCodeQueryHandler:IRequestHandler<PersonalInformationGetListByLanguageCodeQueryRequest,PersonalInformationGetListByLanguageCodeQueryResponse>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IPartCategoryReadRepository _partCategoryReadRepository;
        private readonly IPersonalInformationReadRespository _personalInformationReadRespository;

        public PersonalInformationGetListByLanguageCodeQueryHandler(ILanguageReadRepository languageReadRepository,
        ICvPartReadRepository cvPartReadRepository,
        IPartCategoryReadRepository partCategoryReadRepository,
        IPersonalInformationReadRespository personalInformationReadRespository)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _languageReadRepository = languageReadRepository;
            _partCategoryReadRepository = partCategoryReadRepository;
            _personalInformationReadRespository = personalInformationReadRespository;

        }

        public async Task<PersonalInformationGetListByLanguageCodeQueryResponse> Handle(PersonalInformationGetListByLanguageCodeQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(lang => lang.IsActive == true && lang.Code == request.LanguageCode, false);

            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");
            Domain.Entities.PartCategory partCategory = await _partCategoryReadRepository.GetSingleAsync(part => part.Name == "Kişisel Bilgi");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(part => part.IsActive == true && part.CvInformation.LanguageId == language.Id && part.PartCategoryId == partCategory.Id, false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            var data = _personalInformationReadRespository.GetWhere(personalInfo => personalInfo.IsActive == true && personalInfo.CvPartId == cvPart.Id, false)
                .OrderBy(p => p.Order)
                .Select(p => new
                {
                    p.Name,
                    p.IconPath,
                    p.IconName
                }).ToList();

            return new()
            {
                PersonalInformations = data,
                IconName=cvPart.IconName,
                IconPath=cvPart.IconPath,
                Name = cvPart.Name
            };
        }
    }
}
