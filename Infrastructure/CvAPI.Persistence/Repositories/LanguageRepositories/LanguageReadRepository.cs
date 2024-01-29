using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.LanguageRepositories
{
    public class LanguageReadRepository:ReadRepository<Language>,ILanguageReadRepository
    {
        public LanguageReadRepository(CvAPIDbContext context):base(context)
        {
            
        }
    }
}
