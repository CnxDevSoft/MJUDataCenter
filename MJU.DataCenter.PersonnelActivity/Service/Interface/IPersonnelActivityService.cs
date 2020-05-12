using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MJU.DataCenter.PersonnelActivity.Models;
using MJU.DataCenter.PersonnelActivity.ViewModels;
using MJU.DataCenter.PersonnelActivity.ViewModels.dtos;

namespace MJU.DataCenter.PersonnelActivity.Service.Interface
{
    public interface IPersonnelActivityService
    {
        List<PersonnelViewModel> GetPersonnelActivityByName(PersonnelInputDto input);

        object GetFacultyActivity(PersonnelActivityInputDto input, List<int> filter);
        List<FacultyActivityDataSourceModel> GetFacultyActivityDataSource(PersonnelActivityFilterInputDto input, List<int> filter);

        object GetPersonnelFacultyActivity(PersonnelActivityInputDto input, List<int> filter);
        List<PersonnelFacultyActivityDataSourceModel> GetPersonnelFacultyActivityDataSource(PersonnelActivityFilterInputDto input, List<int> filter);
    }
}
