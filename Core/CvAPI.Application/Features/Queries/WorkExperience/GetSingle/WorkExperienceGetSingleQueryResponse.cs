using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.WorkExperience.GetSingle
{
    public class WorkExperienceGetSingleQueryResponse
    {
        public int Id { get; set; }
        public int CvPartId { get; set; }
        public string StartDate { get; set; }
        public string? EndDate { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string? ShortDescription { get; set; }
        public string City { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
