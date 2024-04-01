namespace Api.ViewModels.Position
{
    public class PositionFilterModel
    {
        public string? Search { get; set; }

        public int? FromSalary { get; set; }

        public int? ToSalary { get; set; }

        public int? FromMaxHiringQty { get; set; }

        public int? ToMaxHiringQty { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string? StringOfCategoryPositionIds { get; set; }

        public string? StringOfCompanyIds { get; set; }

        public string? StringOfLanguageIds { get; set; }

        public List<Guid> getListOfCategoryPositionIds()
        {
            if (this.StringOfCategoryPositionIds != null)
            {
                return this.StringOfCategoryPositionIds.Split(',').Select(Guid.Parse).ToList();
            }
            return null;
        }

        public List<Guid> getListOfCompanyIds()
        {
            if (this.StringOfCompanyIds != null)
            {
                return this.StringOfCompanyIds.Split(',').Select(Guid.Parse).ToList();
            }
            return null;
        }

        public List<Guid> getListOfLanguageIds()
        {
            if (this.StringOfLanguageIds != null)
            {
                return this.StringOfLanguageIds.Split(',').Select(Guid.Parse).ToList();
            }
            return null;
        }
    }
}