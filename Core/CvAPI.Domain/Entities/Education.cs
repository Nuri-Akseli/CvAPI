using CvAPI.Domain.Entities.Common;

namespace CvAPI.Domain.Entities
{
    public class Education:BaseEntity
    {
        public int CvPartId { get; set; }
        public CvPart CvPart { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public int Order { get; set; }

    }
}
