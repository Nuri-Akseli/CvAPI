using CvAPI.Application.Repositories.GeneralArticleRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.GeneralArticle.GetAll
{
    public class GeneralArticleGetAllQueryHandler : IRequestHandler<GeneralArticleGetAllQueryRequest, GeneralArticleGetAllQueryResponse>
    {
        private readonly IGeneralArticleReadRepository _generalArticleReadRepository;
        public GeneralArticleGetAllQueryHandler(IGeneralArticleReadRepository generalArticleReadRepository)
        {
            _generalArticleReadRepository = generalArticleReadRepository;
        }
        public async Task<GeneralArticleGetAllQueryResponse> Handle(GeneralArticleGetAllQueryRequest request, CancellationToken cancellationToken)
        {

            List<Domain.Entities.GeneralArticle> articles =_generalArticleReadRepository.GetAll(false).ToList();

            return new()
            {
                GeneralArticles = articles
            };
        }
    }
}
