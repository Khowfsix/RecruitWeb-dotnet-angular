using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public partial class WorkExperience
    {
        public Guid WorkExperienceId { get; set; }

        [Required]
        public string? JobTitle { get; set; }

        [Required]
        public string? Company { get; set; }

        [Required]
        public DateTime? From { get; set; }
        public DateTime To { get; set; }

        public string? Description { get; set; }
        public string? Project { get; set; }

        [Required]
        public Guid CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; }
    }
}
