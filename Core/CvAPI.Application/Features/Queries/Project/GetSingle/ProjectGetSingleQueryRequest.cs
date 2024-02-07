using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Project.GetSingle
{
    public class ProjectGetSingleQueryRequest:IRequest<ProjectGetSingleQueryResponse>
    {
        public int Id { get; set; }
    }
}
