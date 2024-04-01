namespace Api.ViewModels.CandidateJoinEvent
{
    public class CandidateJoinEventUpdateModel
    {
        public string EventName { get; set; }

        public Guid CandidateJoinEventId { get; set; }

        public Guid CandidateId { get; set; }

        public Guid EventId { get; set; }
    }
}