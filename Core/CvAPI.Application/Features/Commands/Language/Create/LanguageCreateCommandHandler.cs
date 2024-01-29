using CvAPI.Application.Abstractions.Storage;
using CvAPI.Application.Repositories.LanguageRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Language.Create
{
    public class LanguageCreateCommandHandler : IRequestHandler<LanguageCreateCommandRequest, LanguageCreateCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly ILanguageWriteRepository _languageWriteRepository;
        private readonly ILanguageReadRepository _languageReadRepository;
        public LanguageCreateCommandHandler(IStorageService storageService, ILanguageWriteRepository languageWriteRepository, ILanguageReadRepository languageReadRepository)
        {
            _storageService = storageService;
            _languageWriteRepository = languageWriteRepository;
            _languageReadRepository = languageReadRepository;
        }
        public async Task<LanguageCreateCommandResponse> Handle(LanguageCreateCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(language => language.Code == request.Code && language.IsActive == true, false);

            if (language != null)
                throw new BadRequestException("Böyle Bir Kayıt zaten Mevcut");

            (string fileName, string path) image=new();
            if (request.Image != null)
            {
                image= await _storageService.UploadSingleAsync("images\\languages", request.Image);
            }

            bool result = await _languageWriteRepository.AddAsync(new()
            {
                Code = request.Code,
                Name = request.Name,
                FlagFileName = image.fileName != null ? image.fileName : null,
                FlagPath = image.path != null ? image.path : null
            });
            await _languageWriteRepository.SaveAsync();

            if (!result)
                throw new BadRequestException("Bir Hatayla Karşılaşıldı Lütfen Daha Sonra Tekrar Deneyiniz");

            return new() { };
            
        }
    }
}
