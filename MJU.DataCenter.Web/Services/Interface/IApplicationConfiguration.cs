using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Web.Services.Interface
{
    public interface IApplicationConfiguration
    {
        /*
            Note that each property here needs to exactly match the 
            name of each property in my appsettings.json config object
        */
        string PerssonnelApi { get; set; }
        string ResearchExtensionApi { get; set; }
        
    }
}
