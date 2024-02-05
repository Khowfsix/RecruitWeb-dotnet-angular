namespace Api.ViewModels.CvHasSkill
{
    public class CvHasSkillUpdateModel
    {
        public Guid CvSkillsId { get; set; }
        public Guid Cvid { get; set; }

        public Guid SkillId { get; set; }

        public int? ExperienceYear { get; set; }
    }
}