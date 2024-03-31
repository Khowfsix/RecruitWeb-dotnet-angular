using Api.ViewModels.Candidate;
using Api.ViewModels.Certificate;
using Api.ViewModels.Skill;

namespace Api.ViewModels.Cv
{
    public class CvViewModel
    {
        public Guid Cvid { get; set; }
        public Guid CandidateId { get; set; }
        public virtual CandidateViewModel Candidate { get; set; } = null!;
        public string? Experience { get; set; }
        public string? CvPdf { get; set; }

        public string CvName { get; set; } = string.Empty;

        public string Introduction { get; set; } = string.Empty;

        public string Education { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
        public IList<SkillViewModel> Skills { get; set; } = new List<SkillViewModel>();
        public IList<CertificateViewModel> Certificates { get; set; } = new List<CertificateViewModel>();
    }
}