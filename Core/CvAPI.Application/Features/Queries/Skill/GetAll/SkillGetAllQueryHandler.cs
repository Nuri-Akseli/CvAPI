using CvAPI.Application.Repositories.SkillRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Skill.GetAll
{
    public class SkillGetAllQueryHandler:IRequestHandler<SkillGetAllQueryRequest,SkillGetAllQueryResponse>
    {
        private readonly ISkillReadRepository _skillReadRepository;
        public SkillGetAllQueryHandler(ISkillReadRepository skillReadRepository)
        {
            _skillReadRepository= skillReadRepository;
        }

        public async Task<SkillGetAllQueryResponse> Handle(SkillGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Skill> skills =_skillReadRepository.GetAll(false).ToList();
            return new()
            {
                Skills = skills
            };
        }
    }
}
