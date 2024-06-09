using Api.ViewModels.BlackList;
using Api.ViewModels.CandidateJoinEvent;
using Api.ViewModels.Certificate;
using Api.ViewModels.Cv;
using Api.ViewModels.SuccessfulCadidate;
using Data.Entities;
using Service.Models;

namespace Api.ViewModels.Candidate
{
    public class CandidateViewModel
    {
        public Guid CandidateId { get; set; }
        public string UserId { get; set; }
        public string? AboutMe { get; set; }
        public bool IsDeleted { get; set; } = false;
        public WebUser User { get; set; }

        public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
        public virtual ICollection<PersonalProject> PersonalProjects { get; set; } = new List<PersonalProject>();
        public virtual ICollection<CertificateViewModel> Certificates { get; set; } = new List<CertificateViewModel>();
        public virtual ICollection<Award> Awards { get; set; } = new List<Award>();

        public ICollection<CandidateHasSkillModel> CandidateHasSkills { get; set; }

        public virtual ICollection<BlacklistViewModel> BlackLists { get; set; } = new List<BlacklistViewModel>();
        public virtual ICollection<CandidateJoinEventViewModel> CandidateJoinEvents { get; set; } = new List<CandidateJoinEventViewModel>();
        public virtual ICollection<CvViewModel> Cvs { get; set; } = new List<CvViewModel>();
        public virtual ICollection<SuccessfulCadidateViewModel> SuccessfulCadidates { get; set; } = new List<SuccessfulCadidateViewModel>();
    }
}