using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Language.Create
{
    public class LanguageCreateCommandRequest:IRequest<LanguageCreateCommandResponse>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public IFormFile? Image { get; set; }
    }
}
