using MJU.DataCenter.Web.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Web.Models
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        /*
            Note that each property here needs to exactly match the 
            name of each property in my appsettings.json config object
        */
        public string PerssonnelApi { get; set; }
        public string ResearchExtensionApi { get; set; }
    }
}
