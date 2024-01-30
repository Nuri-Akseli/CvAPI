using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvInformation.GetSingle
{
    public class CvInformationGetSingleQueryRequest:IRequest<CvInformationGetSingleQueryResponse>
    {
        public int Id { get; set; } = 0;
    }
}
