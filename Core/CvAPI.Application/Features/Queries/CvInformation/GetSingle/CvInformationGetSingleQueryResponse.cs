using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvInformation.GetSingle
{
    public class CvInformationGetSingleQueryResponse
    {
        public int Id { get; set; }
        public string CvName { get; set; }
        public string NameSurname { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageName { get; set; }
        public int LanguageId { get; set; }
    }
}
