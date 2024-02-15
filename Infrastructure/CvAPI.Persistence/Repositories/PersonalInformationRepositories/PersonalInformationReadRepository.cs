﻿using CvAPI.Application.Repositories.PersonalnformationRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.PersonalInformationRepositories
{
    public class PersonalInformationReadRepository : ReadRepository<PersonalInformation>, IPersonalInformationReadRespository
    {
        public PersonalInformationReadRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
