using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Language.UpdateActivity
{
    public class LanguageUpdateActivityCommandRequest:IRequest<LanguageUpdateActivityCommandResponse>
    {
        public int? Id { get; set; }
        public bool Activity { get; set; } = false;
    }
}
