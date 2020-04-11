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
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
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
