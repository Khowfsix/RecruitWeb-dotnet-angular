using Api.ViewModels.Certificate;

namespace Api.ViewModels.Cv
{
    public class CvAddModel
    {
        public Guid CandidateId { get; set; }
        public string? Experience { get; set; }
        public string? CvPdf { get; set; } = null!;
        public string CvName { get; set; }
        public string Introduction { get; set; }
        public string Education { get; set; }
        public bool IsDeleted { get; set; } = false;
        public IList<CvSkillRelationAddModel> Skills { get; set; } = new List<CvSkillRelationAddModel>();
        public IList<CertificateAddModel> Certificates { get; set; } = new List<CertificateAddModel>();
    }

    public class CvSkillRelationAddModel
    {
        public Guid SkillId { get; set; }
        public int ExperienceYear { get; set; }
    }
}