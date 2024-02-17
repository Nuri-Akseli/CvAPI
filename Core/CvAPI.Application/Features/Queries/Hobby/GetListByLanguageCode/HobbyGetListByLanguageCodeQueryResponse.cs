using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Hobby.GetListByLanguageCode
{
    public class HobbyGetListByLanguageCodeQueryResponse
    {
        public string Name { get; set; }
        public string? IconPath { get; set; }
        public string? IconName { get; set; }
        public object Hobbies { get; set; }
    }
}
