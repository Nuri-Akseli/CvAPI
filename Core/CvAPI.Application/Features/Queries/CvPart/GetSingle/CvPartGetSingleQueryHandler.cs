using CvAPI.Application.Repositories.CvPartRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvPart.GetSingle
{
    public class CvPartGetSingleQueryHandler : IRequestHandler<CvPartGetSingleQueryRequest, CvPartGetSingleQueryResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        public CvPartGetSingleQueryHandler(ICvPartReadRepository cvPartReadRepository)
        {
            _cvPartReadRepository = cvPartReadRepository;
        }
        public async Task<CvPartGetSingleQueryResponse> Handle(CvPartGetSingleQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(cvPart => cvPart.Id == request.Id,false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");
            return new()
            {
                CvInformationId = cvPart.CvInformationId,
                Icon = cvPart.IconPath + cvPart.IconName,
                Id = cvPart.Id,
                IsActive = cvPart.IsActive,
                IsContactInfo = cvPart.IsContactInfo,
                Name = cvPart.Name
            };
        }
    }
}
