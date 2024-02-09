using CvAPI.Application.Repositories.SocialMediaRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.SocialMedia.GetSingle
{
    public class SocialMediaGetSingleQueryHandler:IRequestHandler<SocialMediaGetSingleQueryRequest,SocialMediaGetSingleQueryResponse>
    {
        private readonly ISocialMediaReadRepository _socialMediaReadRepository;
        public SocialMediaGetSingleQueryHandler(ISocialMediaReadRepository socialMediaReadRepository)
        {
            _socialMediaReadRepository= socialMediaReadRepository;
        }

        public async Task<SocialMediaGetSingleQueryResponse> Handle(SocialMediaGetSingleQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.SocialMedia socialMedia = await _socialMediaReadRepository.GetByIdAsync(request.Id, false);

            if (socialMedia == null)
                throw new BadRequestException("Sosyal MEdya Bulunamadı");

            return new()
            {
                Id = socialMedia.Id,
                CvPartId = socialMedia.CvPartId,
                IconName = socialMedia.IconName,
                IconPath = socialMedia.IconPath,
                IsActive = socialMedia.IsActive,
                Order = socialMedia.Order,
                Url = socialMedia.Url
            };
        }
    }
}
