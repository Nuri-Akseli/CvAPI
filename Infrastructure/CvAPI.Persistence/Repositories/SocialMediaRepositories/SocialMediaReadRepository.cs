using CvAPI.Application.Repositories.SocialMediaRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.SocialMediaRepositories
{
    public class SocialMediaReadRepository : ReadRepository<SocialMedia>, ISocialMediaReadRepository
    {
        public SocialMediaReadRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
