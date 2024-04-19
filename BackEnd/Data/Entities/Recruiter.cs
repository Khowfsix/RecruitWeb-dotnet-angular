using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public partial class Recruiter
{
    public Guid RecruiterId { get; set; }

    public string UserId { get; set; } 

    [Column("CompanyId")]
    public Guid CompanyId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Company Company { get; set; } 

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual WebUser User { get; set; } 
}