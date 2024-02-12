using CvAPI.Application.Repositories.SkillRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.SkillRepositories
{
    public class SkillWriteRepository : WriteRepository<Skill>, ISkillWriteRepository
    {
        public SkillWriteRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
