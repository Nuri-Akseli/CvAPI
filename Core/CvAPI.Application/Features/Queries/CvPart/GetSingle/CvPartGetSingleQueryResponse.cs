using CvAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvPart.GetSingle
{
    public class CvPartGetSingleQueryResponse
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public bool? IsContactInfo { get; set; }
        public bool? IsActive { get; set; }
        public int? CvInformationId { get; set; }
    }
}
