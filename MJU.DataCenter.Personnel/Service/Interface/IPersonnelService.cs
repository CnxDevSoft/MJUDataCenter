using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.ViewModels;
using MJU.DataCenter.Personnel.ViewModels.dtos;

namespace MJU.DataCenter.Personnel.Service.Interface
{
    public interface IPersonnelService
    {

        object GetAllPersonnelGroup(int type, List<int> filter);

        List<PersonGroupDataSourceModel> GetAllPersonnelGroupDataSource(string type, List<int> filter);

        object GetAllPersonnelPosition(int type, List<int> filter);
        List<PersonPostionDataSourceModel> GetAllPersonnelPositionDataSource(string type, List<int> filter);
        object GetAllPersonnelEducation(int type, List<int> filter);

        List<PersonEducationDataSourceModel> GetAllPersonnelEducationDataSource(string type, List<int> filter);

        object GetAllPersonnelPositionGeneration(int type, List<int> filter);

        List<PersonPostionGenertionDataSourceViewModel> GetAllPersonnelPositionGenerationDataSource(string positionType, int? index, List<int> filter);

        object GetAllPersonnelRetired(int total,int type, List<int> filter);

        List<RetiredPersonDataTableModel> GetDataTablePersonRetired(string year, int type, List<int> filter);

        object GetAllPersonnelGroupWorkDuration(int type, List<int> filter);

        List<PersonGroupWorkDurationDataSourceModel> GetAllPersonnelGroupWorkDurationDataSource(string personType, int? index, List<int> filter);

        object GetAllPersonnelGroupAdminPositionType(int type, List<int> filter);

        List<PersonGroupAdminPositionDataSourceModel> GetAllPersonnelGroupAdminPositionTypeDataSource(string adminPositionType, string personnelType, List<int> filter);

        object GetAllPersonnelGroupFaculty(int type, List<int> filter);

        List<PersonGroupFacultyDataSourceModel> GetAllPersonnelGroupFacultyDataSource(string faculty, string personnelType, List<int> filter);

        object GetAllPersonnelPositionFaculty(int type, List<int> filter);

        public List<PersonPositionFacultyDataSourceModel> GetAllPersonnelPositionFacultyDataSource(string faculty, string position, List<int> filter);

        object GetAllPersonnelGroupRetiredYear(RetiredGraphInputDto input, List<int> filter);

        List<PersonGroupRetiredYearDataSourceModel> GetAllPersonnelGroupRetiredYearDataSource(RetiredInputDto input, List<int> filter);

        object GetAllPersonnelGroupPositionLevel(int type, List<int> filter);

        object GetAllPersonnelPositionEducation(int type, List<int> filter);

        List<PersonPostionEducationDataSourceModel> GetAllPersonnelPositionEducationDataSource(List<int> filter);

        List<PersonGroupPositionLevelDataSourceModel> GetAllPersonnelGroupPositionLevelDataSource(string personnelType, string positionLevel, List<int> filter);
        List<PersonnelGenderDataSourceViewModel> GetAllPersonnelGenderDataSourceByType(int type, int gender, string genderName, List<int> filter);

        List<PersonnelGenderDataTableViewModel> GetAllPersonnelGender(int type, List<int> filter);
        List<PersonnelGenderDataSourceViewModel> GetAllPersonnelGenderDataSource(List<int> filter);

        PersonnelDataSourceViewModel GetPersonDetailByCitizenId(string citizenId);
        PersonnelDashboard GetPersonnelDashboard();
        List<PersonEducationDetailViewModel> GetPersonEducationDetailByCitizenId(string citizenId);

        List<PersonnelDataSourceViewModel> GetPersonnelByName(PersonnelInputDto input, List<int> filter);

    }
}
