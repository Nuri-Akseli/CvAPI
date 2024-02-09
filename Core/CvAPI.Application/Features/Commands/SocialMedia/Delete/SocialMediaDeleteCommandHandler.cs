using CvAPI.Application.Abstractions.Storage;
using CvAPI.Application.Repositories.SocialMediaRepositories;
using CvAPI.Domain.Entities;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.SocialMedia.Delete
{
    public class SocialMediaDeleteCommandHandler:IRequestHandler<SocialMediaDeleteCommandRequest, SocialMediaDeleteCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly ISocialMediaReadRepository _socialMediaReadRepository;
        private readonly ISocialMediaWriteRepository _socialMediaWriteRepository;
        public SocialMediaDeleteCommandHandler(IStorageService storageService,ISocialMediaReadRepository socialMediaReadRepository,ISocialMediaWriteRepository socialMediaWriteRepository)
        {
            _socialMediaReadRepository = socialMediaReadRepository;
            _storageService = storageService;
            _socialMediaWriteRepository = socialMediaWriteRepository;

        }

        public async Task<SocialMediaDeleteCommandResponse> Handle(SocialMediaDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.SocialMedia socialMedia = await _socialMediaReadRepository.GetByIdAsync(request.Id, false);

            if (socialMedia == null)
                throw new BadRequestException("Sosyal Media Bulunamadı");

            if (socialMedia.IconName != null)
                _storageService.Delete(socialMedia.IconPath, socialMedia.IconName);

            bool result = _socialMediaWriteRepository.Remove(socialMedia);
            await _socialMediaWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
