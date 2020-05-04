using MJU.DataCenter.PortalWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PortalWebApi.Services.Interface
{
    public interface IUserDepartmentRoleService
    {
        List<UserDepartmentRole> GetAll();
        List<UserDepartmentRole> GetById(int userId);
        List<DepartmentRole> GetAllDepartmentRole();
    }
}
