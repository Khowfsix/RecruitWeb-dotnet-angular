using Data.Entities;

namespace Service.Models
{
    public class InterviewerModel
    {
        public Guid InterviewerId { get; set; } = new();
        public string UserId { get; set; } = string.Empty;
        public virtual WebUser User { get; set; } = new();
        public Guid CompanyId { get; set; } = new();
        public bool IsDeleted { get; set; } = false;
    }
}