﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ViewModels.SecurityQuestion
{
    public class SecurityQuestionViewModel
    {
        public Guid SecurityQuestionId { get; set; }
        public string QuestionString { get; set; } = null!;
    }
}
