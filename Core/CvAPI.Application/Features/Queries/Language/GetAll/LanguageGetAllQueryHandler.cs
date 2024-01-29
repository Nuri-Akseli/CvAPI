using CvAPI.Application.Repositories.LanguageRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L = CvAPI.Domain.Entities;

namespace CvAPI.Application.Features.Queries.Language.GetAll
{
    public class LanguageGetAllQueryHandler : IRequestHandler<LanguageGetAllQueryRequest, LanguageGetAllQueryResponse>
    {
        readonly ILanguageReadRepository _languageReadRepository;
        public LanguageGetAllQueryHandler(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;
        }
        public async Task<LanguageGetAllQueryResponse> Handle(LanguageGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<L.Language> data = _languageReadRepository.GetAll(false).ToList();

            return new()
            {
                Languages = data
            };
        }
    }
}
