namespace Service.Models
{
    public class RequirementModel
    {
        public Guid RequirementId { get; set; }

        public Guid PositionId { get; set; }

        public PositionModel Position { get; set; } = null!;

        public Guid SkillId { get; set; }

        public SkillModel Skill { get; set; } = null!;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Experience { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string? Notes { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}