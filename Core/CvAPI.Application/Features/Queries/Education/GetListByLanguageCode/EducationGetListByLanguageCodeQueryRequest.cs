using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Education.GetListByLanguageCode
{
    public class EducationGetListByLanguageCodeQueryRequest:IRequest<EducationGetListByLanguageCodeQueryResponse>
    {
        public string LanguageCode { get; set; }
    }
}
