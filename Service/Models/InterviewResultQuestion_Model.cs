namespace Service.Models
{
    public class InterviewResultQuestion_Model
    {
        public Guid InterviewId { get; set; }
        public string? Notes { get; set; }
        public ICollection<RoundModel> Rounds { get; set; } = new List<RoundModel>();
    }
}