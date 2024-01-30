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

namespace CvAPI.Application.Features.Commands.CvInformation.Create
{
    public class CvInformationCreateCommandHandler : IRequestHandler<CvInformationCreateCommandRequest, CvInformationCreateCommandResponse>
    {
        private readonly ICvInformationWriteRepository _cvInformationWriteRepository;
        private readonly ICvInformationReadRepository _cvInformationReadRepository;
        private readonly IStorageService _storageService;
        private readonly ILanguageReadRepository _languageReadRepository;

        public CvInformationCreateCommandHandler(
            ICvInformationWriteRepository cvInformationWriteRepository,
            ICvInformationReadRepository cvInformationReadRepository,
            IStorageService storageService,
            ILanguageReadRepository languageReadRepository)
        {
            _cvInformationReadRepository= cvInformationReadRepository;
            _cvInformationWriteRepository= cvInformationWriteRepository;
            _storageService= storageService;
            _languageReadRepository= languageReadRepository;
        }
        public async Task<CvInformationCreateCommandResponse> Handle(CvInformationCreateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(language => language.Id == request.LanguageId, false);
            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");

            Domain.Entities.CvInformation cvInfo = await _cvInformationReadRepository.GetSingleAsync(info => info.LanguageId == request.LanguageId, false);
            if(cvInfo!=null)
                throw new BadRequestException("Bu Dilde Cv Mevcut");

            (string fileName, string path) image = new();
            if (request.Image!=null)
                image =await _storageService.UploadSingleAsync("images\\avatars",request.Image);

            bool result = await _cvInformationWriteRepository.AddAsync(new()
            {
                CvName=request.CvName,
                NameSurname=request.NameSurname,
                LanguageId=request.LanguageId,
                ImageName=image.fileName!=null?image.fileName:null,
                ImagePath=image.path!=null?image.path:null
            });

            await _cvInformationWriteRepository.SaveAsync();

            if (!result)
                throw new BadRequestException("Bir Hata ile Karşılaşıldı Daha Sonra Tekrar Deneyiniz");

            return new() { };
        }
    }
}
