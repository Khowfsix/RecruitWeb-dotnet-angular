using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public partial class Certificate
{
    public Guid CertificateId { get; set; }

    [Required]
    public string? CertificateName { get; set; } = null!;

    public string? Description { get; set; }

    //public string? OrganizationName { get; set; }

    [DataType(DataType.Date)]
    public DateTime IssueDate { get; set; }

    [DataType(DataType.Url)]
    public string? CertificateURL { get; set; }


    //[DataType(DataType.Date)]
    //public DateTime? ExpirationDate { get; set; }

    public Guid CandidateId { get; set; }

    public virtual Candidate? Candidate { get; set; }
}