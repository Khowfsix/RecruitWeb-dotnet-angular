using Api.ViewModels.CandidateHasSkill;

namespace Api.ViewModels.Candidate
{
    public class CandidateViewModel
    {
        public Guid CandidateId { get; set; }
        public string UserId { get; set; }
        public string? AboutMe { get; set; }
        public bool IsDeleted { get; set; } = false;
        public WebUserViewModel User { get; set; }

        public ICollection<CandidateHasSkillViewModel> CandidateHasSkills { get; set; }
    }
}