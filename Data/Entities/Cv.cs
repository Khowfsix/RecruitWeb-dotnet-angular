using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public partial class Cv
{
    public Guid Cvid { get; set; }

    public Guid CandidateId { get; set; }

    public string? Experience { get; set; }

    public string? CvPdf { get; set; }

    [Required]
    [DataType(DataType.ImageUrl)]
    public string CvName { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [Required]
    public string Introduction { get; set; } = null!;

    [Required]
    public string Education { get; set; } = null!;

    public bool IsDeleted { get; set; } = false;

    public bool IsDefault { get; set; } = false;

    public virtual ICollection<Application> Applications { get; set; } = null!;

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual ICollection<Certificate> Certificates { get; set; } = null!;

    public virtual ICollection<CvHasSkill> CvHasSkills { get; set; } = null!;
}