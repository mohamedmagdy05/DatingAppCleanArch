using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingAppCleanArch.Application.Interfaces;
using DatingAppCleanArch.Application.Profiles;
using DatingAppCleanArch.Application.Services;
using DatingAppCleanArch.Domain.Interfaces;
using DatingAppCleanArch.Ioc;
using DatingAppCleanArch.Persistence;
using DatingAppCleanArch.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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

            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new UserProfile());
            //});

            //services.AddAutoMapper(typeof(Startup));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterService(services);
        }
    }
}
