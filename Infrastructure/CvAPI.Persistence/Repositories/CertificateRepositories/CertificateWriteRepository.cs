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
    public class CertificateWriteRepository : WriteRepository<Certificate>, ICertificateWriteRepository
    {
        public CertificateWriteRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
