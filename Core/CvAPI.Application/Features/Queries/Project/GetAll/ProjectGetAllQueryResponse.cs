using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Project.GetAll
{
    public class ProjectGetAllQueryResponse
    {
        public List<Domain.Entities.Project> Projects { get; set; }
    }
}
