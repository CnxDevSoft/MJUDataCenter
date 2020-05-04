using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PortalWebApi.Models
{
    public class UserPermissionRole
    {
        public int UserPermissionRoleId { get; set; }
        public int UserId { get; set; }
        public int PermissionRoleId { get; set; }
        public virtual PermissionRole PermissiontRole { get; set; }
    }
}
