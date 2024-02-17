using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvInformation.GetSingleByLanguageCode
{
    public class CvInformationGetSingleByLanguageCodeQueryResponse
    {
        public string NameSurname { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageName { get; set; }
    }
}
