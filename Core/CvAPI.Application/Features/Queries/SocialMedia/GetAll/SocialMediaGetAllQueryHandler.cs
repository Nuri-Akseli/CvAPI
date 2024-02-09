using CvAPI.Application.Repositories.SocialMediaRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.SocialMedia.GetAll
{
    public class SocialMediaGetAllQueryHandler:IRequestHandler<SocialMediaGetAllQueryRequest,SocialMediaGetAllQueryResponse>
    {
        private readonly ISocialMediaReadRepository _socialMediaReadRepository;
        public SocialMediaGetAllQueryHandler(ISocialMediaReadRepository socialMediaReadRepository)
        {
            _socialMediaReadRepository= socialMediaReadRepository;
        }

        public async Task<SocialMediaGetAllQueryResponse> Handle(SocialMediaGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.SocialMedia> socialMedias = _socialMediaReadRepository.GetAll(false).ToList();
            return new()
            {
                SocialMedias = socialMedias,
            };
        }
    }
}
