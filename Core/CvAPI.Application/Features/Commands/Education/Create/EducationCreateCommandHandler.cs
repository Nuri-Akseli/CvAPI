using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.EducationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Education.Create
{
    public class EducationCreateCommandHandler : IRequestHandler<EducationCreateCommandRequest, EducationCreateCommandResponse>
    {
       
        private readonly IEducationWriteRepository _educationWriteRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        public EducationCreateCommandHandler(
            IEducationWriteRepository educationWriteRepository,
            ICvPartReadRepository cvPartReadRepository)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _educationWriteRepository= educationWriteRepository;

        }
        public async Task<EducationCreateCommandResponse> Handle(EducationCreateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            bool result = await _educationWriteRepository.AddAsync(new()
            {
                Title = request.Title,
                City = request.City,
                CvPartId = request.CvPartId,
                Department = request.Department,
                EndDate = request.EndDate,
                StartDate = request.StartDate,
                Order = request.Order,
                University = request.University
            });
            await _educationWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
