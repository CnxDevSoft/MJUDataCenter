using MJU.DataCenter.Web.Models;
using MJU.DataCenter.Web.Repository.Interface;
using MJU.DataCenter.Web.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Web.Services
{
    public class UserDepartmentRoleService : IUserDepartmentRoleService
    {
        private readonly IUserDepartmentRoleRepository _userDepartmentRoleRepository;

        public UserDepartmentRoleService(IUserDepartmentRoleRepository userDepartmentRoleRepository)
        {
            _userDepartmentRoleRepository = userDepartmentRoleRepository;
        }
        public List<UserDepartmentRole> GetAll()
        {
            return _userDepartmentRoleRepository.GetAllWith(x=>x.DepartmentRole).ToList();
        }

        public List<UserDepartmentRole> GetById(int userId)
        {
            return _userDepartmentRoleRepository.GetAllWith(x => x.DepartmentRole)
                .Where( x=>x.UserId == userId).ToList();
        }
    }
}
