using CvAPI.Application.Repositories.SocialMediaRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.SocialMedia.UpdateActivity
{
    public class SocialMediaUpdateActivityCommandHandler:IRequestHandler<SocialMediaUpdateActivityCommandRequest, SocialMediaUpdateActivityCommandResponse>
    {
        private readonly ISocialMediaReadRepository _socialMediaReadRepository;
        private readonly ISocialMediaWriteRepository _socialMediaWriteRepository;

        public SocialMediaUpdateActivityCommandHandler(ISocialMediaReadRepository socialMediaReadRepository,ISocialMediaWriteRepository socialMediaWriteRepository)
        {
            _socialMediaReadRepository=socialMediaReadRepository;
            _socialMediaWriteRepository=socialMediaWriteRepository;

        }

        public async Task<SocialMediaUpdateActivityCommandResponse> Handle(SocialMediaUpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.SocialMedia socialMedia = await _socialMediaReadRepository.GetByIdAsync(request.Id, false);

            if (socialMedia == null)
                throw new BadRequestException("Sosyal Medya Bulunamadı");

            socialMedia.IsActive = request.IsActive;

            bool result = _socialMediaWriteRepository.Update(socialMedia);
            await _socialMediaWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
