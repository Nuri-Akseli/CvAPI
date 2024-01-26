using CvAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Repositories.UserRepositories
{
    public interface IUserWriteRepository:IWriteRepository<User>
    {
        bool UpdateRefreshToken(string refreshToken, User user, DateTime expiresTime);
    }
}
