using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.CvPartRepositories
{
    public class CvPartReadRepository: ReadRepository<CvPart>,ICvPartReadRepository
    {
        public CvPartReadRepository(CvAPIDbContext context):base(context)
        {
            
        }
    }
}
