﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.GeneralArticle.GetAll
{
    public class GeneralArticleGetAllQueryResponse
    {
        public List<Domain.Entities.GeneralArticle> GeneralArticles { get; set; }
        
    }
}
