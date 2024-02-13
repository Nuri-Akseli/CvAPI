using CvAPI.Application.Repositories.WorkExperienceRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.WorkExperienceRepositories
{
    public class WorkExperienceReadRepository : ReadRepository<WorkExperience>, IWorkExperienceReadRepositoy
    {
        public WorkExperienceReadRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
