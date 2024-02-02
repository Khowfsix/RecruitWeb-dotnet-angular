namespace Service.Models
{
    public class CvHasSkillModel
    {
        public Guid CvSkillsId { get; set; }

        public Guid Cvid { get; set; }

        public Guid SkillId { get; set; }

        public int? ExperienceYear { get; set; }
    }
}