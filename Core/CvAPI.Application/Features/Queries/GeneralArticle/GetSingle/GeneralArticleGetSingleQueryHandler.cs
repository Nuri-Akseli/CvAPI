using CvAPI.Application.Repositories.GeneralArticleRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.GeneralArticle.GetSingle
{
    public class GeneralArticleGetSingleQueryHandler : IRequestHandler<GeneralArticleGetSingleQueryRequest, GeneralArticleGetSingleQueryResponse>
    {
        private readonly IGeneralArticleReadRepository _generalArticleReadRepository;
        public GeneralArticleGetSingleQueryHandler(IGeneralArticleReadRepository generalArticleReadRepository)
        {
            _generalArticleReadRepository= generalArticleReadRepository;
        }
        public async Task<GeneralArticleGetSingleQueryResponse> Handle(GeneralArticleGetSingleQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.GeneralArticle article =await _generalArticleReadRepository.GetByIdAsync(request.Id);

            if (article == null)
                throw new BadRequestException("Yazı Bulunamadı");

            return new()
            {
                Article = article.Article,
                CvPartId = article.CvPartId,
                Id = article.Id,
                IsActive = article.IsActive
            };
        }
    }
}
