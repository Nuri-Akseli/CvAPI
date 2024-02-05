using CvAPI.Application.Repositories.GeneralArticleRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.GeneralArticleRepositories
{
    public class GeneralArticleReadRepository : ReadRepository<GeneralArticle>, IGeneralArticleReadRepository
    {
        public GeneralArticleReadRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
