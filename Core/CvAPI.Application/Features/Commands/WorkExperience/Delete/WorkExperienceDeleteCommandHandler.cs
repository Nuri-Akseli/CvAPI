using CvAPI.Application.Repositories.WorkExperienceRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.WorkExperience.Delete
{
    public class WorkExperienceDeleteCommandHandler:IRequestHandler<WorkExperienceDeleteCommandRequest, WorkExperienceDeleteCommandResponse>
    {
        private readonly IWorkExperienceReadRepositoy _workExperienceReadRepositoy;
        private readonly IWorkExperienceWriteRepository _workExperienceWriteRepository;

        public WorkExperienceDeleteCommandHandler(IWorkExperienceReadRepositoy workExperienceReadRepositoy,IWorkExperienceWriteRepository workExperienceWriteRepository)
        {
            _workExperienceReadRepositoy = workExperienceReadRepositoy;
            _workExperienceWriteRepository= workExperienceWriteRepository;

        }

        public async Task<WorkExperienceDeleteCommandResponse> Handle(WorkExperienceDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.WorkExperience workExperience = await _workExperienceReadRepositoy.GetByIdAsync(request.Id, false);

            if (workExperience == null)
                throw new BadRequestException("İş Tecrübesi Bulunamadı");

            bool result = _workExperienceWriteRepository.Remove(workExperience);
            await _workExperienceWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
