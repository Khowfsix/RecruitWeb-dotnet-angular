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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string CvName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Introduction { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Education { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public bool IsDeleted { get; set; } = false;
        public IList<SkillViewModel> Skills { get; set; } = new List<SkillViewModel>();
        public IList<CertificateViewModel> Certificates { get; set; } = new List<CertificateViewModel>();
    }
}