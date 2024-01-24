using CvAPI.Application.Repositories.UserRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.UserRepositories
{
    public class UserReadRepository:ReadRepository<User>,IUserReadRepository
    {
        public UserReadRepository(CvAPIDbContext context):base(context)
        {
        }
    }
}
