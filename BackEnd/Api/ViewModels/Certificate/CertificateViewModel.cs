using Api.ViewModels.Candidate;
namespace Api.ViewModels.Certificate
{
    public class CertificateViewModel
    {
        public Guid CertificateId { get; set; }
        public string? CertificateName { get; set; }
        public string? Description { get; set; } 
        public DateTime IssueDate { get; set; }
        public string? CertificateURL { get; set; } 
        public Guid CandidateId { get; set; } 
        public virtual CandidateViewModel? Candidate { get; set; }
    }
}