namespace Api.ViewModels.Position
{
    public class PositionAddModel
    {
        public string? PositionName { get; set; }

        public string? Description { get; set; }

        public IFormFile? ImageFile { get; set; }

        public decimal? Salary { get; set; }

        public int MaxHiringQty { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid CompanyId { get; set; }

        public Guid LanguageId { get; set; }

        public Guid RecruiterId { get; set; }

        public Guid CategoryPositionId { get; set; }

        //public bool IsDeleted { get; set; } = false;
    }
}