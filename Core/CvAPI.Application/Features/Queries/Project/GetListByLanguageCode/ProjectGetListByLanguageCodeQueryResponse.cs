using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Project.GetListByLanguageCode
{
    public class ProjectGetListByLanguageCodeQueryResponse
    {
        public string Name { get; set; }
        public string? IconPath { get; set; }
        public string? IconName { get; set; }
        public object Projects { get; set; }
    }
}
