
namespace Service.Models
{
    public class CandidateHasSkillModel
    {
        public Guid CandidateHasSkillId { get; set; }
        public string CandidateId { get; set; }
        public Guid SkillId { get; set; }
        public SkillModel Skill { get; set; }
        public string Level { get; set; }

    }
}