namespace Data.Entities;

public partial class QuestionSkill
{
    public Guid QuestionSkillsId { get; set; }

    public Guid QuestionId { get; set; }

    public Guid SkillId { get; set; }

    public virtual Question Question { get; set; } 

    public virtual Skill Skill { get; set; } 
}