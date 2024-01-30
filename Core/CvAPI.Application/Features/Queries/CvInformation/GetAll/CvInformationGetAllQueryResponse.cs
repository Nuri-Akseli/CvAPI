using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvInformation.GetAll
{
    public class CvInformationGetAllQueryResponse
    {
        public List<Domain.Entities.CvInformation> CvInformations { get; set; }
    }

}
