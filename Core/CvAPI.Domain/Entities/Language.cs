using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class Language:BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? FlagPath { get; set; }
        public string? FlagFileName { get; set; }
        public ICollection<CvInformation> CvInformations { get; set; }
    }
}
