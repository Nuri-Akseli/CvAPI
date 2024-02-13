using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class WorkExperience:BaseEntity
    {
        public int CvPartId { get; set; }
        public CvPart CvPart { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string? ShortDescription { get; set; }
        public string City { get; set; }
        public int Order { get; set; }
    }
}
