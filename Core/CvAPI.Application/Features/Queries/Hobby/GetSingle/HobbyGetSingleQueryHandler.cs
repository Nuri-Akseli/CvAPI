using CvAPI.Application.Repositories.HobbyRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Hobby.GetSingle
{
    public class HobbyGetSingleQueryHandler:IRequestHandler<HobbyGetSingleQueryRequest, HobbyGetSingleQueryResponse>
    {
        private readonly IHobbyReadRepository _hobbyReadRepository;
        public HobbyGetSingleQueryHandler(IHobbyReadRepository hobbyReadRepository)
        {
            _hobbyReadRepository = hobbyReadRepository;
        }

        public async Task<HobbyGetSingleQueryResponse> Handle(HobbyGetSingleQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Hobby hobby = await _hobbyReadRepository.GetByIdAsync(request.Id,false);

            if (hobby == null)
                throw new BadRequestException("Hobi Bulunamadı");

            return new()
            {
                CvPartId = hobby.CvPartId,
                Name = hobby.Name,
                Order = hobby.Order
            };
        }
    }
}
