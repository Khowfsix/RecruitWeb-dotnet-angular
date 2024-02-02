using Data.Entities;

namespace Service.Models
{
    public class CvModel
    {
        public Guid Cvid { get; set; }

        public Guid CandidateId { get; set; }

        public string? Experience { get; set; }

        public string? CvPdf { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string CvName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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