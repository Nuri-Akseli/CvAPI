using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Hobby.GetSingle
{
    public class HobbyGetSingleQueryRequest:IRequest<HobbyGetSingleQueryResponse>
    {
        public int Id { get; set; }
    }
}
