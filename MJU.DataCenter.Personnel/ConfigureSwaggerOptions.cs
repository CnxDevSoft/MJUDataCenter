using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace MJU.DataCenter.Personnel
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {     
                Version = description.ApiVersion.ToString(),
               // Description = "A sample application with Swagger, Swashbuckle, and API versioning.",
               // Contact = new OpenApiContact() { Name = "MaeJo Research IT Development", Email = "research.api@mju.ac.th" },
              //  License = new OpenApiLicense() { Name = "MJU", Url = new Uri("https://opensource.org/licenses/MIT") }
            };

            if (description.ApiVersion.MajorVersion == 1)
            {
                info.Title = "Maejo Personnel External API";
                info.Description = " API สำหรับการดึงข้อมูลจากกองกิจการหน่วยงานมหาวิทยาลัยแม่โจ้";
            }
            else
            {
                info.Title = "Maejo Personnel Internal API";
                info.Description = " API สำหรับการดึงข้อมูลจากกองกิจการหน่วยงานมหาวิทยาลัยแม่โจ้";
            }

            if (description.IsDeprecated)
            {
        
            }

            return info;
        }
    }
}
