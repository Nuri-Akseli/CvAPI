using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Application.Repositories.PartCategoryRepositories;
using CvAPI.Application.Repositories.SkillRepositories;
using CvAPI.Application.Repositories.SocialMediaRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.SocialMedia.GetListByLanguageCode
{
    public class SocialMediaGetListByLanguageCodeQueryHandler:IRequestHandler<SocialMediaGetListByLanguageCodeQueryRequest,SocialMediaGetListByLanguageCodeQueryResponse>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IPartCategoryReadRepository _partCategoryReadRepository;
        private readonly ISocialMediaReadRepository _socialMediaReadRepository;

        public SocialMediaGetListByLanguageCodeQueryHandler(ILanguageReadRepository languageReadRepository,
        ICvPartReadRepository cvPartReadRepository,
        IPartCategoryReadRepository partCategoryReadRepository,
        ISocialMediaReadRepository socialMediaReadRepository)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _languageReadRepository = languageReadRepository;
            _partCategoryReadRepository = partCategoryReadRepository;
            _socialMediaReadRepository = socialMediaReadRepository;

        }

        public async Task<SocialMediaGetListByLanguageCodeQueryResponse> Handle(SocialMediaGetListByLanguageCodeQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(lang => lang.IsActive == true && lang.Code == request.LanguageCode, false);

            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");
            Domain.Entities.PartCategory partCategory = await _partCategoryReadRepository.GetSingleAsync(part => part.Name == "Kişisel Bilgi");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(part => part.IsActive == true && part.CvInformation.LanguageId == language.Id && part.PartCategoryId == partCategory.Id, false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            var data = _socialMediaReadRepository.GetWhere(socialMedia => socialMedia.IsActive == true && socialMedia.CvPartId == cvPart.Id, false)
                .OrderBy(s => s.Order)
                .Select(s => new
                {
                   s.Url,
                   s.IconName,
                   s.IconPath
                }).ToList();

            return new()
            {
                SocialMedias = data,
                IconName=cvPart.IconName,
                IconPath=cvPart.IconPath,
                Name = cvPart.Name
            };
        }
    }
}
