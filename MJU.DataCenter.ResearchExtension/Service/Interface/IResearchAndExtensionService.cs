using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.ViewModels;

namespace MJU.DataCenter.ResearchExtension.Service.Interface
{
    public interface IResearchAndExtensionService
    {
        object GetResearchDepartment(InputFilterGraphViewModel input);
        public List<ResearchDepartmentDataSourceModel> GetResearchDepartmentDataSource(InputFilterDataSourceViewModel input);
        object GetResearchGroup(InputFilterGraphViewModel input);
        List<ResearchGroupDataSourceModel> GetResearchGroupDataSource(InputFilterDataSourceViewModel input);
        object GetResearchData(InputFilterGraphViewModel input);
        List<ResearchDataDataSourceModel> GetResearchDataDataSource(InputFilterDataSourceViewModel input);
        object GetAllResearchMoney(InputFilterGraphViewModel input);
        List<RankResearchMoneyDataSourceModel> GetAllResearchMoneyDataSource(InputFilterDataSourceViewModel input);
        List<ResearcherResearchDataModel> GetDcResearcherByName(ResearcherInputDto input);
        ResearcherDetailModel GetResearcherDetail(int researcherId);


    }
}
