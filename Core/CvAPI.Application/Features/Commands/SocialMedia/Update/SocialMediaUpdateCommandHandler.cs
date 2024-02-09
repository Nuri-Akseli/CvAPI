using CvAPI.Application.Abstractions.Storage;
using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.SocialMediaRepositories;
using CvAPI.Domain.Entities;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.SocialMedia.Update
{
    public class SocialMediaUpdateCommandHandler:IRequestHandler<SocialMediaUpdateCommandRequest, SocialMediaUpdateCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly ISocialMediaReadRepository _socialMediaReadRepository;
        private readonly ISocialMediaWriteRepository _socialMediaWriteRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        public SocialMediaUpdateCommandHandler(IStorageService storageService,ISocialMediaReadRepository socialMediaReadRepository,ISocialMediaWriteRepository socialMediaWriteRepository, ICvPartReadRepository cvPartReadRepository)
        {
            _storageService = storageService;
            _socialMediaReadRepository= socialMediaReadRepository;
            _socialMediaWriteRepository= socialMediaWriteRepository;
            _cvPartReadRepository= cvPartReadRepository;
        }

        public async Task<SocialMediaUpdateCommandResponse> Handle(SocialMediaUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.SocialMedia socialMedia = await _socialMediaReadRepository.GetByIdAsync(request.Id, false);

            if (socialMedia == null)
                throw new BadRequestException("Sosyal Medya Bulunamadı");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId,false);

            if(cvPart==null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            (string fileName, string path) icon = new();
            if (request.Icon != null)
            {
                if (socialMedia.IconName != null)
                    _storageService.Delete(socialMedia.IconPath, socialMedia.IconName);
                icon = await _storageService.UploadSingleAsync("images\\socialmedias", request.Icon);
                socialMedia.IconName = icon.fileName;
                socialMedia.IconPath = icon.path;
            }
            socialMedia.CvPartId=request.CvPartId;
            socialMedia.Url = request.Url;
            socialMedia.Order = request.Order;

            bool result = _socialMediaWriteRepository.Update(socialMedia);
            await _socialMediaWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
