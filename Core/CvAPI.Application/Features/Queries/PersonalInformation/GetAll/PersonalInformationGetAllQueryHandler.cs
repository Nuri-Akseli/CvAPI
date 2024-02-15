using CvAPI.Application.Repositories.PersonalnformationRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.PersonalInformation.GetAll
{
    public class PersonalInformationGetAllQueryHandler:IRequestHandler<PersonalInformationGetAllQueryRequest,PersonalInformationGetAllQueryResponse>
    {
        private readonly IPersonalInformationReadRespository _personalInformationReadRespository;

        public PersonalInformationGetAllQueryHandler(IPersonalInformationReadRespository personalInformationReadRespository)
        {
            _personalInformationReadRespository= personalInformationReadRespository;
        }

        public async Task<PersonalInformationGetAllQueryResponse> Handle(PersonalInformationGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.PersonalInformation> personalInformations = _personalInformationReadRespository.GetAll(false).ToList();

            return new()
            {
                PersonalInformations = personalInformations
            };
        }
    }
}
