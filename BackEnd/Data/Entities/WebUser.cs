using Microsoft.AspNetCore.Identity;

namespace Data.Entities;

public partial class WebUser : IdentityUser
{
    public string? FullName { get; set; }
    public string? Title { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PersonalLink { get; set; }
    public string? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public string? ImageURL { get; set; } = null;

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
    public virtual ICollection<Interviewer> Interviewers { get; set; } = new List<Interviewer>();
    public virtual ICollection<Recruiter> Recruiters { get; set; } = new List<Recruiter>();

    public virtual ICollection<SecurityAnswer> SecurityAnswers { get; set; } = new List<SecurityAnswer>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}