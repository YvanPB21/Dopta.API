using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Dopta.API.Domain.Persistence.Contexts;
using Dopta.API.Domain.Repositories;
using Dopta.API.Domain.Services;
using Dopta.API.Persistence;
using Dopta.API.Persistence.Repositories;
using Dopta.API.Services;

namespace Dopta.API
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
            services.AddDbContext<AppDbContext>(options=>
            {
                //options.UseInMemoryDatabase("dopta-api-in-memory");
            });
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<ISpecieRepository, SpecieRepository>();
            services.AddScoped<ISpecieService, SpecieService>();

            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IUserProfileService, UserProfileService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostService>();

            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ICandidateService, CandidateService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
