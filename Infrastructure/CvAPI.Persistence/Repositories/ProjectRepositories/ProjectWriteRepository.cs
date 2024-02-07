using CvAPI.Application.Repositories.ProjectRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.ProjectRepositories
{
    public class ProjectWriteRepository : WriteRepository<Project>, IProjectWriteRepository
    {
        public ProjectWriteRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
