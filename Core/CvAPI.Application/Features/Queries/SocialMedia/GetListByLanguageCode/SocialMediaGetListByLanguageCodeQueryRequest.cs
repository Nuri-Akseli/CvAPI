using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.SocialMedia.GetListByLanguageCode
{
    public class SocialMediaGetListByLanguageCodeQueryRequest:IRequest<SocialMediaGetListByLanguageCodeQueryResponse>
    {
        public string LanguageCode { get; set; }
    }
}
