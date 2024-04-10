using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public partial class Education
    {
        public Guid EducationId { get; set; }

        [Required]
        public string? School { get; set; }

        [Required]
        public string? Major { get; set; }

        [Required]
        public DateTime From { get; set; }
        public DateTime? To { get; set; }

        public string? AdditionalDetails { get; set; }

        [Required]
        public Guid? CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; }
    }
}

