using System;
using System.Threading.Tasks;
using MJU.DataCenter.ResearchExtension.ViewModels;

namespace MJU.DataCenter.ResearchExtension.Service.Interface
{
    public interface IResearchAndExtensionService
    {
        object GetResearchDepartment(InputFilterGraphViewModel input);
        object GetResearchGroup(InputFilterGraphViewModel input);
        object GetResearchData(InputFilterGraphViewModel input);
        Task<object> GetAllResearchMoneyAsync(InputFilterGraphViewModel input);


    }
}
