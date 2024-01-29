using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Language.GetSingleById
{
    public class LanguageGetSingleByIdQueryRequest:IRequest<LanguageGetSingleByIdQueryResponse>
    {
        public int? Id { get; set; }
    }
}
