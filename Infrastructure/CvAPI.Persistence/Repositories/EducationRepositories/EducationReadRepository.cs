﻿using CvAPI.Application.Repositories.EducationRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.EducationRepositories
{
    public class EducationReadRepository : ReadRepository<Education>, IEducationReadRepository
    {
        public EducationReadRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
