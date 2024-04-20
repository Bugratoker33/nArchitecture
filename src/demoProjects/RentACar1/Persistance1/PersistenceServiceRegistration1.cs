using Application1.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance1.Contexts;
using Persistance1.Repositories1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance1
{
    public static class PersistenceServiceRegistration1
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("RentACarCamp1ConnectionString")));
            services.AddScoped<IBrandRepository, BrandRepository>();

            return services;
        }
    }
}
