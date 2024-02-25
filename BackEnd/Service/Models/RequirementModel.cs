namespace Service.Models
{
    public class RequirementModel
    {
        public Guid RequirementId { get; set; }

        public Guid PositionId { get; set; }

        public PositionModel Position { get; set; } = null!;

        public Guid SkillId { get; set; }

        public SkillModel Skill { get; set; } = null!;


        public string Experience { get; set; }


        public string? Notes { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}