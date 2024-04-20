using Api.ViewModels.Candidate;
using Api.ViewModels.Event;

namespace Api.ViewModels.CandidateJoinEvent
{
    public class CandidateJoinEventViewModel
    {
        public Guid CandidateJoinEventId { get; set; }
        public Guid CandidateId { get; set; }
        public CandidateViewModel Candidate { get; set; }
        public Guid EventId { get; set; }
        public EventViewModel Event { get; set; }
        public DateTime DateJoin {  get; set; }
        public int JoinEventCount { get; set; }
    }
}