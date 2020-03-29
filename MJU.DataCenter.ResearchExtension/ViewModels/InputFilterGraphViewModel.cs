using System;
using System.ComponentModel.DataAnnotations;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class InputFilterGraphViewModel
    {
        [Required]
        public int Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
