using MJU.DataCenter.PortalWebApi.Models;
using MJU.DataCenter.PortalWebApi.Repository.Common;
using MJU.DataCenter.PortalWebApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PortalWebApi.Repository
{
    public class UserDepartmentRoleRepository : Repository<UserDepartmentRole>, IUserDepartmentRoleRepository
    {
        public UserDepartmentRoleRepository(DataCenterContext context)
         : base(context)
        {
        }



    }
}
