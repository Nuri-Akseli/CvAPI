using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.GeneralArticle.GetSingle
{
    public class GeneralArticleGetSingleQueryResponse
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public int CvPartId { get; set; }
        public bool IsActive { get; set; }
    }
}
