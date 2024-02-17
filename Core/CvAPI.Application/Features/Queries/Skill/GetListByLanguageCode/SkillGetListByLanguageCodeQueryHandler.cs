using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Application.Repositories.PartCategoryRepositories;
using CvAPI.Application.Repositories.ProjectRepositories;
using CvAPI.Application.Repositories.SkillRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Skill.GetListByLanguageCode
{
    public class SkillGetListByLanguageCodeQueryHandler:IRequestHandler<SkillGetListByLanguageCodeQueryRequest,SkillGetListByLanguageCodeQueryResponse>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IPartCategoryReadRepository _partCategoryReadRepository;
        private readonly ISkillReadRepository _skillReadRepository;

        public SkillGetListByLanguageCodeQueryHandler(ILanguageReadRepository languageReadRepository,
        ICvPartReadRepository cvPartReadRepository,
        IPartCategoryReadRepository partCategoryReadRepository,
        ISkillReadRepository skillReadRepository)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _languageReadRepository = languageReadRepository;
            _partCategoryReadRepository = partCategoryReadRepository;
            _skillReadRepository = skillReadRepository;

        }

        public async Task<SkillGetListByLanguageCodeQueryResponse> Handle(SkillGetListByLanguageCodeQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(lang => lang.IsActive == true && lang.Code == request.LanguageCode, false);

            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");
            Domain.Entities.PartCategory partCategory = await _partCategoryReadRepository.GetSingleAsync(part => part.Name == "Kişisel Bilgi");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(part => part.IsActive == true && part.CvInformation.LanguageId == language.Id && part.PartCategoryId == partCategory.Id, false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            var data = _skillReadRepository.GetWhere(skill => skill.IsActive == true && skill.CvPartId == cvPart.Id, false)
                .OrderBy(s => s.Order)
                .Select(s => new
                {
                    s.Name,
                    s.Ratio
                }).ToList();

            return new()
            {
                Skills = data,
                IconName = cvPart.IconName,
                IconPath = cvPart.IconPath,
                Name = cvPart.Name,
            };

        }
    }
}
