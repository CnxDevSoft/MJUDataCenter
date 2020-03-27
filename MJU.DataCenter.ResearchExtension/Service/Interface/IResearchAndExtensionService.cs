using System;
using MJU.DataCenter.ResearchExtension.ViewModels;

namespace MJU.DataCenter.ResearchExtension.Service.Interface
{
    public interface IResearchAndExtensionService
    {
        object GetResearchDepartment(InputFilterGraphViewModel type);
        object GetResearchGroup(InputFilterGraphViewModel type);
        object GetResearchData(InputFilterGraphViewModel type);
        object GetAllResearchMoney(InputFilterGraphViewModel type);
        
    }
}
