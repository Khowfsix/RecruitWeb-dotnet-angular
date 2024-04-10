using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public partial class CandidateHasSkill
    {
        public Guid CandidateHasSkillId { get; set; }
        public Guid CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; }
        public Guid SkillId { get; set; }
        public virtual Skill? Skill { get; set; }

        [Required]
        public string? Level { get; set; }
    }
}
