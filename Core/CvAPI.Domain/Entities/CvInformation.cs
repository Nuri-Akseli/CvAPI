using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class CvInformation:BaseEntity
    {
        public string CvName { get; set; }
        public string NameSurname { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageName { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public ICollection<CvPart> CvParts { get; set; }
    }
}
