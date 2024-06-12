namespace Service.Models
{
    public class ApplicationModel
    {
        public Guid ApplicationId { get; set; }
        public Guid Cvid { get; set; }
        public Guid PositionId { get; set; }
        public virtual CvModel Cv { get; set; }
        public virtual PositionModel Position { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public int Candidate_Status { get; set; }
        public int Company_Status { get; set; }
        public int? Priority { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<InterviewModel> Interviews { get; set; } = new List<InterviewModel>();
    }
}