using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("Company")]
public partial class Company
{
    [Key]
    [Column("CompanyId")]
    public Guid CompanyId { get; set; }

    [Column("CompanyName")]
    public string CompanyName { get; set; } 

    [DataType(DataType.ImageUrl)]
    public string? Logo { get; set; } 

    public string? Address { get; set; }

    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string? Phone { get; set; }

    [DataType(DataType.Url)]
    public string? Website { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Interviewer> Interviewers { get; set; } = new List<Interviewer>();
    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
    public virtual ICollection<Recruiter> Recruiters { get; set; } = new List<Recruiter>();
}