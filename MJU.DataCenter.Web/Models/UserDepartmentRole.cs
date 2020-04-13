using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Web.Models
{
    public class UserDepartmentRole
    {
        public int UserDepartmentRoleId { get; set; }
        public int UserId { get; set; }
        public int DepartmentRoleId { get; set; }

      //  public virtual AppUser AppUser { get; set; }
        public virtual DepartmentRole DepartmentRole { get; set; }
    }
}
