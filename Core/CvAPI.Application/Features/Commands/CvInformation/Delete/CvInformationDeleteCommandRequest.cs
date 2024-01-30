using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvInformation.Delete
{
    public class CvInformationDeleteCommandRequest:IRequest<CvInformationDeleteCommandResponse>
    {
        public int Id { get; set; } = 0;

    }
}
