namespace Data.Entities;

public partial class Interviewer
{
    public Guid InterviewerId { get; set; }


    public string UserId { get; set; }


    public Guid DepartmentId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual WebUser User { get; set; } = null!;
}