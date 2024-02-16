using CvAPI.Application.Repositories.PartCategoryRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.PartCategoryRepositories
{
    public class PartCategoryWriteRepository : WriteRepository<PartCategory>, IPartCategoryWriteRepository
    {
        public PartCategoryWriteRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
