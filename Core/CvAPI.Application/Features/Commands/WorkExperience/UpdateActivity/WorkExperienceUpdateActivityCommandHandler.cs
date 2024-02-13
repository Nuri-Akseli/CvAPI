using CvAPI.Application.Repositories.WorkExperienceRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.WorkExperience.UpdateActivity
{
    public class WorkExperienceUpdateActivityCommandHandler:IRequestHandler<WorkExperienceUpdateActivityCommandRequest, WorkExperienceUpdateActivityCommandResponse>
    {
        private readonly IWorkExperienceReadRepositoy _workExperienceReadRepositoy;
        private readonly IWorkExperienceWriteRepository _workExperienceWriteRepository;

        public WorkExperienceUpdateActivityCommandHandler(IWorkExperienceReadRepositoy workExperienceReadRepositoy,IWorkExperienceWriteRepository workExperienceWriteRepository)
        {
            _workExperienceReadRepositoy= workExperienceReadRepositoy;
            _workExperienceWriteRepository=workExperienceWriteRepository;
        }

        public async Task<WorkExperienceUpdateActivityCommandResponse> Handle(WorkExperienceUpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.WorkExperience workExperience = await _workExperienceReadRepositoy.GetByIdAsync(request.Id,false);

            if (workExperience == null)
                throw new BadRequestException("İş Tecrübesi Bulunamadı");

            workExperience.IsActive = request.IsActive;

            bool result= _workExperienceWriteRepository.Update(workExperience);
            await _workExperienceWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sorna Tekrar Deneyiniz");
        }
    }
}
