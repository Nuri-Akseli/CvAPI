﻿using CvAPI.Application.Repositories.UserRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.UserRepositories
{
    public class UserWriteRepository:WriteRepository<User>,IUserWriteRepository
    {
        public UserWriteRepository(CvAPIDbContext context):base(context)
        {
        }

        public bool UpdateRefreshToken(string refreshToken, User user, DateTime expiresTime)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate=expiresTime;
            return Update(user);
        }
    }
}
