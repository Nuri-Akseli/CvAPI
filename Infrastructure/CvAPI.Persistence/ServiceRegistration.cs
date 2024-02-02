﻿using CvAPI.Application.Repositories.CvInformationRepositories;
using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Application.Repositories.UserRepositories;
using CvAPI.Persistence.Contexts;
using CvAPI.Persistence.Repositories.CvInformationRepositories;
using CvAPI.Persistence.Repositories.CvPartRepositories;
using CvAPI.Persistence.Repositories.LanguageRepositories;
using CvAPI.Persistence.Repositories.UserRepositories;
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
        }
        
    }
}
