namespace Service.Models
{
    public class RequirementModel
    {
        public Guid RequirementId { get; set; } = new();
        public Guid PositionId { get; set; } = new();
        public PositionModel Position { get; set; } = null!;
        public Guid SkillId { get; set; }
        public SkillModel Skill { get; set; } = null!;
        public string Experience { get; set; } = string.Empty;
        public string? Notes { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}