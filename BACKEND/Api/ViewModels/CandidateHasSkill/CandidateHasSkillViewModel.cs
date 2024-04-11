using Api.ViewModels.Skill;

namespace Api.ViewModels.CandidateHasSkill
{
    public class CandidateHasSkillViewModel
    {
        public Guid CandidateHasSkillId { get; set; }
        public string CandidateId { get; set; }
        public Guid SkillId { get; set; }
        public SkillViewModel Skill { get; set; }
        public string Level { get; set; }
    }
}