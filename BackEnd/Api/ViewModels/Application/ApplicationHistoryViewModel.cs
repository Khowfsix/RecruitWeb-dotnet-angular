using Api.ViewModels.Cv;
using Api.ViewModels.Position;
using System.Text.Json.Serialization;

namespace Api.ViewModels.Application;

public class ApplicationHistoryViewModel
{
    public Guid ApplicationId { get; set; }
    public Guid PositionId { get; set; }
    public PositionViewModel Position { get; set; }
    public Guid Cvid { get; set; }
    public DateTime CreatedTime { get; set; }

    [JsonPropertyName("Status")]
    public string? Candidate_status { get; set; }

    public string? Priority { get; set; }
}