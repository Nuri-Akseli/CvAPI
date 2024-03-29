﻿using CvAPI.Domain.Entities;
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
        public DbSet<GeneralArticle> GeneralArticles { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<PartCategory> PartCategories { get; set; }
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
