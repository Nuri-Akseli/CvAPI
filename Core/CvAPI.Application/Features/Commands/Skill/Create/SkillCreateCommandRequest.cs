using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Skill.Create
{
    public class SkillCreateCommandRequest:IRequest<SkillCreateCommandResponse>
    {
        public int CvPartId { get; set; }
        public string Name { get; set; }
        public int Ratio { get; set; }
        public int Order { get; set; }
    }
}
