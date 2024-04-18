namespace Data.Entities;

public partial class Application
{
    public Guid ApplicationId { get; set; }

    public Guid Cvid { get; set; }

    public Guid PositionId { get; set; }

    public DateTime CreatedTime { get; set; }

    public int? Company_Status { get; set; }

    public int? Candidate_Status { get; set; }

    public int? Priority { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Cv Cv { get; set; }

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual Position Position { get; set; }
}