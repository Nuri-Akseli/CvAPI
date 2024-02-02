using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvPart.Delete
{
    public class CvPartDeleteCommandRequest:IRequest<CvPartDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}
