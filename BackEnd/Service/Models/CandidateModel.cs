using Data.Entities;

namespace Service.Models
{
    public class CandidateModel
    {
        public Guid CandidateId { get; set; } = new();
        public string UserId { get; set; } = string.Empty;
        public virtual WebUser User { get; set; } = new();
        public string? Experience { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}