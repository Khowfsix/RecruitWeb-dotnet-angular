using Data.Entities;

namespace Service.Models
{
    public class CvModel
    {
        public Guid Cvid { get; set; }

        public Guid CandidateId { get; set; }

        public string? Experience { get; set; }

        public string? CvPdf { get; set; }

        public string CvName { get; set; } = string.Empty;

        public string Introduction { get; set; } = null!;

        public string Education { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public bool IsDefault { get; set; } = false;

        public virtual ICollection<ApplicationModel> Applications { get; set; } = null!;

        public virtual Candidate Candidate { get; set; } = null!;

        public virtual ICollection<CertificateModel> Certificates { get; set; } = null!;

        public virtual ICollection<CvHasSkillModel> CvHasSkills { get; set; } = null!;
    }
}