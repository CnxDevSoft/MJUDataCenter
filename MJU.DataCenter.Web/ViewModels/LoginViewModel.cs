using MJU.DataCenter.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "กรุณาระบุ {0}")]
        [EmailAddress]
        [Display(Name = "อีเมล์")]
        public string Email { get; set; }

        [Required(ErrorMessage = "กรุณาระบุ {0}")]
        [Display(Name = "รหัสผ่าน")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class LoginApiModel
    {
        public bool IsSuccess { get; set; }
        public string AccessToken { get; set; }
        public string Description { get; set; }
        public List<DepartmentRole> DepartmentRoleList { get; set; }
    }


}
