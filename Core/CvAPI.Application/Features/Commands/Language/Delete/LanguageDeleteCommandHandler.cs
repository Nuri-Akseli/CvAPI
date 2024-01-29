using CvAPI.Application.Abstractions.Storage;
using CvAPI.Application.Repositories.LanguageRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Language.Delete
{
    public class LanguageDeleteCommandHandler : IRequestHandler<LanguageDeleteCommandRequest, LanguageDeleteCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly ILanguageWriteRepository _languageWriteRepository;
        private readonly ILanguageReadRepository _languageReadRepository;
        public LanguageDeleteCommandHandler(IStorageService storageService, ILanguageWriteRepository languageWriteRepository, ILanguageReadRepository languageReadRepository)
        {
            _storageService = storageService;
            _languageWriteRepository = languageWriteRepository;
            _languageReadRepository = languageReadRepository;
        }
        public async Task<LanguageDeleteCommandResponse> Handle(LanguageDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language =await _languageReadRepository.GetSingleAsync(lang=>lang.Id==request.Id);

            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");

            if (language.FlagFileName != null)
                _storageService.Delete(language.FlagPath, language.FlagFileName);

            bool result=_languageWriteRepository.Remove(language);
            await _languageWriteRepository.SaveAsync();

            if (result)
                return new() { };

            throw new BadRequestException("Bir Hata Oluştu Lüfen Daha Sonra Tekrar Deneyiniz");

        }
    }
}
