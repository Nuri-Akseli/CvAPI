using CvAPI.Application.Repositories.CvInformationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvInformation.GetSingle
{
    public class CvInformationGetSingleQueryHandler:IRequestHandler<CvInformationGetSingleQueryRequest,CvInformationGetSingleQueryResponse>
    {
        private readonly ICvInformationReadRepository _cvInformationReadRepository;
        public CvInformationGetSingleQueryHandler(ICvInformationReadRepository cvInformationReadRepository)
        {
            _cvInformationReadRepository = cvInformationReadRepository;
        }

        public async Task<CvInformationGetSingleQueryResponse> Handle(CvInformationGetSingleQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvInformation cvInfo = await _cvInformationReadRepository.GetSingleAsync(info => info.Id == request.Id,false);

            if (cvInfo == null)
                throw new BadRequestException("Cv Bilgisi Bulunamadı");

            return new()
            {
                CvName=cvInfo.CvName,
                Id=cvInfo.Id,
                NameSurname=cvInfo.NameSurname,
                ImageName = cvInfo.ImageName,
                ImagePath = cvInfo.ImagePath,
                LanguageId = cvInfo.LanguageId
            };
        }
    }
}
