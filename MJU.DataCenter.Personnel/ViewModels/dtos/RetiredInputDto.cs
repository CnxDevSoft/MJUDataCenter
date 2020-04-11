using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels.dtos
{
    public class RetiredInputDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string RetiredYear { get; set; }
        public string PersonnelType { get; set; }
    }

    public class RetiredGraphInputDto
    {
        [Required]
        public int Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
