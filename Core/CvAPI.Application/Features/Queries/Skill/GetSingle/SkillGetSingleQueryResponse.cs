using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Skill.GetSingle
{
    public class SkillGetSingleQueryResponse
    {
        public int Id { get; set; }
        public int CvPartId { get; set; }
        public string Name { get; set; }
        public int Ratio { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
