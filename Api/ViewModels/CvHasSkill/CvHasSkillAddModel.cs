namespace Api.ViewModels.CvHasSkill
{
    public class CvHasSkillAddModel
    {
        public Guid Cvid { get; set; }

        public Guid SkillId { get; set; }

        public int? ExperienceYear { get; set; }
    }
}