using Data.Entities;

namespace Service.Models;

public partial class RecruiterModel
{
    public Guid RecruiterId { get; set; }
    public string UserId { get; set; } = null!;
    public virtual WebUser User { get; set; } = null!;
    public Guid CompanyId { get; set; }
    public virtual CompanyModel Company { get; set; } = null!;
    public bool IsDeleted { get; set; } = false;
}