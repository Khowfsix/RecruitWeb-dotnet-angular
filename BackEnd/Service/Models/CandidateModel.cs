using Data.Entities;

namespace Service.Models
{
    public class CandidateModel
    {
        public Guid CandidateId { get; set; }

        public string UserId { get; set; }
        public virtual WebUser User { get; set; }
        public string? AboutMe { get; set; }

        public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
        public virtual ICollection<PersonalProject> PersonalProjects { get; set; } = new List<PersonalProject>();
        public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
        public virtual ICollection<Award> Awards { get; set; } = new List<Award>();

        public bool IsDeleted { get; set; } = false;
        public ICollection<CandidateHasSkillModel> CandidateHasSkills { get; set; }

        public virtual ICollection<BlackList> BlackLists { get; set; } = new List<BlackList>();
        public virtual ICollection<CandidateJoinEvent> CandidateJoinEvents { get; set; } = new List<CandidateJoinEvent>();
        public virtual ICollection<Cv> Cvs { get; set; } = new List<Cv>();
        public virtual ICollection<SuccessfulCadidate> SuccessfulCadidates { get; set; } = new List<SuccessfulCadidate>();
    }
}