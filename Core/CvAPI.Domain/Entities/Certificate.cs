using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class Certificate:BaseEntity
    {
        public int CvPartId { get; set; }
        public CvPart CvPart { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string? ShortDescription { get; set; }
        public string? Link { get; set; }
        public int Order { get; set; }
    }
}
