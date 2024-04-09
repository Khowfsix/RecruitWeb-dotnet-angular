using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public partial class PersonalProject
    {
        public Guid PersonalProjectId { get; set; }

        [Required]
        public string? ProjectName { get; set; }

        [Required]
        public DateTime? From { get; set; }
        public DateTime To { get; set; }

        public string? ShortDescription { get; set; }

        [DataType(DataType.Url)]
        public string? ProjectUrl { get; set; }

        public Guid CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; }
    }
}
