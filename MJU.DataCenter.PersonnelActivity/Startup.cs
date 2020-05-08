using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MJU.DataCenter.PersonnelActivity.Models;
using MJU.DataCenter.PersonnelActivity.Repository.Interface;
using MJU.DataCenter.PersonnelActivity.Repository.Repositories;
using MJU.DataCenter.PersonnelActivity.Service.Interface;
using MJU.DataCenter.PersonnelActivity.Service.Services;
using MJU.DataCenter.ResearchExtension.Service.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MJU.DataCenter.PersonnelActivity
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

            services.AddDbContext<PersonnelActivityContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }));

            services.AddScoped<IDcActivityRepository, DcActivityRepository>();
            services.AddScoped<IDcPersonnelActivityRepository, DcPersonnelActivityRepository>();
            services.AddScoped<IPersonnelActivityRepository, PersonnelActivityRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddTransient<IPersonnelActivityService, PersonnelActivityService>();
            services.AddTransient<ISeedPersonnelActivityService, SeedPersonnelActivityService>();



            services.AddApiVersioning(
              options =>
              {
                  // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                  options.ReportApiVersions = true;
                  //   options.Conventions.Controller<ResearchMoney>().HasApiVersion(new ApiVersion(1, 0));
                  // options.Conventions.Controller<ResearchData>().HasApiVersion(new ApiVersion(1, 0));

                  //  options.Conventions.Controller<ResearchMoney>().HasApiVersion(new ApiVersion(2, 0));
              });
            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();

                    // integrate xml comments
                    //options.IncludeXmlComments(XmlCommentsFilePath);
                });
            services.AddRazorPages();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCors(builder =>
            // builder.WithOrigins("https://localhost:44302"));

            app.UseSwagger();
            app.UseSwaggerUI(
            options =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/{description.GroupName}/swagger.json", "Maejo Personnel Activity API " + description.GroupName.ToUpperInvariant());
                }
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
