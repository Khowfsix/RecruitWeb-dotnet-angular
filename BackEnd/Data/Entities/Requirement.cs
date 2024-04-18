namespace Data.Entities;

public partial class Requirement
{
    public Guid RequirementId { get; set; }

    public Guid PositionId { get; set; }

    public Guid SkillId { get; set; }

    public string Experience { get; set; } 

    public string? Notes { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Position Position { get; set; } 

    public virtual Skill Skill { get; set; } 
}