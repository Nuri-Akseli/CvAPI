using CvAPI.Application.Repositories.WorkExperienceRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.WorkExperience.GetAll
{
    public class WorkExperienceGetAllQueryHandler:IRequestHandler<WorkExperienceGetAllQueryRequest,WorkExperienceGetAllQueryResponse>
    {
        private readonly IWorkExperienceReadRepositoy _workExperienceReadRepositoy;
        public WorkExperienceGetAllQueryHandler(IWorkExperienceReadRepositoy workExperienceReadRepositoy)
        {
            _workExperienceReadRepositoy= workExperienceReadRepositoy;
        }

        public async Task<WorkExperienceGetAllQueryResponse> Handle(WorkExperienceGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.WorkExperience> workExperiences = _workExperienceReadRepositoy.GetAll(false).ToList();

            return new()
            {
                WorkExperiences=workExperiences
            };
        }
    }
}
