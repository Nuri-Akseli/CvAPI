using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Skill.GetSingle
{
    public class SkillGetSingleQueryRequest:IRequest<SkillGetSingleQueryResponse>
    {
        public int Id { get; set; }
    }
}
