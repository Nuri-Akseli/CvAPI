using CvAPI.Application.Repositories.EducationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Education.GetSingle
{
    public class EducationGetSingleQueryHandler : IRequestHandler<EducationGetSingleQueryRequest, EducationGetSingleQueryResponse>
    {
        private readonly IEducationReadRepository _educationReadRepository;
        public EducationGetSingleQueryHandler(IEducationReadRepository educationReadRepository)
        {
            _educationReadRepository=educationReadRepository;
        }
        public async Task<EducationGetSingleQueryResponse> Handle(EducationGetSingleQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Education education = await _educationReadRepository.GetByIdAsync(request.Id, false);
            if (education == null)
                throw new BadRequestException("Eğitim Bulunamadı");

            return new()
            {
                Id = education.Id,
                City = education.City,
                Department = education.Department,
                EndDate = education.EndDate,
                IsActive = education.IsActive,
                CvPartId = education.CvPartId,
                Order = education.Order,
                StartDate = education.StartDate,
                Title = education.Title,
                University = education.University
            };
        }
    }
}
