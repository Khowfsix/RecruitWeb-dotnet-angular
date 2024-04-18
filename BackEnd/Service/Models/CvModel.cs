using Data.Entities;

namespace Service.Models
{
    public class CvModel
    {
        public Guid Cvid { get; set; }

        public Guid CandidateId { get; set; }

        public string? CvPdf { get; set; }

        public string CvName { get; set; }

        public string AboutMe { get; set; } = null!;


        public bool IsDeleted { get; set; } = false;

        public bool IsDefault { get; set; } = false;

        public virtual ICollection<ApplicationModel> Applications { get; set; } = null!;

        public virtual CandidateModel Candidate { get; set; } = null!;

        public virtual ICollection<CvHasSkillModel> CvHasSkills { get; set; } = null!;
    }
}