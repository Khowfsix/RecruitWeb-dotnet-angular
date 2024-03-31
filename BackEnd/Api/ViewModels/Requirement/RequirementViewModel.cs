using Api.ViewModels.Position;
using Api.ViewModels.Skill;

namespace Api.ViewModels.Requirement
{
    public class RequirementViewModel
    {
        public Guid RequirementId { get; set; } = new();
        public Guid PositionId { get; set; }
        public Guid SkillId { get; set; }

        public SkillViewModel Skill { get; set; } = new();

        public PositionViewModel Position { get; set; } = new();

        public string Experience { get; set; } = null!;

        public string? Notes { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}