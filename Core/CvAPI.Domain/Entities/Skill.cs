using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class Skill:BaseEntity
    {
        public int CvPartId { get; set; }
        public CvPart CvPart { get; set; }
        public string Name { get; set; }
        public int Ratio { get; set; }
        public int Order { get; set; }

    }
}
