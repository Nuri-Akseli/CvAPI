using U=CvAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CvAPI.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public bool Success { get; set; }
        public List<U.User> Users { get; set; }
    }
}
