using CvAPI.Application.Repositories.CvPartRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvPart.GetAll
{
    public class CvPartGetAllQueryHandler:IRequestHandler<CvPartGetAllQueryRequest, CvPartGetAllQueryResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        public CvPartGetAllQueryHandler(ICvPartReadRepository cvPartReadRepository)
        {
            _cvPartReadRepository  = cvPartReadRepository;
        }

        public async Task<CvPartGetAllQueryResponse> Handle(CvPartGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.CvPart> cvParts =_cvPartReadRepository.GetAll(false).OrderBy(cvPart=>cvPart.Order).ToList();

            return new()
            {
                CvParts=cvParts
            };
        }
    }
}
