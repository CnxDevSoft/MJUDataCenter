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
        DepartmentRole AddDepartmentRole(string departmentRoleName, string departmentRoleNameTH, string departmentKey, Guid? departmentApiToken);
        DepartmentRole UpdateDepartmentRole(int departmentRoleId, string departmentRoleName, string departmentRoleNameTH, string departmentKey, Guid? departmentApiToken);
        List<UserDepartmentRole> GetDepartmentRoleByToken(Guid token);
    }
}
