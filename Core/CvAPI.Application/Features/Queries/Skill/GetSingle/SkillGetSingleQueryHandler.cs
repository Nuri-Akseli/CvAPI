using CvAPI.Application.Repositories.SkillRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Skill.GetSingle
{
    public class SkillGetSingleQueryHandler:IRequestHandler<SkillGetSingleQueryRequest,SkillGetSingleQueryResponse>
    {
        private readonly ISkillReadRepository _skillReadRepository;
        public SkillGetSingleQueryHandler(ISkillReadRepository skillReadRepository)
        {
            _skillReadRepository= skillReadRepository;
        }

        public async Task<SkillGetSingleQueryResponse> Handle(SkillGetSingleQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Skill skill = await _skillReadRepository.GetByIdAsync(request.Id, false);

            if (skill == null)
                throw new BadRequestException("Beceri Bulunamadı");

            return new()
            {
                Id = skill.Id,
                CvPartId = skill.CvPartId,
                IsActive = skill.IsActive,
                Name = skill.Name,
                Order = skill.Order,
                Ratio = skill.Ratio,
            };

        }
    }
}
