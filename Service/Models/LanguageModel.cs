using System;
using System.Collections.Generic;

namespace Service.Models
{
    public class LanguageModel
    {
        public Guid LanguageId { get; set; }

        public string LanguageName { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;
    }

}