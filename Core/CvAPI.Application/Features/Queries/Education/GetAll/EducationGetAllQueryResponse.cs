using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Education.GetAll
{
    public class EducationGetAllQueryResponse
    {
        public List<Domain.Entities.Education> Education { get; set; }
    }
}
