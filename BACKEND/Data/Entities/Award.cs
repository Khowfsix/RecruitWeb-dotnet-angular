using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public partial class Award
    {
        public Guid AwardId { get; set; }

        [Required]
        public string? AwardName { get; set; }
        [Required]
        public string? AwardOrganization { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        public string? Description { get; set; }

        public Guid CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; }
    }
}
