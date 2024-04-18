namespace Service.Models
{
    public class RequirementModel
    {
        public Guid RequirementId { get; set; }

        public Guid PositionId { get; set; }

        public PositionModel Position { get; set; } 

        public Guid SkillId { get; set; }

        public SkillModel Skill { get; set; } 

        public string Experience { get; set; }

        public string? Notes { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}