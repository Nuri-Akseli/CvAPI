using CvAPI.Application.Abstractions.Storage;
using CvAPI.Application.Repositories.LanguageRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Language.Update
{
    public class LanguageUpdateCommandHandler : IRequestHandler<LanguageUpdateCommandRequest, LanguageUpdateCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ILanguageWriteRepository _languageWriteRepository;
        public LanguageUpdateCommandHandler(IStorageService storageService, ILanguageReadRepository languageReadRepository, ILanguageWriteRepository languageWriteRepository)
        {
            _storageService = storageService;
            _languageReadRepository = languageReadRepository;
            _languageWriteRepository = languageWriteRepository;
        }
        public async Task<LanguageUpdateCommandResponse> Handle(LanguageUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(lang => lang.Id == request.Id, false);
            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");

            (string fileName, string path) image = new();
            if (request.Image != null)
            {
                if (language.FlagFileName != null)
                    _storageService.Delete(language.FlagPath, language.FlagFileName);
                image= await _storageService.UploadSingleAsync("images\\languages", request.Image);
                language.FlagFileName = image.fileName;
                language.FlagPath = image.path;
            }

            language.Code = request.Code;
            language.Name = request.Name;

            bool result = _languageWriteRepository.Update(language);
            await _languageWriteRepository.SaveAsync();

            if (result)
                return new() { };

            throw new BadRequestException("Bir Hata Oluştu Lütfen Sonra Tekrar Deneyiniz");
        }
    }
}
