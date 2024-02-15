using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.PersonalInformation.GetSingle
{
    public class PersonalInformationGetSingleQueryRequest:IRequest<PersonalInformationGetSingleQueryResponse>
    {
        public int Id { get; set; }
    }
}
