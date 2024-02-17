using CvAPI.Application.Repositories.CvInformationRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvInformation.GetSingleByLanguageCode
{
    public class CvInformationGetSingleByLanguageCodeQueryHandler:IRequestHandler<CvInformationGetSingleByLanguageCodeQueryRequest,CvInformationGetSingleByLanguageCodeQueryResponse>
    {
        private readonly ICvInformationReadRepository _cvInformationReadRepository;
        private readonly ILanguageReadRepository _languageReadRepository;
        public CvInformationGetSingleByLanguageCodeQueryHandler(ICvInformationReadRepository cvInformationReadRepository,ILanguageReadRepository languageReadRepository)
        {
            _cvInformationReadRepository = cvInformationReadRepository;
            _languageReadRepository = languageReadRepository;

        }

        public async Task<CvInformationGetSingleByLanguageCodeQueryResponse> Handle(CvInformationGetSingleByLanguageCodeQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(lang => lang.IsActive == true && lang.Code == request.LanguageCode,false);

            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");

            Domain.Entities.CvInformation cvInfo = await _cvInformationReadRepository.GetSingleAsync(cv=>cv.IsActive==true && cv.LanguageId==language.Id,false);

            if (cvInfo == null)
                throw new BadRequestException("Cv bilgisi Bulunamadı");

            return new()
            {
                ImageName = cvInfo.ImageName,
                ImagePath = cvInfo.ImagePath,
                NameSurname = cvInfo.NameSurname
            };
        }
    }
}
