using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Education.GetSingle
{
    public class EducationGetSingleQueryResponse
    {
        public int Id { get; set; }
        public int CvPartId { get; set; }
        public string StartDate { get; set; }
        public string? EndDate { get; set; }
        public string Title { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
