using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.SocialMedia.Create
{
    public class SocialMediaCreateCommandRequest:IRequest<SocialMediaCreateCommandResponse>
    {
        public int CvPartId { get; set; }
        public string? Url { get; set; }
        public IFormFile? Icon { get; set; }
        public int Order { get; set; }
    }
}
