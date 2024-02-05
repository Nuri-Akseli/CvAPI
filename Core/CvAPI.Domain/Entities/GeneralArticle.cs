using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class GeneralArticle:BaseEntity
    {
        public string Article { get; set; }
        public int CvPartId { get; set; }
        public CvPart CvPart { get; set; }
    }
}
