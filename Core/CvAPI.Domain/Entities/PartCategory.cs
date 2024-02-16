using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class PartCategory:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CvPart> CvParts { get; set; }
    }
}
