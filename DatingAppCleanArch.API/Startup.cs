using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using DatingAppCleanArch.Application.Common;
using DatingAppCleanArch.Application.Interfaces;
using DatingAppCleanArch.Application.Profiles;
using DatingAppCleanArch.Application.Services;
using DatingAppCleanArch.Domain.Interfaces;
using DatingAppCleanArch.Ioc;
using DatingAppCleanArch.Persistence;
using DatingAppCleanArch.Persistence.Repository;
using Elastic.Apm.AspNetCore;
using Elastic.Apm.DiagnosticSource;
using Elastic.Apm.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DatingAppCleanArch.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DatingAppContext>(d => d.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            RegisterServices(services);

        

            services.AddAutoMapper(typeof(Startup));

            services.AddApiVersioning(av =>
            {
                av.DefaultApiVersion = new ApiVersion(1, 0);
                //av.AssumeDefaultVersionWhenUnspecified = true;
                av.ReportApiVersions = true;
                av.ApiVersionReader = new HeaderApiVersionReader("x-version");

            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

       
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
        
        }
        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterService(services);
            #region swaggerOld
            //services.AddSwaggerGen(
            //    c =>
            //         {
            //             c.SwaggerDoc("v1.0",new OpenApiInfo{Title = "User API",Version = "v1.0"});

            //             c.SwaggerDoc("v1.1",
            //             new OpenApiInfo
            //             {
            //                 Title = "User API",
            //                 Version = "v1.1"
            //             });
            //             // Apply the filters
            //             c.OperationFilter<RemoveVersionParameterFilter>();
            //             c.DocumentFilter<ReplaceVersionWithExactValueInPathFilter>();

            //             // Ensure the routes are added to the right Swagger doc

            //             c.DocInclusionPredicate((docName, apiDesc) =>
            //             {
            //                 if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

            //                 var versions = methodInfo.DeclaringType
            //                     .GetCustomAttributes(true)
            //                     .OfType<ApiVersionAttribute>()
            //                     .SelectMany(attr => attr.Versions);

            //                 return versions.Any(v => $"v{v.ToString()}" == docName);
            //             });
            //         });
            #endregion
        }
    }
}