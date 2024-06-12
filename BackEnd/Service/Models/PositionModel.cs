namespace Service.Models;

public class PositionModel
{
    public Guid PositionId { get; set; }

    public string? PositionName { get; set; }

    public string? Description { get; set; }

    public string? ImageURL { get; set; }

    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }

    public int MaxHiringQty { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
    public Guid LevelId { get; set; }
    public LevelModel Level { get; set; }

    public Guid CompanyId { get; set; }
    public CompanyModel? Company { get; set; }

    public Guid LanguageId { get; set; }
    public LanguageModel? Language { get; set; }

    public Guid RecruiterId { get; set; }
    public RecruiterModel Recruiter { get; set; } 

    public Guid CategoryPositionId { get; set; }
    public CategoryPositionModel CategoryPosition { get; set; } 

    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<RequirementModel> Requirements { get; set; } = new List<RequirementModel>();
}