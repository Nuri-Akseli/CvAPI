using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Certificate.GetSingle
{
    public class CertificateGetSingleQueryResponse
    {
        public int Id { get; set; }
        public int CvPartId { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string? ShortDescription { get; set; }
        public string? Link { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
