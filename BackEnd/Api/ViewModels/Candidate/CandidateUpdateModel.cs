namespace Api.ViewModels.Candidate
{
    public class CandidateUpdateModel
    {
        public Guid CandidateId { get; set; }

        public string UserId { get; set; }

        public string? AboutMe { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}