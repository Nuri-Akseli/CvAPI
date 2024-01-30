using CvAPI.Application.Repositories.CvInformationRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvInformation.GetAll
{
    public class CvInformationGetAllQueryHandler:IRequestHandler<CvInformationGetAllQueryRequest, CvInformationGetAllQueryResponse>
    {
        private readonly ICvInformationReadRepository _cvInformationReadRepository;
        public CvInformationGetAllQueryHandler(ICvInformationReadRepository cvInformationReadRepository)
        {
            _cvInformationReadRepository = cvInformationReadRepository;
        }

        public async Task<CvInformationGetAllQueryResponse> Handle(CvInformationGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.CvInformation> cvInfos = _cvInformationReadRepository.GetAll(false).Include(l=>l.Language).ToList();
            

            return new()
            {
                CvInformations = cvInfos
            };
        }
    }
}
