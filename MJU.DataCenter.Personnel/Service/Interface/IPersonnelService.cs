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

        List<PersonPostionDataSourceModel> GetAllPersonnelPositionDataSource();

        object GetAllPersonnelEducation(int type);

        List<PersonEducationDataSourceModel> GetAllPersonnelEducationDataSource();

        object GetAllPersonnelPositionGeneration(int type);

        List<PersonPostionGenertionDataSourceViewModel> GetAllPersonnelPositionGenerationDataSource();

        object GetAllPersonRetired(int total,int type);

        List<RetiredPersonDataTableModel> GetDataTablePersonRetired(string year, int type);

        List<PersonnelGenderDataTableViewModel> GetAllPersonGender(int type);

        List<PersonnelGenderDataSourceViewModel> GetAllPersonGenderDataSource();

        object GetAllPersonnelGroupWorkDuration(int type);

        List<PersonGroupWorkDurationDataSourceModel> GetAllPersonnelGroupWorkDurationDataSource();

        List<PersonnelDataSourceViewModel> GetAllPersonnelGroupWorkDurationDataSourceByType(string personGroupType, string personGroupTypeId, int type);

        object GetAllPersonGroupAdminPositionType(int type);

        List<PersonGroupAdminPositionDataSourceModel> GetAllPersonGroupAdminPositionTypeDataSource();

        object GetAllPersonGroupFaculty(int type);

        List<PersonGroupFacultyDataSourceModel> GetAllPersonGroupFacultyDataSource();

        object GetAllPersonPositionFaculty(int type);

        public List<PersonPositionFacultyDataSourceModel> GetAllPersonPositionFacultyDataSource();

        object GetAllPersonGroupRetiredYear(RetiredGraphInputDto input);

        List<PersonGroupRetiredYearDataSourceModel> GetAllPersonGroupRetiredYearDataSource(RetiredInputDto input);

        object GetAllPersonGroupPositionLevel(int type);

        object GetAllPersonnelPositionEducation(int type);

        List<PersonPostionEducationDataSourceModel> GetAllPersonnelPositionEducationDataSource();


        List<PersonGroupPositionLevelDataSourceModel> GetAllPersonGroupPositionLevelDataSource();
        List<PersonnelGenderDataSourceViewModel> GetAllPersonGenderDataSourceByType(int type, int gender, string genderName);

    }
}
