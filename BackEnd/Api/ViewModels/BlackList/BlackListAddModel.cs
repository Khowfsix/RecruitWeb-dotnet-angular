namespace Api.ViewModels.BlackList
{
    public class BlackListAddModel
    {
        public Guid CandidateId { get; set; }
        public string? Reason { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; }
    }
}