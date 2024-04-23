using Application2.Services.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance2.Contexts;
using Persistance2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance2
{
    public static class PersistenceServiceRegistration1
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("LanguagCamp1ConnectionString")));
            services.AddScoped<ILangugaeRepository, LangugaeRepositories>();
           // services.AddScoped<IModelRepository, ModelRepository>();


            return services;
        }
    }
}
