using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ViewModels.Report
{
    public class ReportAddModel
    {
        public string? ReportName { get; set; }

        public Guid RecruiterId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
