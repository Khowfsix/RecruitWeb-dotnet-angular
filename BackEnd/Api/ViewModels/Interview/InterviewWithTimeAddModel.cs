using Api.ViewModels.Itrsinterview;

namespace Api.ViewModels.Interview
{
    public class InterviewWithTimeAddModel
    {
        public InterviewAddModel Interview { get; set; } = new();

        public ItrsinterviewAddModel ITRS { get; set; } = new();
    }
}