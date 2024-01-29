
using Api.ViewModels.Department;
using Api.ViewModels.Language;
using Api.ViewModels.Recruiter;
using Api.ViewModels.Requirement;
using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels.Position
{
    public class PositionViewModel
    {
        [Key]
        public Guid PositionId { get; set; }

        public string? PositionName { get; set; }

        public string? Description { get; set; }

        public decimal? Salary { get; set; }

        public int MaxHiringQty { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DepartmentViewModel Department { get; set; }

        public LanguageViewModel Language { get; set; }

        public RecruiterViewModel Recruiter { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<RequirementViewModel> Requirements { get; set; } = new List<RequirementViewModel>();
    }
}