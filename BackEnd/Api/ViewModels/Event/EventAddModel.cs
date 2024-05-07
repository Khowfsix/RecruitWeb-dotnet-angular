namespace Api.ViewModels.Event
{
    public class EventAddModel
    {
        public string EventName { get; set; } 

        public Guid RecruiterId { get; set; }

        public string? Description { get; set; }

        public string Place { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int MaxParticipants { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}