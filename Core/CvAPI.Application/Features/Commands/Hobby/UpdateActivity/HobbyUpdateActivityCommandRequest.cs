using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Hobby.UpdateActivity
{
    public class HobbyUpdateActivityCommandRequest:IRequest<HobbyUpdateActivityCommandResponse>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
