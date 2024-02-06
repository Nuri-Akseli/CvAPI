using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.EducationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Education.Update
{
    public class EducationUpdateCommandHandler : IRequestHandler<EducationUpdateCommandRequest, EducationUpdateCommandResponse>
    {
        private readonly IEducationReadRepository _educationReadRepository;
        private readonly IEducationWriteRepository _educationWriteRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        public EducationUpdateCommandHandler(IEducationReadRepository educationReadRepository,IEducationWriteRepository educationWriteRepository,ICvPartReadRepository cvPartReadRepository)
        {
            _cvPartReadRepository=cvPartReadRepository;
            _educationReadRepository=educationReadRepository;
            _educationWriteRepository = educationWriteRepository;

        }
        public async Task<EducationUpdateCommandResponse> Handle(EducationUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.Id,false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            Domain.Entities.Education education = await _educationReadRepository.GetByIdAsync(request.Id, false);

            if (education == null)
                throw new BadRequestException("Eğitim Bulunamadı");

            education.StartDate = DateOnly.Parse(request.StartDate);
            education.EndDate= request.EndDate != null ? DateOnly.Parse(request.EndDate) : null;
            education.CvPartId=request.CvPartId;
            education.Order = request.Order;
            education.City = request.City;
            education.Department = request.Department;
            education.Title = request.Title;
            education.University = request.University;

            bool result = _educationWriteRepository.Update(education);
            await _educationWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
