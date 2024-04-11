using Api.ViewModels.Certificate;
using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels.Cv
{
    public class CvUpdateModel
    {
        [Required]
        public Guid Cvid { get; set; }

        [Required]
        public Guid CandidateId { get; set; }

        public string? CvPdf { get; set; }

        public string CvName { get; set; }

        public string AboutMe { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsDefault { get; set; }
        public IList<CvSkillRelationUpdateModel> Skills { get; set; } = new List<CvSkillRelationUpdateModel>();
    }

    public class CvSkillRelationUpdateModel
    {
        [Required]
        public Guid SkillId { get; set; }

        public int ExperienceYear { get; set; }
    }
}