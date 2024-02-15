using CvAPI.Application.Repositories.PersonalnformationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.PersonalInformation.GetSingle
{
    public class PersonalInformationGetSingleQueryHandler:IRequestHandler<PersonalInformationGetSingleQueryRequest, PersonalInformationGetSingleQueryResponse>
    {
        private readonly IPersonalInformationReadRespository _personalInformationReadRespository;

        public PersonalInformationGetSingleQueryHandler(IPersonalInformationReadRespository personalInformationReadRespository)
        {
            _personalInformationReadRespository= personalInformationReadRespository;
        }

        public async Task<PersonalInformationGetSingleQueryResponse> Handle(PersonalInformationGetSingleQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.PersonalInformation personalInformation = await _personalInformationReadRespository.GetByIdAsync(request.Id, false);

            if (personalInformation == null)
                throw new BadRequestException("Kişisel Bilgi Bulunamadı");

            return new()
            {
                CvPartId = personalInformation.CvPartId,
                IconName = personalInformation.IconName,
                IconPath = personalInformation.IconPath,
                Name = personalInformation.Name,
                Order = personalInformation.Order
            };
        }
    }
}
