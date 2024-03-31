namespace Api.ViewModels.Candidate
{
    public class CandidateAddModel
    {
        public string UserId { get; set; } = string.Empty;
        public string? Experience { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}