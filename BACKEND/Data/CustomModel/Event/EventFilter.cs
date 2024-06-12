namespace Data.CustomModel.Event
{
    public class EventFilter
    {
        public string? Search { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? FromMaxParticipants { get; set; }
        public int? ToMaxParticipants { get; set; }
    }
}