using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Application.Repositories.PartCategoryRepositories;
using CvAPI.Application.Repositories.PersonalnformationRepositories;
using CvAPI.Application.Repositories.ProjectRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Project.GetListByLanguageCode
{
    public class ProjectGetListByLanguageCodeQueryHandler:IRequestHandler<ProjectGetListByLanguageCodeQueryRequest,ProjectGetListByLanguageCodeQueryResponse>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IPartCategoryReadRepository _partCategoryReadRepository;
        private readonly IProjectReadRepository _projectReadRepository;
        public ProjectGetListByLanguageCodeQueryHandler(ILanguageReadRepository languageReadRepository,
        ICvPartReadRepository cvPartReadRepository,
        IPartCategoryReadRepository partCategoryReadRepository,
        IProjectReadRepository projectReadRepository)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _languageReadRepository = languageReadRepository;
            _partCategoryReadRepository = partCategoryReadRepository;
            _projectReadRepository = projectReadRepository;

        }

        public async Task<ProjectGetListByLanguageCodeQueryResponse> Handle(ProjectGetListByLanguageCodeQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(lang => lang.IsActive == true && lang.Code == request.LanguageCode, false);

            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");
            Domain.Entities.PartCategory partCategory = await _partCategoryReadRepository.GetSingleAsync(part => part.Name == "Kişisel Bilgi");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(part => part.IsActive == true && part.CvInformation.LanguageId == language.Id && part.PartCategoryId == partCategory.Id, false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            var data = _projectReadRepository.GetWhere(project => project.IsActive == true && project.CvPartId == cvPart.Id, false)
                .OrderBy(p => p.Order)
                .Select(p => new
                {
                    p.Name,
                    p.Link,
                    p.ShortDescription
                }).ToList();

            return new()
            {
                Projects = data,
                IconName=cvPart.IconName,
                IconPath=cvPart.IconPath,
                Name = cvPart.Name
            };
        }
    }
}
