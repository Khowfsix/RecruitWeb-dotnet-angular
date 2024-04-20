using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public partial class Cv
{
    public Guid Cvid { get; set; }
    public Guid CandidateId { get; set; }

    [Required]
    [DataType(DataType.Url)]
    public string? CvPdf { get; set; }

    [Required]
    public string? CvName { get; set; }

    public string? AboutMe { get; set; }

    public bool IsDeleted { get; set; } = false;
    public bool IsDefault { get; set; } = false;

    public virtual ICollection<Application> Applications { get; set; } = null!;
    public virtual ICollection<CvHasSkill> CvHasSkills { get; set; } = null!;
    public virtual Candidate Candidate { get; set; } = null!;
}