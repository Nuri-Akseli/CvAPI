using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Hobby.Update
{
    public class HobbyUpdateCommandRequest:IRequest<HobbyUpdateCommandResponse>
    {
        public int Id { get; set; }
        public int CvPartId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
