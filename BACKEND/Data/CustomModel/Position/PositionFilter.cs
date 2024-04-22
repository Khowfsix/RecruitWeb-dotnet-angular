namespace Data.CustomModel.Position
{
    public class PositionFilter
    {
        public string? Search { get; set; }

        public Guid? UserId { get; set; }

        public int? FromSalary { get; set; }

        public int? ToSalary { get; set; }

        public int? FromMaxHiringQty { get; set; }

        public int? ToMaxHiringQty { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public List<Guid>? CategoryPositionIds { get; set; }

        public List<Guid>? CompanyIds { get; set; }

        public List<Guid>? LanguageIds { get; set; }
    }
}