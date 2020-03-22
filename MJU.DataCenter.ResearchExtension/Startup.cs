using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Repository.Interface;
using MJU.DataCenter.ResearchExtension.Repository.Repositories;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.Service.Services;

namespace MJU.DataCenter.ResearchExtension
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

            services.AddDbContext<ResearchExtensionContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //DI
            services.AddScoped<IPersonnelGroupRepository, PersonnelGroupRepository> ();
            services.AddScoped <IResearchDataRepository, ResearchDataRepository> ();
            services.AddScoped <IResearcherPaperRepository, ResearcherPaperRepository> ();
            services.AddScoped <IResearcherRepository, ResearcherRepository> ();
            services.AddScoped <IResearchGroupRepository, ResearchGroupRepository> ();
            services.AddScoped <IResearchPaperRepository, ResearchPaperRepository> ();
            services.AddScoped <IResearchPersonnelRepository,ResearchPersonnelRepository> ();
            services.AddScoped <IResearchMoneyRepository, ResearchMoneyRepository> ();
            services.AddScoped<IMoneyTypeRepository, MoneyTypeRepository>();
            services.AddScoped<IDcResearchDepartmentRepository, DcResearchDepartmentRepository>();
            services.AddScoped<IDcResearchGroupRepository, DcResearchGroupRepository>();
            services.AddScoped<IDcResearchDataRepository, DcResearchDataRepository>();
            services.AddScoped<IDcResearchMoneyRepository,DcReasearchMoneyRepository >();
            services.AddTransient<INewSeedDataService,NewSeedDataService >();
            services.AddTransient<IResearchAndExtensionService, ResearchAndExtensionService>();


            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddRazorPages();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder =>
              builder.WithOrigins("https://localhost:44302"));

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            // app.UseMvc(ConfigureRoutes);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
