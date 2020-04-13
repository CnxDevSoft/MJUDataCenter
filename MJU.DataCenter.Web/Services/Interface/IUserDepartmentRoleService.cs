using MJU.DataCenter.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Web.Services.Interface
{
    public interface IUserDepartmentRoleService
    {
        List<UserDepartmentRole> GetAll();
        List<UserDepartmentRole> GetById(int userId);
    }
}
