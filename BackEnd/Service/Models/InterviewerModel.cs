using Data.Entities;

namespace Service.Models
{
    public class InterviewerModel
    {
        public Guid InterviewerId { get; set; }

        public string UserId { get; set; }

        public virtual WebUser User { get; set; }

        public Guid CompanyId { get; set; }
        public virtual CompanyModel Company { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}