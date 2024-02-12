using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.SkillRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Skill.Update
{
    public class SkillUpdateCommandHandler:IRequestHandler<SkillUpdateCommandRequest,SkillUpdateCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly ISkillReadRepository _skillReadRepository;
        private readonly ISkillWriteRepository _skillWriteRepository;
        public SkillUpdateCommandHandler(ICvPartReadRepository cvPartReadRepository,ISkillReadRepository skillReadRepository,ISkillWriteRepository skillWriteRepository)
        {
            _cvPartReadRepository=cvPartReadRepository;
            _skillReadRepository=skillReadRepository;
            _skillWriteRepository=skillWriteRepository;
        }

        public async Task<SkillUpdateCommandResponse> Handle(SkillUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId,false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            Domain.Entities.Skill skill = await _skillReadRepository.GetByIdAsync(request.Id, false);

            if (skill == null)
                throw new BadRequestException("Beceri Bulunamadı");

            skill.CvPartId = request.CvPartId;
            skill.Order = request.Order;
            skill.Name = request.Name;
            skill.Ratio = request.Ratio;

            bool result = _skillWriteRepository.Update(skill);
            await _skillWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sorna Tekrar Deneyiniz");
        }
    }
}
