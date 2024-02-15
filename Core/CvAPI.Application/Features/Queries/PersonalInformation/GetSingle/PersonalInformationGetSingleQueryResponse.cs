using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.PersonalInformation.GetSingle
{
    public class PersonalInformationGetSingleQueryResponse
    {
        public int CvPartId { get; set; }
        public string Name { get; set; }
        public string? IconPath { get; set; }
        public string? IconName { get; set; }
        public int Order { get; set; }
    }
}
