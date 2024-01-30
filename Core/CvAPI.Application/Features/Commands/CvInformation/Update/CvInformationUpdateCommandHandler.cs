using CvAPI.Application.Abstractions.Storage;
using CvAPI.Application.Repositories.CvInformationRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvInformation.Update
{
    public class CvInformationUpdateCommandHandler : IRequestHandler<CvInformationUpdateCommandRequest, CvInformationUpdateCommandResponse>
    {
        private readonly ICvInformationWriteRepository _cvInformationWriteRepository;
        private readonly ICvInformationReadRepository _cvInformationReadRepository;
        private readonly IStorageService _storageService;
        private readonly ILanguageReadRepository _languageReadRepository;
        public CvInformationUpdateCommandHandler(
            ICvInformationWriteRepository cvInformationWriteRepository,
            ICvInformationReadRepository cvInformationReadRepository,
            IStorageService storageService,
            ILanguageReadRepository languageReadRepository)
        {
            _cvInformationReadRepository = cvInformationReadRepository;
            _cvInformationWriteRepository = cvInformationWriteRepository;
            _storageService = storageService;
            _languageReadRepository = languageReadRepository;
        }
        public async Task<CvInformationUpdateCommandResponse> Handle(CvInformationUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(language => language.Id == request.LanguageId, false);
            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");

            Domain.Entities.CvInformation cvInfo = await _cvInformationReadRepository.GetSingleAsync(info => info.Id == request.Id, false);
            if (cvInfo == null)
                throw new BadRequestException("Bu Cv Bilgisi Bulunamadı");


            (string fileName, string path) image = new();
            if (request.Image != null)
            {
                if (cvInfo.ImageName != null)
                    _storageService.Delete(cvInfo.ImagePath, cvInfo.ImageName);
                image = await _storageService.UploadSingleAsync("images\\avatars", request.Image);

                cvInfo.ImagePath = image.path;
                cvInfo.ImageName = image.fileName;
            }

            cvInfo.CvName = request.CvName;
            cvInfo.LanguageId = request.LanguageId;
            cvInfo.NameSurname = request.NameSurname;

            bool result = _cvInformationWriteRepository.Update(cvInfo);
            await _cvInformationWriteRepository.SaveAsync();

            if (!result)
                throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");

            return new() { };


                
        }
    }
}
