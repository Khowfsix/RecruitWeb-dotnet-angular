namespace Api.ViewModels.Candidate
{
    public class CandidateAddModel
    {
        public string UserId { get; set; }

        public string? AboutMe { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}