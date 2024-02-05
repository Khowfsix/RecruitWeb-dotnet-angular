namespace Api.ViewModels.Application
{
    public class ApplicationUpdateModel
    {
        public Guid ApplicationId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid Cvid { get; set; }
        public Guid PositionId { get; set; }
        public DateTime DateTime { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Company_Status { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Priority { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public bool IsDeleted { get; set; } = false;
    }
}