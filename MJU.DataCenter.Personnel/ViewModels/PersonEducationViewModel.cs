﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonEducation
    {
        public string EducationTypeName { get; set; }
        public int Person { get; set; }

    }
    public class PersonEducationViewModel
    {
        public List<PersonEducation> PersonEducation { get; set; }
    }

}
