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

        object GetAllPersonnelPosition(int type);

        object GetAllPersonnelEducation(int type);

        object GetAllPersonnelPositionGeneration(int type);

        object GetAllPersonRetired(int total,int type);

        List<RetiredPersonDataTableModel> GetDataTablePersonRetired(string year, int type);
    }
}
