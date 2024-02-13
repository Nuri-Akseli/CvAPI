using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.WorkExperienceRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.WorkExperience.Create
{
    public class WorkExperienceCreateCommandHandler : IRequestHandler<WorkExperienceCreateCommandRequest, WorkExperienceCreateCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IWorkExperienceWriteRepository _workExperienceWriteRepository;
        public WorkExperienceCreateCommandHandler(ICvPartReadRepository cvPartReadRepository,IWorkExperienceWriteRepository workExperienceWriteRepository)
        {
            _cvPartReadRepository=cvPartReadRepository;
            _workExperienceWriteRepository=workExperienceWriteRepository;

        }
        public async Task<WorkExperienceCreateCommandResponse> Handle(WorkExperienceCreateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            bool result = await _workExperienceWriteRepository.AddAsync(new()
            {
                City = request.City,
                Company = request.Company,
                CvPartId = request.CvPartId,
                EndDate = request.EndDate,
                Order = request.Order,
                ShortDescription = request.ShortDescription,
                StartDate = request.StartDate,
                Title = request.Title
            });
            await _workExperienceWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
