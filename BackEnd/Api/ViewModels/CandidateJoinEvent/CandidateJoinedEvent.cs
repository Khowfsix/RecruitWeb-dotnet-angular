using Api.ViewModels.Event;

namespace Api.ViewModels.CandidateJoinEvent
{
    public class CandidateJoinedEvent
    {
        public Guid CandidateId { get; set; }

        public Guid CandidateJoinEventId { get; set; }

        public Guid EventId { get; set; }

        public EventViewModel Event { get; set; } = new();
    }
}