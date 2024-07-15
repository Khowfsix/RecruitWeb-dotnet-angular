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

    public ICollection<Application> Applications { get; set; } = null!;
    //public ICollection<CvHasSkill> CvHasSkills { get; set; } = null!;
    public Candidate Candidate { get; set; } = null!;
}