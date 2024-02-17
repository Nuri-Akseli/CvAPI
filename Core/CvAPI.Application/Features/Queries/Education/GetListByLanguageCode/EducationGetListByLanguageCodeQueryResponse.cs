using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Education.GetListByLanguageCode
{
    public class EducationGetListByLanguageCodeQueryResponse
    {
        public string Name { get; set; }
        public string? IconPath { get; set; }
        public string? IconName { get; set; }
        public object Educations { get; set; }
    }
}
