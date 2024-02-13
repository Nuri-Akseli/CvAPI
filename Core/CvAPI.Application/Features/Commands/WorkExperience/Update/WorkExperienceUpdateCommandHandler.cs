using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.WorkExperienceRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.WorkExperience.Update
{
    public class WorkExperienceUpdateCommandHandler:IRequestHandler<WorkExperienceUpdateCommandRequest, WorkExperienceUpdateCommandResponse>
    {
        private readonly IWorkExperienceReadRepositoy _workExperienceReadRepositoy;
        private readonly IWorkExperienceWriteRepository _workExperienceWriteRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        public WorkExperienceUpdateCommandHandler(IWorkExperienceReadRepositoy workExperienceReadRepositoy,IWorkExperienceWriteRepository workExperienceWriteRepository,ICvPartReadRepository cvPartReadRepository)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _workExperienceReadRepositoy= workExperienceReadRepositoy;
            _workExperienceWriteRepository= workExperienceWriteRepository;

        }

        public async Task<WorkExperienceUpdateCommandResponse> Handle(WorkExperienceUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            Domain.Entities.WorkExperience workExperience = await _workExperienceReadRepositoy.GetByIdAsync(request.Id, false);
            if (workExperience == null)
                throw new BadRequestException("İş Tecrübesi Bulunamadı");

            workExperience.StartDate = request.StartDate;
            workExperience.EndDate = request.EndDate;
            workExperience.ShortDescription = request.ShortDescription;
            workExperience.CvPartId = request.CvPartId;
            workExperience.City = request.City;
            workExperience.Company = request.Company;
            workExperience.Order= request.Order;
            workExperience.Title = request.Title;

            bool result = _workExperienceWriteRepository.Update(workExperience);
            await _workExperienceWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sorna Tekrar Deneyiniz");
        }
    }
}
