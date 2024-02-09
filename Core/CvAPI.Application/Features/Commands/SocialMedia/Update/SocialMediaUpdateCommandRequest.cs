using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.SocialMedia.Update
{
    public class SocialMediaUpdateCommandRequest:IRequest<SocialMediaUpdateCommandResponse>
    {
        public int Id { get; set; }
        public int CvPartId { get; set; }
        public string? Url { get; set; }
        public IFormFile? Icon { get; set; }
        public int Order { get; set; }
    }
}
