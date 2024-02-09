using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.SocialMedia.GetSingle
{
    public class SocialMediaGetSingleQueryRequest:IRequest<SocialMediaGetSingleQueryResponse>
    {
        public int Id { get; set; }
    }
}
