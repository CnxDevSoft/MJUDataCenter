using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.ViewModels;

namespace MJU.DataCenter.Personnel.Service.Interface
{
    public interface IPersonnelService
    {

        object GetAllPersonnelGroup(int type);

        List<PersonGroupDataSourceModel> GetAllPersonnelGroupDataSource();

        object GetAllPersonnelPosition(int type);

        List<PersonPostionDataSourceModel> GetAllPersonnelPositionDataSource();

        object GetAllPersonnelEducation(int type);

        List<PersonEducationDataSourceModel> GetAllPersonnelEducationDataSource();

        object GetAllPersonnelPositionGeneration(int type);

        List<PersonPostionGenertionDataSourceViewModel> GetAllPersonnelPositionGenerationDataSource();

        object GetAllPersonRetired(int total,int type);

        List<RetiredPersonDataTableModel> GetDataTablePersonRetired(string year, int type);

        object GetAllPersonGender(int type);


    }
}
