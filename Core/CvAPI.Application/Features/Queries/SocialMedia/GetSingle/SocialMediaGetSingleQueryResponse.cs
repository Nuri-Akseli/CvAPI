using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.SocialMedia.GetSingle
{
    public class SocialMediaGetSingleQueryResponse
    {
        public int Id { get; set; }
        public int CvPartId { get; set; }
        public string Url { get; set; }
        public string? IconPath { get; set; }
        public string? IconName { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
