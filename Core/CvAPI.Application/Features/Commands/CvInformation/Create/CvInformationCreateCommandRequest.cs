using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvInformation.Create
{
    public class CvInformationCreateCommandRequest:IRequest<CvInformationCreateCommandResponse>
    {
        public string? CvName { get; set; }
        public string? NameSurname { get; set; }
        public IFormFile? Image { get; set; }
        public int LanguageId { get; set; } = 0;
    }
}
