namespace Api.ViewModels.Application
{
    public class ApplicationUpdateModel
    {
        public Guid ApplicationId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid Cvid { get; set; }
        public Guid PositionId { get; set; }
        public DateTime DateTime { get; set; }

        public string Company_Status { get; set; } = string.Empty;

        public string Priority { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
    }
}