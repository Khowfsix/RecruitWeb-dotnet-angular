using Api.ViewModels.Recruiter;

namespace Api.ViewModels.Event
{
    public class EventViewModel
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; } = null!;

        public Guid RecruiterId { get; set; }

        public RecruiterViewModel Recruiter { get; set; }   

        public string? Description { get; set; }

        public string Place { get; set; } = null!;

        public string? ImageURL { get; set; }

        public DateTime? DatetimeEvent { get; set; }

        public int MaxParticipants { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}