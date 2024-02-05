using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.GeneralArticle.Delete
{
    public class GeneralArticleDeleteCommandRequest:IRequest<GeneralArticleDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}
