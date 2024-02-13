using CvAPI.Application.Repositories.WorkExperienceRepositories;
using MediatR;
using Microsoft.VisualBasic;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.WorkExperience.GetSingle
{
    public class WorkExperienceGetSingleQueryHandler:IRequestHandler<WorkExperienceGetSingleQueryRequest, WorkExperienceGetSingleQueryResponse>
    {
        private readonly IWorkExperienceReadRepositoy _workExperienceReadRepositoy;

        public WorkExperienceGetSingleQueryHandler(IWorkExperienceReadRepositoy workExperienceReadRepositoy)
        {
            _workExperienceReadRepositoy=workExperienceReadRepositoy;
        }

        public async Task<WorkExperienceGetSingleQueryResponse> Handle(WorkExperienceGetSingleQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.WorkExperience workExperience = await _workExperienceReadRepositoy.GetByIdAsync(request.Id, false);
            if (workExperience == null)
                throw new BadRequestException("İş Tecrübesi Bulunamadı");
            return new()
            {
                Id = workExperience.Id,
                City = workExperience.City,
                Company = workExperience.Company,
                CvPartId = workExperience.CvPartId,
                EndDate = workExperience.EndDate?.ToString("yyyy-MM-dd"),
                IsActive = workExperience.IsActive,
                Order = workExperience.Order,
                ShortDescription = workExperience.ShortDescription,
                StartDate = workExperience.StartDate.ToString("yyyy-MM-dd"),
                Title = workExperience.Title

            };
        }
    }
}
