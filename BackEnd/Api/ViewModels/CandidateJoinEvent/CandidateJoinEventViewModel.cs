using Api.ViewModels.Candidate;
using Api.ViewModels.Event;

namespace Api.ViewModels.CandidateJoinEvent
{
    public class CandidateJoinEventViewModel
    {
        public EventViewModel Event { get; set; } = new EventViewModel();
        public Guid CandidateJoinEventId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid EventId { get; set; }
        public int JoinEventCount { get; set; }
        public CandidateViewModel Candidate { get; set; } = new();
    }
}