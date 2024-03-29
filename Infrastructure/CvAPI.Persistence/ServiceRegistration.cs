﻿using CvAPI.Application.Repositories.CertificateRepositories;
using CvAPI.Application.Repositories.CvInformationRepositories;
using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.EducationRepositories;
using CvAPI.Application.Repositories.GeneralArticleRepositories;
using CvAPI.Application.Repositories.HobbyRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Application.Repositories.PartCategoryRepositories;
using CvAPI.Application.Repositories.PersonalnformationRepositories;
using CvAPI.Application.Repositories.ProjectRepositories;
using CvAPI.Application.Repositories.SkillRepositories;
using CvAPI.Application.Repositories.SocialMediaRepositories;
using CvAPI.Application.Repositories.UserRepositories;
using CvAPI.Application.Repositories.WorkExperienceRepositories;
using CvAPI.Persistence.Contexts;
using CvAPI.Persistence.Repositories.CertificateRepositories;
using CvAPI.Persistence.Repositories.CvInformationRepositories;
using CvAPI.Persistence.Repositories.CvPartRepositories;
using CvAPI.Persistence.Repositories.EducationRepositories;
using CvAPI.Persistence.Repositories.GeneralArticleRepositories;
using CvAPI.Persistence.Repositories.HobbyRepositories;
using CvAPI.Persistence.Repositories.LanguageRepositories;
using CvAPI.Persistence.Repositories.PartCategoryRepositories;
using CvAPI.Persistence.Repositories.PersonalInformationRepositories;
using CvAPI.Persistence.Repositories.ProjectRepositories;
using CvAPI.Persistence.Repositories.SkillRepositories;
using CvAPI.Persistence.Repositories.SocialMediaRepositories;
using CvAPI.Persistence.Repositories.UserRepositories;
using CvAPI.Persistence.Repositories.WorkExperienceRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CvAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
           
            services.AddDbContext<CvAPIDbContext>(options=>options.UseMySQL(Configuration.ConnectionString));

            services.AddScoped<IUserReadRepository,UserReadRepository>();
            services.AddScoped<IUserWriteRepository,UserWriteRepository>();

            services.AddScoped<ILanguageReadRepository,LanguageReadRepository>();
            services.AddScoped<ILanguageWriteRepository,LanguageWriteRepository>();

            services.AddScoped<ICvInformationReadRepository,CvInformationReadRepository>();
            services.AddScoped<ICvInformationWriteRepository,CvInformationWriteRepository>();

            services.AddScoped<ICvPartReadRepository, CvPartReadRepository>();
            services.AddScoped<ICvPartWriteRepository,CvPartWriteRepository>();

            services.AddScoped<IGeneralArticleReadRepository, GeneralArticleReadRepository>();
            services.AddScoped<IGeneralArticleWriteRepository, GeneralArticleWriteRepository>();

            services.AddScoped<IEducationReadRepository, EducationReadRepository>();
            services.AddScoped<IEducationWriteRepository,EducationWriteRepository>();

            services.AddScoped<IProjectReadRepository, ProjectReadRepository>();
            services.AddScoped<IProjectWriteRepository, ProjectWriteRepository>();

            services.AddScoped<ICertificateReadRepository, CertificateReadRepository>();
            services.AddScoped<ICertificateWriteRepository,CertificateWriteRepository>();

            services.AddScoped<ISocialMediaReadRepository, SocialMediaReadRepository>();
            services.AddScoped<ISocialMediaWriteRepository, SocialMediaWriteRepository>();

            services.AddScoped<ISkillReadRepository, SkillReadRepository>();
            services.AddScoped<ISkillWriteRepository, SkillWriteRepository>();

            services.AddScoped<IWorkExperienceReadRepositoy, WorkExperienceReadRepository>();
            services.AddScoped<IWorkExperienceWriteRepository, WorkExperienceWriteRepository>();

            services.AddScoped<IHobbyReadRepository, HobbyReadRepository>();
            services.AddScoped<IHobbyWriteRepository, HobbyWriteRepository>();

            services.AddScoped<IPersonalInformationReadRespository, PersonalInformationReadRepository>();
            services.AddScoped<IPersonalInformationWriteRepository,PersonalInformationWriteRepository>();

            services.AddScoped<IPartCategoryReadRepository, PartCategoryReadRepository>();
        }
        
    }
}
