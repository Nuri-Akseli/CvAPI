using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Skill.GetListByLanguageCode
{
    public class SkillGetListByLanguageCodeQueryRequest:IRequest<SkillGetListByLanguageCodeQueryResponse>
    {
        public string LanguageCode { get; set; }
    }
}
