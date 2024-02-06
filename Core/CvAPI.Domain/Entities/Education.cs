using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class Education:BaseEntity
    {
        public int CvPartId { get; set; }
        public CvPart CvPart { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string Title { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public int Order { get; set; }

    }
}
