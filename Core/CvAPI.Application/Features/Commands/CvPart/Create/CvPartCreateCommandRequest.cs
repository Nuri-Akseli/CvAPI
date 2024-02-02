using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvPart.Create
{
    public class CvPartCreateCommandRequest:IRequest<CvPartCreateCommandResponse>
    {
        public int CvInformationId { get; set; } = 0;
        public string? Name { get; set; }
        public IFormFile? Icon { get; set; }
        public int Order { get; set; } = 0;
        public bool IsContactInfo { get; set; } = false;
    }
}
