using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "กรุณาระบุ {0}")]
        [EmailAddress]
        [Display(Name = "อีเมล์")]
        public string Email { get; set; }

        [Required(ErrorMessage = "กรุณาระบุ {0}")]
        [StringLength(100, ErrorMessage = "{0} ต้องมีตัวอักษรอย่างน้อย {2} ตัว และต้องมีความยาวไม่เกิน {1} อักษร", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "รหัสผ่าน")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ยืนยันรหัสผ่าน")]
        [Compare("Password", ErrorMessage = "ยืนยันรหัสผ่านไม่ถูกต้อง")]
        public string ConfirmPassword { get; set; }
    }
}
