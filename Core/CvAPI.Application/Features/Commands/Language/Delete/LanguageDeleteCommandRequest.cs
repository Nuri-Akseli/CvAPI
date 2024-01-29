using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Language.Delete
{
    public class LanguageDeleteCommandRequest:IRequest<LanguageDeleteCommandResponse>
    {
        public int? Id { get; set; }
    }
}
