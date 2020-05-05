using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PortalWebApi.Models
{
    public class HomeViewModel
    {
        public UserInfo UserInfo { get; set; }
        public List<DepartmentRole> DepartmentRoles { get; set; }
    }
    
    public class UserInfo
    {
        public string Role { get; set; }
        public DepartmentRole DepartmentRole { get; set; }
        public string FullName { get; set; }
    }
}
