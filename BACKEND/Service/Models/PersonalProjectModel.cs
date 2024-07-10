namespace Service.Models
{
    public partial class PersonalProjectModel
    {
        public Guid PersonalProjectId { get; set; }
        public string? ProjectName { get; set; }
        public DateTime? From { get; set; }
        public DateTime To { get; set; }
        public string? ShortDescription { get; set; }
        public string? ProjectUrl { get; set; }
        public Guid CandidateId { get; set; }
        public virtual CandidateModel? Candidate { get; set; }
    }
}
