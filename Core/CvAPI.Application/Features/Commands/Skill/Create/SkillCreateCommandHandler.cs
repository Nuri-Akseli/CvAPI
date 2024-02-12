using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.SkillRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Skill.Create
{
    public class SkillCreateCommandHandler:IRequestHandler<SkillCreateCommandRequest, SkillCreateCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly ISkillWriteRepository _skillWriteRepository;
        public SkillCreateCommandHandler(ICvPartReadRepository cvPartReadRepository,ISkillWriteRepository skillWriteRepository)
        {
            _cvPartReadRepository= cvPartReadRepository;
            _skillWriteRepository= skillWriteRepository;
        }

        public async Task<SkillCreateCommandResponse> Handle(SkillCreateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            bool result = await _skillWriteRepository.AddAsync(new()
            {
                CvPartId = request.CvPartId,
                Name = request.Name,
                Order = request.Order,
                Ratio = request.Ratio
            });
            await _skillWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
