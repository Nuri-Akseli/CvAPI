using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.SocialMedia.GetAll
{
    public class SocialMediaGetAllQueryResponse
    {
        public List<Domain.Entities.SocialMedia> SocialMedias { get; set; }
    }
}
