using MJU.DataCenter.PortalWebApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PortalWebApi.Services
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        /*
            Note that each property here needs to exactly match the 
            name of each property in my appsettings.json config object
        */
        public string PerssonnelApi { get; set; }
        public string ResearchExtensionApi { get; set; }
        public string PerssonnelApiSwagger { get; set; }
        public string ResearchExtensionApiSwagger { get; set; }

    }
}
