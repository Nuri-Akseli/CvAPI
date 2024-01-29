using CvAPI.Application.Repositories.LanguageRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Language.GetSingleByCode
{
    public class LanguageGetSingleByCodeQueryHandler : IRequestHandler<LanguageGetSingleByCodeQueryRequest, LanguageGetSingleByCodeQueryResponse>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        public LanguageGetSingleByCodeQueryHandler(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;
        }
        public async Task<LanguageGetSingleByCodeQueryResponse> Handle(LanguageGetSingleByCodeQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(lang => lang.Code == request.Code, false);

            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");

            return new()
            {
                Id = language.Id,
                Code = language.Code,
                FlagFileName = language.FlagFileName,
                FlagPath = language.FlagPath,
                IsActive = language.IsActive,
                Name = language.Name
            };
        }
    }
}
