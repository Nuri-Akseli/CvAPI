using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Hobby.GetAll
{
    public class HobbyGetAllQueryResponse
    {
        public List<Domain.Entities.Hobby> Hobbies { get; set; }
    }
}
