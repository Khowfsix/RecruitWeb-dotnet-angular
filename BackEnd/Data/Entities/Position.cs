using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public partial class Position
{
    public Guid PositionId { get; set; }

    public string? PositionName { get; set; }

    public string? Description { get; set; }

    public string? ImageURL { get; set; }

    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }

    public int MaxHiringQty { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Column("CompanyId")]
    public Guid CompanyId { get; set; }

    public Guid LanguageId { get; set; }

    public Guid RecruiterId { get; set; }

    public bool IsDeleted { get; set; }

    public Guid CategoryPositionId { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Company Company { get; set; } 

    public virtual Language Language { get; set; } 

    public virtual Recruiter Recruiter { get; set; } 

    public virtual CategoryPosition CategoryPosition { get; set; } 

    public virtual ICollection<Requirement> Requirements { get; set; } = new List<Requirement>();

    public virtual ICollection<SuccessfulCadidate> SuccessfulCadidates { get; set; } = new List<SuccessfulCadidate>();
}