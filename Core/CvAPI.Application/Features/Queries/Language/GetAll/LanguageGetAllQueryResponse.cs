using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L = CvAPI.Domain.Entities;

namespace CvAPI.Application.Features.Queries.Language.GetAll
{
    public class LanguageGetAllQueryResponse
    {
        public List<L.Language> Languages { get; set; }
    }
}
