using CvAPI.Application.Repositories.EducationRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Education.GetAll
{
    public class EducationGetAllQueryHandler : IRequestHandler<EducationGetAllQueryRequest, EducationGetAllQueryResponse>
    {
        private readonly IEducationReadRepository _educationReadRepository;
        public EducationGetAllQueryHandler(IEducationReadRepository educationReadRepository)
        {
            _educationReadRepository= educationReadRepository;
        }
        public async Task<EducationGetAllQueryResponse> Handle(EducationGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Education> education = _educationReadRepository.GetAll(false).ToList();
            return new()
            {
                Education = education
            };

        }
    }
}
