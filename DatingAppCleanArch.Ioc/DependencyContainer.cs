using DatingAppCleanArch.Application.Common;
using DatingAppCleanArch.Application.Interfaces;
using DatingAppCleanArch.Application.Services;
using DatingAppCleanArch.Domain.Interfaces;
using DatingAppCleanArch.Persistence;
using DatingAppCleanArch.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCleanArch.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IUserRrepository, UserRepository>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserService, UserService>();

            services.AddScoped<DatingAppContext>();


            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();

                });

        }
    }
}
