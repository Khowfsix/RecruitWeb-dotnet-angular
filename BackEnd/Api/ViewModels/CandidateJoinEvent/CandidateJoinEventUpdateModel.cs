namespace Api.ViewModels.CandidateJoinEvent
{
    public class CandidateJoinEventUpdateModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string EventName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Guid CandidateJoinEventId { get; set; }

        public Guid CandidateId { get; set; }

        public Guid EventId { get; set; }
    }
}