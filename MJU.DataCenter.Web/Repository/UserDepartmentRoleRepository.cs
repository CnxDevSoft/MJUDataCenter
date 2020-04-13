using MJU.DataCenter.Web.Models;
using MJU.DataCenter.Web.Repository.Common;
using MJU.DataCenter.Web.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Web.Repository
{
    public class UserDepartmentRoleRepository : Repository<UserDepartmentRole>, IUserDepartmentRoleRepository
    {
        public UserDepartmentRoleRepository(DataCenterContext context)
         : base(context)
        {
        }



    }
}
