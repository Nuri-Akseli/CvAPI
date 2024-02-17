using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.GeneralArticle.GetSingleByLanguageCode
{
    public class GeneralArticleGetSingleByLanguageCodeQueryRequest:IRequest<GeneralArticleGetSingleByLanguageCodeQueryResponse>
    {
        public string LanguageCode { get; set; }
    }
}
