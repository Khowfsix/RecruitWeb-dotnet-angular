namespace Service.Models
{
    public class CertificateModel
    {
        public Guid CertificateId { get; set; }
        public string? CertificateName { get; set; }
        public string? Description { get; set; }
        public DateTime IssueDate { get; set; }
        public string? CertificateURL { get; set; }
        public Guid CandidateId { get; set; }
        public virtual CandidateModel? Candidate { get; set; }
    }
}