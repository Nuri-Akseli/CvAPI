using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Language.Update
{
    public class LanguageUpdateCommandRequest:IRequest<LanguageUpdateCommandResponse>
    {
        public int? Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public IFormFile? Image { get; set; }
    }
}
