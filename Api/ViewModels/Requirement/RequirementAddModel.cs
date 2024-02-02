namespace Api.ViewModels.Requirement
{
    public class RequirementAddModel
    {
        public Guid PositionId { get; set; }

        public Guid SkillId { get; set; }

        public string Experience { get; set; } = null!;

        public string? Notes { get; set; }
    }
}