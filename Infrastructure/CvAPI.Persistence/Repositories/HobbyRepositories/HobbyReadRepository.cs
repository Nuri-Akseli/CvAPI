using CvAPI.Application.Repositories.HobbyRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;

namespace CvAPI.Persistence.Repositories.HobbyRepositories
{
    public class HobbyReadRepository : ReadRepository<Hobby>, IHobbyReadRepository
    {
        public HobbyReadRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
