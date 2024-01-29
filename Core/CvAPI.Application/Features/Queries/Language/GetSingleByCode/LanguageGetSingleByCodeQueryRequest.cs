using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Language.GetSingleByCode
{
    public class LanguageGetSingleByCodeQueryRequest:IRequest<LanguageGetSingleByCodeQueryResponse>
    {
        public string? Code { get; set; }
    }
}
