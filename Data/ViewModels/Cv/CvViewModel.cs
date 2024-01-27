using Data.ViewModels.Candidate;
using Data.ViewModels.Certificate;
using Data.ViewModels.Skill;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Cv
{
    public class CvViewModel
    {
        public Guid Cvid { get; set; }
        public Guid CandidateId { get; set; }
        public virtual CandidateViewModel Candidate { get; set; } = null!;
        public string? Experience { get; set; }
        public string? CvPdf { get; set; }
        public string CvName { get; set; }
        public string Introduction { get; set; }
        public string Education { get; set; }
        public bool IsDeleted { get; set; } = false;
        public IList<SkillViewModel> Skills { get; set; } = new List<SkillViewModel>();
        public IList<CertificateViewModel> Certificates { get; set; } = new List<CertificateViewModel>();
    }
}
