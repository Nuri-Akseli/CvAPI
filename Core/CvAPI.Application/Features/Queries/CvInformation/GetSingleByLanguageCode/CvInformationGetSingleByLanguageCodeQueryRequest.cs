using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvInformation.GetSingleByLanguageCode
{
    public class CvInformationGetSingleByLanguageCodeQueryRequest:IRequest<CvInformationGetSingleByLanguageCodeQueryResponse>
    {
        public string LanguageCode { get; set; }
    }
}
