using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Web.Models
{
    public class DepartmentRole
    {
        public int DepartmentRoleId { get; set; }
        public string DepartmentRoleName { get; set; }
        public string DepartmentRoleNameTH { get; set; }
        public string DepartmentKey { get; set; }
        public Guid? DepartmentApiToken { get; set; }
        public bool? DepartmentApiActive { get; set; }
    }
}
