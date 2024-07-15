using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public partial class Skill
{
    public Guid SkillId { get; set; }

    [Required]
    public string? SkillName { get; set; }

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CandidateHasSkill> CandidateHasSkills { get; set; } = new List<CandidateHasSkill>();

    //public virtual ICollection<CvHasSkill> CvHasSkills { get; set; } = new List<CvHasSkill>();

    public virtual ICollection<QuestionSkill> QuestionSkills { get; set; } = new List<QuestionSkill>();

    public virtual ICollection<Requirement> Requirements { get; set; } = new List<Requirement>();
}