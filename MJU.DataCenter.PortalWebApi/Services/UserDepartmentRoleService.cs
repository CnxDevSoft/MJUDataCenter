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
            return _userDepartmentRoleRepository.GetAllWith(x => x.DepartmentRole).ToList();
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

        public DepartmentRole UpdateDepartmentRole(int departmentRoleId, string departmentRoleName, string departmentRoleNameTH, string departmentKey, Guid? departmentApiToken)
        {
            var depertmentRole = _departmentRoleRepository.Find(m => m.DepartmentRoleId == departmentRoleId).FirstOrDefault();

            depertmentRole.DepartmentRoleName = departmentRoleName;
            depertmentRole.DepartmentRoleNameTH = departmentRoleNameTH;
            depertmentRole.DepartmentKey = departmentKey;

            if (departmentApiToken == null)
            {
                depertmentRole.DepartmentApiToken = Guid.NewGuid();
            }
            else
            {
                depertmentRole.DepartmentApiToken = departmentApiToken;
            }

            return _departmentRoleRepository.Update(depertmentRole);
        }

        public DepartmentRole AddDepartmentRole(string departmentRoleName, string departmentRoleNameTH, string departmentKey, Guid? departmentApiToken)
        {
            var departmentRole = new DepartmentRole { 
                DepartmentRoleName = departmentRoleName,
                DepartmentRoleNameTH = departmentRoleNameTH,
                DepartmentKey = departmentKey,
                DepartmentApiToken = departmentApiToken == null ? Guid.NewGuid() : departmentApiToken,
                DepartmentApiActive = true
            };

            return _departmentRoleRepository.Add(departmentRole);

        }

        public List<UserDepartmentRole> GetDepartmentRoleByToken(Guid token)
        {
            var query = _userDepartmentRoleRepository.GetAllWith(inc => inc.DepartmentRole)
                .Where(x => x.DepartmentRole.DepartmentApiToken == token).ToList();
            return query;
        }

    }
}
