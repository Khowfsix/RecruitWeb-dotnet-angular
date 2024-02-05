namespace Service.Models
{
    public class CandidateJoinEventModel
    {
        public Guid CandidateJoinEventId { get; set; }

        public Guid CandidateId { get; set; }

        public Guid EventId { get; set; }

        public DateTime? DateJoin { get; set; } = DateTime.Now;
        public int JoinEventCount { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EventModel Event { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CandidateModel Candidate { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}