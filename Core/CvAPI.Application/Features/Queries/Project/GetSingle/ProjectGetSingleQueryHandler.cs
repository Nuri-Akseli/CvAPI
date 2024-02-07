using CvAPI.Application.Repositories.ProjectRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Project.GetSingle
{
    public class ProjectGetSingleQueryHandler:IRequestHandler<ProjectGetSingleQueryRequest, ProjectGetSingleQueryResponse>
    {
        private readonly IProjectReadRepository _projectReadRepository;
        public ProjectGetSingleQueryHandler(IProjectReadRepository projectReadRepository)
        {
            _projectReadRepository = projectReadRepository;
        }

        public async Task<ProjectGetSingleQueryResponse> Handle(ProjectGetSingleQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Project project = await _projectReadRepository.GetByIdAsync(request.Id, false);

            if (project == null)
                throw new BadRequestException("Proje Bulunamadı");

            return new()
            {
                Id = project.Id,
                CvPartId = project.CvPartId,
                Link = project.Link,
                Name = project.Name,
                Order = project.Order,
                ShortDescription = project.ShortDescription
            };
        }
    }
}
