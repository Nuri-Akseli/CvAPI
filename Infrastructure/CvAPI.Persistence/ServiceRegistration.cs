using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Application.Repositories.UserRepositories;
using CvAPI.Persistence.Contexts;
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
        }
        
    }
}
