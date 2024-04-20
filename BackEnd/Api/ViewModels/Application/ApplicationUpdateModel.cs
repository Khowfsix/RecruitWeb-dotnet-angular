namespace Api.ViewModels.Application
{
    public class ApplicationUpdateModel
    {
        public Guid ApplicationId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid Cvid { get; set; }
        public Guid PositionId { get; set; }
        public DateTime CreatedTime { get; set; }
        public int? Company_Status { get; set; }

        public int? Priority { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}