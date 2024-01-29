using CvAPI.Application.Repositories.LanguageRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Language.GetSingleById
{
    public class LanguageGetSingleByIdQueryHandler : IRequestHandler<LanguageGetSingleByIdQueryRequest, LanguageGetSingleByIdQueryResponse>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        public LanguageGetSingleByIdQueryHandler(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;
        }
        public async Task<LanguageGetSingleByIdQueryResponse> Handle(LanguageGetSingleByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var language = await _languageReadRepository.GetSingleAsync(lang => lang.Id == request.Id,false);
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
