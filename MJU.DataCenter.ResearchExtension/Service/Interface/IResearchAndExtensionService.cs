using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.ViewModels;

namespace MJU.DataCenter.ResearchExtension.Service.Interface
{
    public interface IResearchAndExtensionService
    {
        object GetResearchFaculty(InputFilterGraphViewModel input, List<int> filter);
        public List<ResearchFacultyDataSourceModel> GetResearchFacultyDataSource(InputFilterDataSourceViewModel input, List<int> filter);
        object GetResearchGroup(InputFilterGraphViewModel input, List<int> filter);
        List<ResearchGroupDataSourceModel> GetResearchGroupDataSource(InputFilterDataSourceViewModel input, List<int> filter);
        object GetResearchData(InputFilterGraphViewModel input, List<int> filter);
        List<ResearchDataDataSourceModel> GetResearchDataDataSource(InputFilterDataSourceViewModel input, List<int> filter);
        object GetAllResearchMoney(InputFilterGraphViewModel input, List<int> filter);
        List<RankResearchRageMoneyDataSourceModel> GetAllResearchMoneyDataSource(InputFilterDataSourceViewModel input, List<int> filter);
        List<ResearcherResearchDataModel> GetDcResearcherByName(ResearcherInputDto input, List<int> filter);
        ResearcherDetailModel GetResearcherDetail(int researcherId);

        PersonResearchDetailModel GetPersonResearchDetail(string citizenId);
        ResearchDetailViewModel GetResearchDetail(int researchId);

        ResearchExtensionDashboard GetResearchDashboard();
        FacultyDashboard GetFacultyDashboard();

    }
}
