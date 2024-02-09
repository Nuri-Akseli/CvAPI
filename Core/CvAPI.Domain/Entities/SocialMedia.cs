using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class SocialMedia:BaseEntity
    {
        public int CvPartId { get; set; }
        public CvPart CvPart { get; set; }
        public string Url { get; set; }
        public string? IconPath { get; set; }
        public string? IconName { get; set; }
        public int Order { get; set; }
        
    }
}
