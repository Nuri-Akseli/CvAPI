using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.WorkExperience.Delete
{
    public class WorkExperienceDeleteCommandRequest:IRequest<WorkExperienceDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}
