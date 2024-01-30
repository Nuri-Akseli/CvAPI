using CvAPI.Application.Repositories.CvInformationRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.CvInformationRepositories
{
    public class CvInformationWriteRepository:WriteRepository<CvInformation>,ICvInformationWriteRepository
    {
        public CvInformationWriteRepository(CvAPIDbContext context):base(context)
        {
            
        }
    }
}
