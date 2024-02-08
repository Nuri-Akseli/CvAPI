using CvAPI.Application.Repositories.CertificateRepositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories.CertificateRepositories
{
    public class CertificateReadRepository : ReadRepository<Certificate>, ICertificateReadRepository
    {
        public CertificateReadRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
