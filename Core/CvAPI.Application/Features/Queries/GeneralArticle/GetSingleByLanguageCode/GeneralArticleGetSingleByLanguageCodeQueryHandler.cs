using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.EducationRepositories;
using CvAPI.Application.Repositories.GeneralArticleRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Application.Repositories.PartCategoryRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.GeneralArticle.GetSingleByLanguageCode
{
    public class GeneralArticleGetSingleByLanguageCodeQueryHandler:IRequestHandler<GeneralArticleGetSingleByLanguageCodeQueryRequest,GeneralArticleGetSingleByLanguageCodeQueryResponse>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IPartCategoryReadRepository _partCategoryReadRepository;
        private readonly IGeneralArticleReadRepository _generalArticleReadRepository;

        public GeneralArticleGetSingleByLanguageCodeQueryHandler(ILanguageReadRepository languageReadRepository,
        ICvPartReadRepository cvPartReadRepository,
        IPartCategoryReadRepository partCategoryReadRepository,
        IGeneralArticleReadRepository generalArticleReadRepository)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _languageReadRepository = languageReadRepository;
            _partCategoryReadRepository = partCategoryReadRepository;
            _generalArticleReadRepository = generalArticleReadRepository;

        }

        public async Task<GeneralArticleGetSingleByLanguageCodeQueryResponse> Handle(GeneralArticleGetSingleByLanguageCodeQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(lang => lang.IsActive == true && lang.Code == request.LanguageCode, false);

            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");
            Domain.Entities.PartCategory partCategory = await _partCategoryReadRepository.GetSingleAsync(part => part.Name == "Genel Yazı");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(part => part.IsActive == true && part.CvInformation.LanguageId == language.Id && part.PartCategoryId == partCategory.Id, false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            Domain.Entities.GeneralArticle generalArticle = await _generalArticleReadRepository.GetSingleAsync(article => article.IsActive == true && article.CvPartId == cvPart.Id, false);

            return new()
            {
                Article = generalArticle != null ? generalArticle.Article : null,
                IconName = cvPart.IconName,
                IconPath = cvPart.IconPath,
                Name = cvPart.Name
            };

        }
    }
}
