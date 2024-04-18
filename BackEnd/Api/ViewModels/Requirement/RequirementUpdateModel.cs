namespace Api.ViewModels.Requirement
{
    public class RequirementUpdateModel
    {
        public Guid RequirementId { get; set; }
        public Guid PositionId { get; set; }

        public Guid SkillId { get; set; }

        public string Experience { get; set; } 

        public string? Notes { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}