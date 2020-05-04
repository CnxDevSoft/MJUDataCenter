using MJU.DataCenter.PortalWebApi.Models;
using MJU.DataCenter.PortalWebApi.Repository.Interface;
using MJU.DataCenter.PortalWebApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PortalWebApi.Services
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
