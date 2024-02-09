using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.SocialMedia.Delete
{
    public class SocialMediaDeleteCommandRequest:IRequest<SocialMediaDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}
