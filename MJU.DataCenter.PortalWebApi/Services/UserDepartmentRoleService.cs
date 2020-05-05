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
        private readonly IDepartmentRoleRepository _departmentRoleRepository;

        public UserDepartmentRoleService(IUserDepartmentRoleRepository userDepartmentRoleRepository,
             IDepartmentRoleRepository departmentRoleRepository)
        {
            _userDepartmentRoleRepository = userDepartmentRoleRepository;
            _departmentRoleRepository = departmentRoleRepository;
        }
        public List<UserDepartmentRole> GetAll()
        {
            return _userDepartmentRoleRepository.GetAllWith(x=>x.DepartmentRole).ToList();
        }

        public List<UserDepartmentRole> GetById(int userId)
        {
            return _userDepartmentRoleRepository.GetAllWith(x => x.DepartmentRole)
                .Where(x => x.UserId == userId).ToList();
        }
        public List<DepartmentRole> GetAllDepartmentRole()
        {
            return _departmentRoleRepository.GetAll().ToList();
        }

        public DepartmentRole GenerateDepartmentRole(int departmentRoleId)
        {
            var depertmentRole = _departmentRoleRepository.Find(m=>m.DepartmentRoleId == departmentRoleId).FirstOrDefault();
            depertmentRole.DepartmentApiToken = Guid.NewGuid();
            return _departmentRoleRepository.Update(depertmentRole);
        }

    }
}
