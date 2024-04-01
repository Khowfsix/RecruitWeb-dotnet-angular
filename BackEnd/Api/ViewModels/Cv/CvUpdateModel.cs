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
        public string? Experience { get; set; }
        public string? CvPdf { get; set; }

        public string CvName { get; set; }

        public string Introduction { get; set; }

        public string Education { get; set; }

        public bool IsDeleted { get; set; }
        public IList<CvSkillRelationUpdateModel> Skills { get; set; } = new List<CvSkillRelationUpdateModel>();
        public IList<CertificateUpdateModel> Certificates { get; set; } = new List<CertificateUpdateModel>();
    }

    public class CvSkillRelationUpdateModel
    {
        [Required]
        public Guid SkillId { get; set; }
        public int ExperienceYear { get; set; }
    }
}