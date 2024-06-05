using Api.ViewModels.EventHasPosition;
using Api.ViewModels.Recruiter;

namespace Api.ViewModels.Event
{
    public class EventViewModel
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; } 

        public Guid RecruiterId { get; set; }

        public RecruiterViewModel Recruiter { get; set; }   

        public string? Description { get; set; }

        public string Place { get; set; } 

        public string? ImageURL { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int MaxParticipants { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<EventHasPositionViewModel> EventHasPositions { get; set; }
    }
}