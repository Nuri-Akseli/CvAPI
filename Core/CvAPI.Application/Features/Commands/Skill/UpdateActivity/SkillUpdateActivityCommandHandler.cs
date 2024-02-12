using CvAPI.Application.Repositories.SkillRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Skill.UpdateActivity
{
    public class SkillUpdateActivityCommandHandler:IRequestHandler<SkillUpdateActivityCommandRequest, SkillUpdateActivityCommandResponse>
    {
        private readonly ISkillReadRepository _skillReadRepository;
        private readonly ISkillWriteRepository _skillWriteRepository;
        public SkillUpdateActivityCommandHandler(ISkillReadRepository skillReadRepository,ISkillWriteRepository skillWriteRepository)
        {
            _skillReadRepository = skillReadRepository;
            _skillWriteRepository = skillWriteRepository;
        }

        public async Task<SkillUpdateActivityCommandResponse> Handle(SkillUpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Skill skill = await _skillReadRepository.GetByIdAsync(request.Id, false);

            if (skill == null)
                throw new BadRequestException("Beceri Bulunamadı");

            skill.IsActive = request.IsActive;

            bool result = _skillWriteRepository.Update(skill);
            await _skillWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
