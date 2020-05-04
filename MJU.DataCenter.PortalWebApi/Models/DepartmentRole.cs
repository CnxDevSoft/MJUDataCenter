using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PortalWebApi.Models
{
    public class DepartmentRole
    {
        public int DepartmentRoleId { get; set; }
        public string DepartmentRoleName { get; set; }
        public string DepartmentKey { get; set; }
        public Guid DepartmentApiToken { get; set; }
    }
}
