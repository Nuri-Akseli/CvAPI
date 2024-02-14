using CvAPI.Application.Repositories.HobbyRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Hobby.GetAll
{
    public class HobbyGetAllQueryHandler:IRequestHandler<HobbyGetAllQueryRequest,HobbyGetAllQueryResponse>
    {
        private readonly IHobbyReadRepository _hobbyReadRepository;
        public HobbyGetAllQueryHandler(IHobbyReadRepository hobbyReadRepository)
        {
            _hobbyReadRepository= hobbyReadRepository;
        }

        public async Task<HobbyGetAllQueryResponse> Handle(HobbyGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Hobby> hobbies = _hobbyReadRepository.GetAll(false).ToList();

            return new()
            {
                Hobbies = hobbies
            };
        }
    }
}
