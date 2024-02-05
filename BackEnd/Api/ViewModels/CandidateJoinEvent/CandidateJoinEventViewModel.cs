using Api.ViewModels.Candidate;
using Api.ViewModels.Event;

namespace Api.ViewModels.CandidateJoinEvent
{
    public class CandidateJoinEventViewModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EventViewModel Event { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Guid CandidateJoinEventId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid EventId { get; set; }

        public int JoinEventCount { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CandidateViewModel Candidate { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}