using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public partial class Event
{
    public Guid EventId { get; set; }

    public string EventName { get; set; } 

    public Guid RecruiterId { get; set; }

    public string? Description { get; set; }

    public string? ImageURL { get; set; }
    public int? ApplyPriority { get; set; }

    [Required]
    public string Place { get; set; }

    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }

    public int MaxParticipants { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<EventHasPosition> EventHasPositions { get; set; } = new List<EventHasPosition>();

    public virtual ICollection<CandidateJoinEvent> CandidateJoinEvents { get; set; } = new List<CandidateJoinEvent>();

    public virtual Recruiter Recruiter { get; set; } 
}