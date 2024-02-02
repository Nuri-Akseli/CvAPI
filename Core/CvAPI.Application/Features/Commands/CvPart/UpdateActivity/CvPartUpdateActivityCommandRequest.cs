using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvPart.UpdateActivity
{
    public class CvPartUpdateActivityCommandRequest:IRequest<CvPartUpdateActivityCommandResponse>
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; }=false;
    }
}
