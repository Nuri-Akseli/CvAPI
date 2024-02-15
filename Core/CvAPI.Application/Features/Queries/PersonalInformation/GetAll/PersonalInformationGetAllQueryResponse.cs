using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.PersonalInformation.GetAll
{
    public class PersonalInformationGetAllQueryResponse
    {
        public List<Domain.Entities.PersonalInformation> PersonalInformations { get; set; }
    }
}
