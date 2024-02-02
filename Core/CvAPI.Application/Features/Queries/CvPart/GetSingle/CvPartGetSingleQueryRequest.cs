using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvPart.GetSingle
{
    public class CvPartGetSingleQueryRequest:IRequest<CvPartGetSingleQueryResponse>
    {
        public int Id { get; set; }
    }
}
