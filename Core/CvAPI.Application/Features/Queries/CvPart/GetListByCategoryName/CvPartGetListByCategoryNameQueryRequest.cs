using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvPart.GetListByCategoryName
{
    public class CvPartGetListByCategoryNameQueryRequest:IRequest<CvPartGetListByCategoryNameQueryResponse>
    {
        public string CategoryName { get; set; }
    }
}
