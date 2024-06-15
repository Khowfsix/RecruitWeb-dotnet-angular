using Data.Entities;
using Service.Models;

namespace Api.ViewModels
{
    public class WebUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
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

        public virtual ICollection<CandidateModel> Candidates { get; set; } = new List<CandidateModel>();
        public virtual ICollection<InterviewerModel> Interviewers { get; set; } = new List<InterviewerModel>();
        public virtual ICollection<RecruiterModel> Recruiters { get; set; } = new List<RecruiterModel>();
        public virtual ICollection<SecurityAnswerModel> SecurityAnswers { get; set; } = new List<SecurityAnswerModel>();

    }
}