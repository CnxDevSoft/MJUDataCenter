using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Repository.Interface;
using MJU.DataCenter.ResearchExtension.Repository.Repositories;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.Service.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

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
            services.AddScoped<IPersonnelGroupRepository, PersonnelGroupRepository>();
            services.AddScoped<IResearchDataRepository, ResearchDataRepository>();
            services.AddScoped<IResearcherPaperRepository, ResearcherPaperRepository>();
            services.AddScoped<IResearcherRepository, ResearcherRepository>();
            services.AddScoped<IResearchGroupRepository, ResearchGroupRepository>();
            services.AddScoped<IResearchPaperRepository, ResearchPaperRepository>();
            services.AddScoped<IResearchPersonnelRepository, ResearchPersonnelRepository>();
            services.AddScoped<IResearchMoneyRepository, ResearchMoneyRepository>();
            services.AddScoped<IMoneyTypeRepository, MoneyTypeRepository>();
            services.AddScoped<IDcResearchDepartmentRepository, DcResearchDepartmentRepository>();
            services.AddScoped<IDcResearchGroupRepository, DcResearchGroupRepository>();
            services.AddScoped<IDcResearchDataRepository, DcResearchDataRepository>();
            services.AddScoped<IDcResearchMoneyRepository, DcReasearchMoneyRepository>();
            services.AddTransient<INewSeedDataService, NewSeedDataService>();
            services.AddTransient<IResearchAndExtensionService, ResearchAndExtensionService>();

            //swagger
            //services.AddSwaggerGen(c =>
            //{
            //   /*  c.DocInclusionPredicate((docName, apiDoc) =>
            //    {
            //        if (!apiDoc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

            //        var versions = methodInfo.DeclaringType.GetCustomAttributes(true).OfType<ApiVersionAttribute>()
            //        .SelectMany(a => a.Versions);

            //        return versions.Any(v => $"v{v.ToString()}" == docName);
            //    });*/
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Maejo Research Public API", Description = "API สำหรับการดึงข้อมูลงานวิจัยภายนอกหน่วยงานมหาวิทยาลัยแม่โจ้", Version = "v1" });
            //    c.SwaggerDoc("v2", new OpenApiInfo { Title = "Maejo Research Private API",  Description = "API สำหรับการดึงข้อมูลงานวิจัยภายในหน่วยงานมหาวิทยาลัยแม่โจ้", Version = "v2" });
            //});
            //services.AddApiVersioning(o => { 
            //    o.ReportApiVersions = true; 
            //    o.AssumeDefaultVersionWhenUnspecified = true;
            //    o.DefaultApiVersion = new ApiVersion(1, 0);


            //    o.Conventions.Controller<ResearchMoney>().HasApiVersion(new ApiVersion(1, 0));
            //    o.Conventions.Controller<ResearchMoney>().HasApiVersion(new ApiVersion(2, 0));
            //});

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
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder =>
              builder.WithOrigins("https://localhost:44302"));

            app.UseSwagger();
            app.UseSwaggerUI(
            options =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
                 // build a swagger endpoint for each discovered API version
                 foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/{description.GroupName}/swagger.json", "Maejo Research API " + description.GroupName.ToUpperInvariant());
                }
            });
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Maejo Researcher Pubic API");
            //    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Maejo Researcher Private API");
            //});

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



        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
