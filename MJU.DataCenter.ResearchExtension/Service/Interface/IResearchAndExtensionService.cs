using System;
namespace MJU.DataCenter.ResearchExtension.Service.Interface
{
    public interface IResearchAndExtensionService
    {
        object GetResearchDepartment(int type);
        object GetResearchGroup(int type);
        object GetResearchData(int type);
    }
}
