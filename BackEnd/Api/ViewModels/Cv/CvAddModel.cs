using Api.ViewModels.Certificate;

namespace Api.ViewModels.Cv
{
    public class CvAddModel
    {
        public Guid CandidateId { get; set; }
        public string? CvPdf { get; set; } = null!;
        public string CvName { get; set; }
        public string AboutMe { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsDefault { get; set; } = false;
        public IList<CvSkillRelationAddModel> Skills { get; set; } = new List<CvSkillRelationAddModel>();
    }

    public class CvSkillRelationAddModel
    {
        public Guid SkillId { get; set; }
        public int ExperienceYear { get; set; }
    }
}