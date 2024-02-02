using CvAPI.Domain.Entities;
using CvAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace CvAPI.Persistence.Contexts
{
    public class CvAPIDbContext:DbContext
    {
        public CvAPIDbContext(DbContextOptions options):base(options) { 
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<CvInformation> CvInformations { get; set; }
        public DbSet<CvPart> CvParts { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.IsActive = true,
                    _=>true
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
