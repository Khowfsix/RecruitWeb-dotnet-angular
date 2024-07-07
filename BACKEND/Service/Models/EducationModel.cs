using System.ComponentModel.DataAnnotations;

namespace Service.Models
{
    public partial class EducationModel
    {
        public Guid EducationId { get; set; }
        public string? School { get; set; }
        public string? Major { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public string? AdditionalDetails { get; set; }
        public Guid? CandidateId { get; set; }
        public virtual CandidateModel? Candidate { get; set; }
    }
}

