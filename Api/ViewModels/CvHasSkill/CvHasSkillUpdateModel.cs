﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ViewModels.CvHasSkill
{
    public class CvHasSkillUpdateModel
    {
        public Guid CvSkillsId { get; set; }
        public Guid Cvid { get; set; }

        public Guid SkillId { get; set; }

        public int? ExperienceYear { get; set; }
    }
}
