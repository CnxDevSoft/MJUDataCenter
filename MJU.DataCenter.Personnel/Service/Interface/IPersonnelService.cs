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

        object GetAllPersonnelGroup(int type);

        List<PersonGroupDataSourceModel> GetAllPersonnelGroupDataSource(string type);

        object GetAllPersonnelPosition(int type);

        List<PersonPostionDataSourceModel> GetAllPersonnelPositionDataSource(string type);

        object GetAllPersonnelEducation(int type);

        List<PersonEducationDataSourceModel> GetAllPersonnelEducationDataSource(string type);

        object GetAllPersonnelPositionGeneration(int type);

        List<PersonPostionGenertionDataSourceViewModel> GetAllPersonnelPositionGenerationDataSource();

        object GetAllPersonnelRetired(int total,int type);

        List<RetiredPersonDataTableModel> GetDataTablePersonRetired(string year, int type);

        object GetAllPersonnelGroupWorkDuration(int type);

        List<PersonGroupWorkDurationDataSourceModel> GetAllPersonnelGroupWorkDurationDataSource();

        List<PersonnelDataSourceViewModel> GetAllPersonnelGroupWorkDurationDataSourceByType(string personGroupType, string personGroupTypeId, int type);

        object GetAllPersonnelGroupAdminPositionType(int type);

        List<PersonGroupAdminPositionDataSourceModel> GetAllPersonnelGroupAdminPositionTypeDataSource(string adminPositionType, string personnelType);

        object GetAllPersonnelGroupFaculty(int type);

        List<PersonGroupFacultyDataSourceModel> GetAllPersonnelGroupFacultyDataSource(string faculty, string personnelType);

        object GetAllPersonnelPositionFaculty(int type);

        public List<PersonPositionFacultyDataSourceModel> GetAllPersonnelPositionFacultyDataSource(string faculty, string position);

        object GetAllPersonnelGroupRetiredYear(RetiredGraphInputDto input);

        List<PersonGroupRetiredYearDataSourceModel> GetAllPersonnelGroupRetiredYearDataSource(RetiredInputDto input);

        object GetAllPersonnelGroupPositionLevel(int type);

        object GetAllPersonnelPositionEducation(int type);

        List<PersonPostionEducationDataSourceModel> GetAllPersonnelPositionEducationDataSource();

        List<PersonGroupPositionLevelDataSourceModel> GetAllPersonnelGroupPositionLevelDataSource(string personnelType, string positionLevel);
        List<PersonnelGenderDataSourceViewModel> GetAllPersonnelGenderDataSourceByType(int type, int gender, string genderName);

        List<PersonnelGenderDataTableViewModel> GetAllPersonnelGender(int type);
        List<PersonnelGenderDataSourceViewModel> GetAllPersonnelGenderDataSource();

    }
}
