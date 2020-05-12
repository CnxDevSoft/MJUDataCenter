using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PersonnelActivity.ViewModels.dtos
{
    public class PersonnelActivityFilterInputDto
    {
        [Required]
        public string Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
