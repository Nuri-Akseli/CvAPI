using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.GeneralArticle.Create
{
    public class GeneralArticleCreateCommandRequest:IRequest<GeneralArticleCreateCommandResponse>
    {
        public int CvPartId { get; set; }
        public string? Article { get; set; }
    }
}
