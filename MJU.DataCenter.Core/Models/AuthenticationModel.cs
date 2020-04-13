using System;
using System.Collections.Generic;
using System.Text;

namespace MJU.DataCenter.Core.Models
{
    public class AuthenticationModel
    {
        public bool IsSuccess { get; set; }
        public string AccessToken { get; set; }
        public string Description { get; set; }
        public List<DepartmentRoleDto> DepartmentRoleList { get; set; }
    }

    public class DepartmentRoleDto
    {
        public int DepartmentRoleId { get; set; }
        public string DepartmentRoleName { get; set; }
        public string DepartmentKey { get; set; }
    }
}

