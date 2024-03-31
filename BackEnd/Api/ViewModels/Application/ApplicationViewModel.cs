using Api.ViewModels.Cv;
using Api.ViewModels.Position;

namespace Api.ViewModels.Application
{
    public class ApplicationViewModel
    {
        public Guid ApplicationId { get; set; } = new();

        public virtual CvViewModel Cv { get; set; } = new();

        public PositionViewModel Position { get; set; } = new();

        public DateTime DateTime { get; set; } = new();

        public string Company_Status { get; set; } = string.Empty;

        public string Candidate_Status { get; set; } = string.Empty;

        public string Priority { get; set; } = string.Empty;
    }
}