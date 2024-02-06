using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Education.GetAll
{
    public class EducationGetAllQueryRequest:IRequest<EducationGetAllQueryResponse>
    {
    }
}
