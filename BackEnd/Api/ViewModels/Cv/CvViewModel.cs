using Api.ViewModels.Application;
using Api.ViewModels.Candidate;
using Api.ViewModels.Certificate;
using Api.ViewModels.Skill;

namespace Api.ViewModels.Cv
{
    public class CvViewModel
    {
        public Guid Cvid { get; set; }
        public Guid CandidateId { get; set; }
        public CandidateViewModel Candidate { get; set; } = null!;
        public string? CvPdf { get; set; }
        public string CvName { get; set; }
        public string AboutMe { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsDefault { get; set; } = false;
        public ICollection<ApplicationViewModel> Applications { get; set; } = null!;
        public IList<SkillViewModel> Skills { get; set; } = new List<SkillViewModel>();
    }
}