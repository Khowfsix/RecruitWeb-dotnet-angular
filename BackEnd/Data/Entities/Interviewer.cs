namespace Data.Entities;

public partial class Interviewer
{
    public Guid InterviewerId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string UserId { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Guid DepartmentId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual WebUser User { get; set; } = null!;
}