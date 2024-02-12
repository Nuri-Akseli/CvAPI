using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Skill.UpdateActivity
{
    public class SkillUpdateActivityCommandRequest:IRequest<SkillUpdateActivityCommandResponse>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
