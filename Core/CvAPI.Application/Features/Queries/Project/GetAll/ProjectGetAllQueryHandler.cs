using CvAPI.Application.Repositories.ProjectRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Project.GetAll
{
    public class ProjectGetAllQueryHandler:IRequestHandler<ProjectGetAllQueryRequest,ProjectGetAllQueryResponse>
    {
        private readonly IProjectReadRepository _projectReadRepository;
        public ProjectGetAllQueryHandler(IProjectReadRepository projectReadRepository)
        {
            _projectReadRepository= projectReadRepository;
        }

        public async Task<ProjectGetAllQueryResponse> Handle(ProjectGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Project> projects =_projectReadRepository.GetAll(false).ToList();
            return new()
            {
                Projects = projects
            };
        }
    }
}
