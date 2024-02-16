using CvAPI.Application.Repositories.PartCategoryRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.PartCategory.GetAll
{
    public class PartCategoryGetAllQueryHandler:IRequestHandler<PartCategoryGetAllQueryRequest,PartCategoryGetAllQueryResponse>
    {
        private readonly IPartCategoryReadRepository _partCategoryReadRepository;
        public PartCategoryGetAllQueryHandler(IPartCategoryReadRepository partCategoryReadRepository)
        {
            _partCategoryReadRepository= partCategoryReadRepository;
        }

        public async Task<PartCategoryGetAllQueryResponse> Handle(PartCategoryGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.PartCategory> partCategories = _partCategoryReadRepository.GetAll(false).ToList();
            return new()
            {
                PartCategories = partCategories,
            };
        }
    }
}
