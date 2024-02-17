using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.WorkExperience.GetListByLanguageCode
{
    public class WorkExperienceGetListByLanguageCodeQueryRequest:IRequest<WorkExperienceGetListByLanguageCodeQueryResponse>
    {
        public string LanguageCode { get; set; }
    }
}
