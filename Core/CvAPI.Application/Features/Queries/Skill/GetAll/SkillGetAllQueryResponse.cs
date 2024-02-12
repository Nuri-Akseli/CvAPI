using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Skill.GetAll
{
    public class SkillGetAllQueryResponse
    {
        public List<Domain.Entities.Skill> Skills { get; set; }
    }
}
