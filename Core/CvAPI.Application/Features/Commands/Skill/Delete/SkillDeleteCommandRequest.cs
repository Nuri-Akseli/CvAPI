using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Skill.Delete
{
    public class SkillDeleteCommandRequest:IRequest<SkillDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}
