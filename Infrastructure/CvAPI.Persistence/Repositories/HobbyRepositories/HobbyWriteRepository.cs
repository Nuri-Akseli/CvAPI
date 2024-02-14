using CvAPI.Application.Repositories.HobbyRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;

namespace CvAPI.Persistence.Repositories.HobbyRepositories
{
    public class HobbyWriteRepository : WriteRepository<Hobby>, IHobbyWriteRepository
    {
        public HobbyWriteRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
