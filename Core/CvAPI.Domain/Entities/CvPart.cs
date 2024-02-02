using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class CvPart:BaseEntity
    {
        public int CvInformationId { get; set; }
        public CvInformation CvInformation { get; set; }
        public string Name { get; set; }
        public string? IconPath { get; set; }
        public string? IconName { get; set; }
        public int Order { get; set; }
        public bool IsContactInfo { get; set; } 
    }
}
