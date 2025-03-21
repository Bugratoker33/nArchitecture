﻿using Application2.Features.Languages.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application2
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

           services.AddAutoMapper(Assembly.GetExecutingAssembly());
           services.AddMediatR(Assembly.GetExecutingAssembly());
           services.AddScoped<LanguageBusinessRule>();

         
           // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
           // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>)); //pilen devreye sokmadan çalışmaz validateör aslında burası aspect 

            return services;

        }
    }
}
