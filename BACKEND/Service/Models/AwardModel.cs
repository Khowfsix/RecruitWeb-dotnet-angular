namespace Service.Models
{
    public partial class AwardModel
    {
        public Guid AwardId { get; set; }
        public string? AwardName { get; set; }
        public string? AwardOrganization { get; set; }
        public DateTime IssueDate { get; set; }
        public string? Description { get; set; }
        public Guid CandidateId { get; set; }
        public virtual CandidateModel? Candidate { get; set; }
    }
}
