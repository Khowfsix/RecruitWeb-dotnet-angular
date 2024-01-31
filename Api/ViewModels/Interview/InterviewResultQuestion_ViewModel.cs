using Api.ViewModels.Round;

namespace Api.ViewModels.Interview
{
    public class InterviewResultQuestion_ViewModel
    {
        public Guid InterviewId { get; set; }
        public string? Notes { get; set; }
        public ICollection<RoundResultAddModel> Rounds { get; set; } = new List<RoundResultAddModel>();
    }
}