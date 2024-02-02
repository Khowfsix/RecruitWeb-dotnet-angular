using Api.ViewModels.Position;
using Api.ViewModels.Skill;

namespace Api.ViewModels.Requirement
{
    public class RequirementViewModel
    {
        public Guid RequirementId { get; set; }
        public Guid PositionId { get; set; }
        public Guid SkillId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SkillViewModel Skill { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public PositionViewModel Position { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string Experience { get; set; } = null!;

        public string? Notes { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}