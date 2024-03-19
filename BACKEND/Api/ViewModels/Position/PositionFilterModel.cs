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

        public string? stringOfCategoryPositionIds { get; set; }

        public string? stringOfCompanyIds { get; set; }

        public string? stringOfLanguageIds { get; set; }

        public List<Guid> getListOfCategoryPositionIds()
        {
            if (this.stringOfCategoryPositionIds != null)
            {
                return this.stringOfCategoryPositionIds.Split(',').Select(Guid.Parse).ToList();
            }
            return null;
        }

        public List<Guid> getListOfCompanyIds()
        {
            if (this.stringOfCompanyIds != null)
            {
                return this.stringOfCompanyIds.Split(',').Select(Guid.Parse).ToList();
            }
            return null;
        }

        public List<Guid> getListOfLanguageIds()
        {
            if (this.stringOfLanguageIds != null)
            {
                return this.stringOfLanguageIds.Split(',').Select(Guid.Parse).ToList();
            }
            return null;
        }
    }
}