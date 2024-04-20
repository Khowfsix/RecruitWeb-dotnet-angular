using Api.ViewModels.Position;
using Api.ViewModels.Skill;

namespace Api.ViewModels.CvHasSkill
{
    public class CvHasSkillViewModel
    {
        public Guid CvSkillsId { get; set; }
        public Guid Cvid { get; set; }
        public Guid SkillId { get; set; }
        public int? ExperienceYear { get; set; }
        public virtual SkillViewModel? Skill { get; set; }
    }
}