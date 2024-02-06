using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Education.UpdateActivity
{
    public class EducationUpdateActivityCommandRequest:IRequest<EducationUpdateActivityCommandResponse>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
