using CvAPI.Application.Repositories.CvPartRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvPart.GetListByCategoryName
{
    public class CvPartGetListByCategoryNameQueryHandler:IRequestHandler<CvPartGetListByCategoryNameQueryRequest,CvPartGetListByCategoryNameQueryResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        public CvPartGetListByCategoryNameQueryHandler(ICvPartReadRepository cvPartReadRepository)
        {
            _cvPartReadRepository=cvPartReadRepository;
        }

        public async Task<CvPartGetListByCategoryNameQueryResponse> Handle(CvPartGetListByCategoryNameQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.CvPart> cvParts = _cvPartReadRepository.GetWhere(cvPart => cvPart.PartCategory.Name == request.CategoryName, false).ToList();

            return new()
            {
                CvParts = cvParts
            };
        }
    }
}
