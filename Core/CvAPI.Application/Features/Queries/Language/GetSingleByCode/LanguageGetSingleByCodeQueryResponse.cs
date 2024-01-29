using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Language.GetSingleByCode
{
    public class LanguageGetSingleByCodeQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? FlagPath { get; set; }
        public string? FlagFileName { get; set; }
        public bool IsActive { get; set; }
    }
}
