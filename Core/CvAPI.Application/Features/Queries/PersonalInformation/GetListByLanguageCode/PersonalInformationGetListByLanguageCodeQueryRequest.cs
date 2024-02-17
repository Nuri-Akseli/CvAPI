using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.PersonalInformation.GetListByLanguageCode
{
    public class PersonalInformationGetListByLanguageCodeQueryRequest:IRequest<PersonalInformationGetListByLanguageCodeQueryResponse>
    {
        public string LanguageCode { get; set; }
    }
}
